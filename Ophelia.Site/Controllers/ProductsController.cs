using Microsoft.AspNetCore.Mvc;
using Ophelia.Services;
using System;

namespace Ophelia.Site.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsServices _services;

        public ProductsController(IProductsServices services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        [HttpGet]
        [Route("GetProducts")]
        public IActionResult GetProducts()
        {
            try
            {
                var response = _services.GetProducts();
                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}