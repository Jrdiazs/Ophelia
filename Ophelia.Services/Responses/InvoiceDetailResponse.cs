using Ophelia.Services.ModelView;
using System.Collections.Generic;

namespace Ophelia.Services.Responses
{
    public class InvoiceDetailResponse : ResponseData<InvoiceDetailModelView>
    {
        public InvoiceDetailResponse()
        {
            Data = new InvoiceDetailModelView();
        }
    }

    public class InvoiceDetailResponseList : ResponseData<List<InvoiceDetailModelView>>
    {
        public InvoiceDetailResponseList()
        {
            Data = new List<InvoiceDetailModelView> { };
        }
    }
}