using AutoMapper;
using Ophelia.Data;
using Ophelia.Services.ModelView;
using Ophelia.Services.Responses;
using System;
using System.Collections.Generic;

namespace Ophelia.Services
{
    public class TypeDocumentServices : BaseServices, ITypeDocumentServices
    {
        private readonly ITypeDocumentRepository _typeDocumentRepository;

        public TypeDocumentServices(ITypeDocumentRepository typeDocumentRepository, IMapper mapper) : base(mapper)
        {
            _typeDocumentRepository = typeDocumentRepository ?? throw new ArgumentNullException(nameof(typeDocumentRepository));
        }

        public TypeDocumentResponseList GetTypeDocuments()
        {
            TypeDocumentResponseList response = new TypeDocumentResponseList();
            try
            {
                var typeDocuments = _typeDocumentRepository.GetAll();
                var typeDocumentsResponse = Mapper.Map<List<TypeDocumentModelView>>(typeDocuments);
                response.Ok(typeDocumentsResponse);
            }
            catch (Exception ex)
            {
                response.Error(ex);
            }
            return response;
        }
    }

    public interface ITypeDocumentServices
    {
        TypeDocumentResponseList GetTypeDocuments();
    }
}