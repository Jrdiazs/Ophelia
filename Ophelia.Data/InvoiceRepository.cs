using Ophelia.Models;
using System;

namespace Ophelia.Data
{
    public class InvoiceRepository : RepositoryGeneric<Invoice>, IInvoiceRepository, IDisposable
    {
        public InvoiceRepository()
        { }
    }

    public interface IInvoiceRepository : IRepositoryGeneric<Invoice>, IDisposable
    { }
}