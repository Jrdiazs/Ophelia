using AutoMapper;
using Ophelia.Models;
using Ophelia.Services.ModelView;

namespace Ophelia.Services.Profiles
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<Invoice, InvoiceModelView>().
              ForMember(x => x.Id, y => y.MapFrom(src => src.InvoiceId)).
              ForMember(x => x.Customer, y => y.MapFrom(src => src.CustomerId)).
              ForMember(x => x.TotalBill, y => y.MapFrom(src => src.TotalBill)).
              ForMember(x => x.CreationDate, y => y.MapFrom(src => src.CreationDate)).
              ForMember(x => x.CustomerName, y => y.MapFrom(src => src.CustomerName)).
              ForMember(x => x.InvoiceNumber, y => y.MapFrom(src => src.InvoiceNumber)).
              ReverseMap();
        }
    }
}