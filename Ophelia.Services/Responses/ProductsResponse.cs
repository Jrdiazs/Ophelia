using Ophelia.Services.ModelView;
using System.Collections.Generic;

namespace Ophelia.Services.Responses
{
    public class ProductsResponse : ResponseData<ProductsModelView>
    {
        public ProductsResponse()
        {
            Data = new ProductsModelView();
        }
    }

    public class ProductsResponseList : ResponseData<List<ProductsModelView>>
    {
        public ProductsResponseList()
        {
            Data = new List<ProductsModelView> { };
        }
    }
}