using Ophelia.Models;
using System;
using System.Collections.Generic;

namespace Ophelia.Data
{
    public class InvoiceRepository : RepositoryGeneric<Invoice>, IInvoiceRepository, IDisposable
    {
        public InvoiceRepository()
        { }

        public List<Invoice> GetInvoicesSearch(int? invoiceNumber, int? customerId) 
        {
            try
            {
                var invoices = GetList("WHERE (InvoiceNumber = @invoice OR @invoice IS NULL)" +
                    " AND (CustomerId = @cutomer OR @customer IS NULL)", new { invoice = invoiceNumber, customer = customerId });

                return invoices?? new List<Invoice>();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public interface IInvoiceRepository : IRepositoryGeneric<Invoice>, IDisposable
    {
        List<Invoice> GetInvoicesSearch(int? invoiceNumber, int? customerId);
    }
}