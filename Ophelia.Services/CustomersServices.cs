using AutoMapper;
using Ophelia.Data;
using Ophelia.Services.ModelView;
using Ophelia.Services.Responses;
using System;
using System.Collections.Generic;

namespace Ophelia.Services
{
    public class CustomersServices : BaseServices, ICustomersServices
    {
        private readonly ICustomersRepository _customersRepository;

        public CustomersServices(ICustomersRepository customersRepository, IMapper mapper) : base(mapper)
        {
            _customersRepository = customersRepository ?? throw new ArgumentNullException(nameof(customersRepository));
        }

        public CustomersResponseList GetCustomers()
        {
            CustomersResponseList response = new CustomersResponseList();
            try
            {
                var customers = _customersRepository.GetAll();
                var customersResponse = Mapper.Map<List<CustomersModelView>>(customers);
                response.Ok(customersResponse);
            }
            catch (Exception ex)
            {
                response.Error(ex);
            }
            return response;
        }
    }

    public interface ICustomersServices
    {
        CustomersResponseList GetCustomers();
    }
}