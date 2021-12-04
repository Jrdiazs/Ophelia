using Dapper;
using Ophelia.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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
                var invoices = Connection.Query<Invoice>(sql: "OpheliaDB_SP_Invoice_Search", new
                {
                    InvoiceId = invoiceNumber,
                    CustomerId = customerId
                }, commandType: CommandType.StoredProcedure).ToList();

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