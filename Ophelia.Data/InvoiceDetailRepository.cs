using System;

namespace Ophelia.Data
{
    public class InvoiceDetailRepository : RepositoryGeneric<InvoiceDetailRepository>, IDisposable, IInvoiceDetailRepository
    {
        public InvoiceDetailRepository()
        { }
    }

    public interface IInvoiceDetailRepository : IRepositoryGeneric<InvoiceDetailRepository>, IDisposable
    { }
}