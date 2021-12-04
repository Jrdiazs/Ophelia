using Ophelia.Services.ModelView;
using System.Collections.Generic;

namespace Ophelia.Services.Responses
{
    public class InvoiceResponse : ResponseData<InvoiceModelView>
    {
        public InvoiceResponse()
        {
            Data = new InvoiceModelView();
        }
    }

    public class InvoiceResponseList : ResponseData<List<InvoiceModelView>>
    {
        public InvoiceResponseList()
        {
            Data = new List<InvoiceModelView> { };
        }
    }
}