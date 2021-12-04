using AutoMapper;
using Ophelia.Models;
using Ophelia.Services.ModelView;

namespace Ophelia.Services.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Products, ProductsModelView>().
              ForMember(x => x.Id, y => y.MapFrom(src => src.ProductId)).
              ForMember(x => x.PriceByUnit, y => y.MapFrom(src => src.PriceByUnit)).
              ForMember(x => x.InventoryQuantity, y => y.MapFrom(src => src.InventoryQuantity)).
              ForMember(x => x.ProductName, y => y.MapFrom(src => src.ProductName)).
              ReverseMap();
        }
    }
}