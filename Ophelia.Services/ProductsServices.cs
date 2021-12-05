using AutoMapper;
using Ophelia.Data;
using Ophelia.Services.ModelView;
using Ophelia.Services.Responses;
using System;
using System.Collections.Generic;

namespace Ophelia.Services
{
    public class ProductsServices : BaseServices, IProductsServices
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsServices(IProductsRepository productsRepository, IMapper mapper) : base(mapper)
        {
            _productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
        }

        public ProductsResponseList GetProducts()
        {
            ProductsResponseList response = new ProductsResponseList();
            try
            {
                var products = _productsRepository.GetAll();
                var productsResponse = Mapper.Map<List<ProductsModelView>>(products);
                response.Ok(productsResponse);
            }
            catch (Exception ex)
            {
                response.Error(ex);
            }
            return response;
        }
    }

    public interface IProductsServices
    {
        ProductsResponseList GetProducts();
    }
}