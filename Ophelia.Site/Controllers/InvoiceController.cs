using Microsoft.AspNetCore.Mvc;
using Ophelia.Services;
using Ophelia.Services.ModelView;
using Ophelia.Services.Request;
using System;

namespace Ophelia.Site.Controllers
{
    [Route("api/Invoice")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceServices _services;

        public InvoiceController(IInvoiceServices services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        [HttpPost]
        [Route("GetInvoicesSearch")]
        public IActionResult GetInvoicesSearch([FromBody] InvoiceFilter request)
        {
            try
            {
                var invoices = _services.GetInvoicesSearch(request);
                return Ok(invoices);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetInvoiceById")]
        public IActionResult GetInvoiceById(int invoiceId)
        {
            try
            {
                var invoices = _services.GetInvoiceById(invoiceId);
                return Ok(invoices);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPost]
        [Route("SaveInvoice")]
        public IActionResult SaveInvoice([FromBody] InvoiceModelView invoice)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = _services.SaveInvoice(invoice);
                    return Ok(response);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}