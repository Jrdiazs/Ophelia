using Microsoft.AspNetCore.Mvc;
using Ophelia.Services;
using Ophelia.Services.Responses;
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
        public TypeDocumentResponseList GetTypeDocuments() 
        {
           
            try
            {   var typeDocuments = _services.GetTypeDocuments();
                return typeDocuments;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
