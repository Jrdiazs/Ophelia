using Ophelia.Services.ModelView;
using System.Collections.Generic;

namespace Ophelia.Services.Responses
{
    public class CustomersResponse : ResponseData<CustomersModelView>
    {
        public CustomersResponse()
        {
            Data = new CustomersModelView();
        }
    }

    public class CustomersResponseList : ResponseData<List<CustomersModelView>>
    {
        public CustomersResponseList()
        {
            Data = new List<CustomersModelView>();
        }
    }
}