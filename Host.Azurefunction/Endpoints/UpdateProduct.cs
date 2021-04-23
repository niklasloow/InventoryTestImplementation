using System.Threading.Tasks;
using Common.SellingService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Host.AzureFunction.Endpoints.Products
{
    public class UpdateProduct
    {
        private readonly IProductSellingService _productSellingService;
        public UpdateProduct(IProductSellingService productSellingService)
        {
            _productSellingService = productSellingService;
        }

        [FunctionName(nameof(UpdateProduct))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            var productId = req.Query["productId"];
            if (!_productSellingService.CanSellProduct(productId))
                return new NotFoundObjectResult("Can't be sold");
            
            _productSellingService.SellProduct(productId);

            const string responseMessage = "Product sold";
            return new OkObjectResult(responseMessage);
        }
    }
}

