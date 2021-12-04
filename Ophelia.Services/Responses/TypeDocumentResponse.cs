using Ophelia.Services.ModelView;
using System.Collections.Generic;

namespace Ophelia.Services.Responses
{
    public class TypeDocumentResponse : ResponseData<TypeDocumentModelView>
    {
        public TypeDocumentResponse()
        {
            Data = new TypeDocumentModelView();
        }
    }

    public class TypeDocumentResponseList : ResponseData<List<TypeDocumentModelView>>
    {
        public TypeDocumentResponseList()
        {
            Data = new List<TypeDocumentModelView>();
        }
    }
}