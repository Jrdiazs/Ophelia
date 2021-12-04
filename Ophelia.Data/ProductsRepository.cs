using Ophelia.Models;
using System;

namespace Ophelia.Data
{
    public class ProductsRepository : RepositoryGeneric<Products>, IDisposable, IProductsRepository
    {
        public ProductsRepository()
        { }
    }

    public interface IProductsRepository : IRepositoryGeneric<Products>, IDisposable
    { }
}