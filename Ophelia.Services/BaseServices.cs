using AutoMapper;

namespace Ophelia.Services
{
    public class BaseServices
    {
        public IMapper Mapper { get; }

        public BaseServices(IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}