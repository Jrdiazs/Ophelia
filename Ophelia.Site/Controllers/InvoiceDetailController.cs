using Microsoft.AspNetCore.Mvc;
using Ophelia.Services;
using Ophelia.Services.ModelView;
using System;

namespace Ophelia.Site.Controllers
{
    [Route("api/InvoiceDetail")]
    [ApiController]
    public class InvoiceDetailController : ControllerBase
    {
        private readonly IInvoiceDetailServices _services;

        public InvoiceDetailController(IInvoiceDetailServices services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        [HttpPost]
        [Route("SaveInvoiceDetail")]
        public IActionResult SaveInvoiceDetail([FromBody] InvoiceDetailModelView request)
        {
            try
            {
                var response = _services.SaveInvoiceDetail(request);

                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetInvoiceDetailFromByInvoiceId")]
        public IActionResult GetInvoiceDetailFromByInvoiceId(int invoiceId)
        {
            try
            {
                var response = _services.GetInvoiceDetailFromByInvoiceId(invoiceId);

                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}