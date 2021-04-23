using System.Threading.Tasks;
using Common.SellingService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Host.AzureFunction.Endpoints.Products
{
    public class GetAllProducts
    {
        private readonly IProductSellingService _productSellingService;
        public GetAllProducts(IProductSellingService productSellingService)
        {
            _productSellingService = productSellingService;
        }

        [FunctionName(nameof(GetAllProducts))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            return new OkObjectResult(_productSellingService.GetAllSellableProduct());
        }
    }
}

