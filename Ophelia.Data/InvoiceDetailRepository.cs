using Dapper;
using Ophelia.Models;
using System;
using System.Data;

namespace Ophelia.Data
{
    public class InvoiceDetailRepository : RepositoryGeneric<InvoiceDetail>, IDisposable, IInvoiceDetailRepository
    {
        public InvoiceDetailRepository()
        { }

        public InvoiceDetail SaveInvoiceDetail(InvoiceDetail invoice)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@InvoiceDetailId", dbType: DbType.Int32, direction: ParameterDirection.InputOutput, value: invoice.InvoiceDetailId);
                parameters.Add("@InvoiceId", dbType: DbType.Int32, direction: ParameterDirection.Input, value: invoice.InvoiceId);
                parameters.Add("@ProductId", dbType: DbType.Int32, direction: ParameterDirection.Input, value: invoice.ProductId);
                parameters.Add("@ProductQuantity", dbType: DbType.Int32, direction: ParameterDirection.Input, value: invoice.ProductQuantity);
                parameters.Add("@ProductValue", dbType: DbType.Decimal, direction: ParameterDirection.Input, value: invoice.ProductValue);
                parameters.Add("@TotalValue", dbType: DbType.Decimal, direction: ParameterDirection.Input, value: invoice.TotalValue);

                using (var conex = Connection)
                {
                    conex.Open();
                    using (var trx = conex.BeginTransaction())
                    {
                        try
                        {
                            conex.Execute(sql: "OpheliaDB_SP_InvoiceDetail_Save", param: parameters, transaction: trx, commandType: CommandType.StoredProcedure);
                            invoice.InvoiceDetailId = parameters.Get<int>("@InvoiceDetailId");
                            trx.Commit();
                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            throw;
                        }
                    }
                }

                return invoice;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int DeleteInvoiceDetail(int invoiceDetailId)
        {
            try
            {
                int rowsAffected = 0;
                using (var conex = Connection)
                {
                    conex.Open();
                    using (var trx = conex.BeginTransaction())
                    {
                        try
                        {
                            rowsAffected = conex.Execute(sql: "OpheliaDB_SP_InvoiceDetail_Delete", param: new { InvoiceDetailId = invoiceDetailId }, transaction: trx, commandType: CommandType.StoredProcedure);

                            trx.Commit();
                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            throw;
                        }
                    }
                }

                return rowsAffected;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public interface IInvoiceDetailRepository : IRepositoryGeneric<InvoiceDetail>, IDisposable
    {
        InvoiceDetail SaveInvoiceDetail(InvoiceDetail invoice);

        int DeleteInvoiceDetail(int invoiceDetailId);
    }
}