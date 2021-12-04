using Microsoft.AspNetCore.Mvc;
using Ophelia.Services;
using System;

namespace Ophelia.Site.Controllers
{
    [Route("api/Customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersServices _services;

        public CustomersController(ICustomersServices services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        [HttpGet]
        [Route("GetCustomers")]
        public IActionResult GetCustomers()
        {
            try
            {
                var customers = _services.GetCustomers();
                return Ok(customers);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}