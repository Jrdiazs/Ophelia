using AutoMapper;
using Ophelia.Models;
using Ophelia.Services.ModelView;

namespace Ophelia.Services.Profiles
{
    public class TypeDocumentProfile : Profile
    {
        public TypeDocumentProfile()
        {
            CreateMap<TypeDocument, TypeDocumentModelView>().
             ForMember(x => x.Id, y => y.MapFrom(src => src.TypeDocumentId)).
             ForMember(x => x.TypeDocumentName, y => y.MapFrom(src => src.TypeDocumentName)).
             ForMember(x => x.TypeDocumentNameShort, y => y.MapFrom(src => src.TypeDocumentNameShort)).
             ReverseMap();
        }
    }
}