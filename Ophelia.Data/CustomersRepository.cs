using Ophelia.Models;
using System;

namespace Ophelia.Data
{
    public class CustomersRepository : RepositoryGeneric<Customers>, IDisposable, ICustomersRepository
    {
        public CustomersRepository()
        { }
    }

    public interface ICustomersRepository : IRepositoryGeneric<Customers>, IDisposable
    { }
}