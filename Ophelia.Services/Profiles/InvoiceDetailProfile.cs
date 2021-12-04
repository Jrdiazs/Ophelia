using AutoMapper;
using Ophelia.Models;
using Ophelia.Services.ModelView;

namespace Ophelia.Services.Profiles
{
    public class InvoiceDetailProfile : Profile
    {
        public InvoiceDetailProfile()
        {
            CreateMap<InvoiceDetail, InvoiceDetailModelView>().
              ForMember(x => x.Invoice, y => y.MapFrom(src => src.InvoiceId)).
              ForMember(x => x.Id, y => y.MapFrom(src => src.InvoiceDetailId)).
              ForMember(x => x.Product, y => y.MapFrom(src => src.ProductId)).
              ForMember(x => x.ProductValue, y => y.MapFrom(src => src.ProductValue)).
              ForMember(x => x.TotalValue, y => y.MapFrom(src => src.TotalValue)).
              ForMember(x => x.CreationDate, y => y.MapFrom(src => src.CreationDate)).
              ForMember(x => x.ProductQuantity, y => y.MapFrom(src => src.ProductQuantity)).
              ReverseMap();
        }
    }
}