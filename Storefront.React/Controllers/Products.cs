﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models;
using Common.SellingService;

namespace Storefront.React.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductSellingService _productSellingService;

        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger, IProductSellingService productSellingService)
        {
            _logger = logger;
            _productSellingService = productSellingService;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _productSellingService.GetAllSellableProduct();
        }
    }
}