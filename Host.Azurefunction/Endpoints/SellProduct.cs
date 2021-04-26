using System.Threading.Tasks;
using Common.SellingService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Host.AzureFunction.Endpoints
{
    public class SellProduct
    {
        private readonly IProductSellingService _productSellingService;
        public SellProduct(IProductSellingService productSellingService)
        {
            _productSellingService = productSellingService;
        }

        [FunctionName(nameof(SellProduct))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            //TODO - should be contained in a service
            var productId = req.Query["productId"];
            if (!_productSellingService.CanSellProduct(productId))
                return new NotFoundObjectResult("Can't be sold");
            
            _productSellingService.SellProduct(productId);

            const string responseMessage = "Product sold";
            return new OkObjectResult(responseMessage);
        }
    }
}

