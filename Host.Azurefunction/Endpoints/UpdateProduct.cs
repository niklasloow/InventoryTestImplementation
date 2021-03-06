using System;
using System.Threading.Tasks;
using Common.SellingService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Host.AzureFunction.Endpoints
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
            throw new NotImplementedException();
        }
    }
}

