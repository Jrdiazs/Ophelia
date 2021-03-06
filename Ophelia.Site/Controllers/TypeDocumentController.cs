using Microsoft.AspNetCore.Mvc;
using Ophelia.Services;
using System;

namespace Ophelia.Site.Controllers
{
    [ApiController]
    [Route("Api/TypeDocument")]
    public class TypeDocumentController : ControllerBase
    {
        private readonly ITypeDocumentServices _services;

        public TypeDocumentController(ITypeDocumentServices services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        [HttpGet]
        [Route("GetTypeDocuments")]
        public IActionResult GetTypeDocuments()
        {
            try
            {
                var typeDocuments = _services.GetTypeDocuments();
                return Ok(typeDocuments);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}