using AutoMapper;
using Ophelia.Models;
using Ophelia.Services.ModelView;

namespace Ophelia.Services.Profiles
{
    public class CustomersProfile : Profile
    {
        public CustomersProfile()
        {
            CreateMap<Customers, CustomersModelView>().
               ForMember(x => x.TypeDocument, y => y.MapFrom(src => src.TypeDocumentId)).
               ForMember(x => x.BirthdayDate, y => y.MapFrom(src => src.BirthdayDate)).
               ForMember(x => x.Id, y => y.MapFrom(src => src.CustomerId)).
               ForMember(x => x.CustomerNames, y => y.MapFrom(src => src.CustomerNames)).
               ForMember(x => x.CustomerLastNames, y => y.MapFrom(src => src.CustomerLastNames)).
               ForMember(x => x.CreationDate, y => y.MapFrom(src => src.CreationDate)).
               ForMember(x => x.Email, y => y.MapFrom(src => src.Email)).
               ForMember(x => x.Document, y => y.MapFrom(src => src.DocumentNumber)).
               ReverseMap();
        }
    }
}