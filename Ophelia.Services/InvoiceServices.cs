using AutoMapper;
using Ophelia.Data;
using Ophelia.Models;
using Ophelia.Services.ModelView;
using Ophelia.Services.Request;
using Ophelia.Services.Responses;
using System;
using System.Collections.Generic;

namespace Ophelia.Services
{
    public class InvoiceServices : BaseServices, IInvoiceServices
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceServices(IInvoiceRepository invoiceRepository, IMapper mapper) : base(mapper)
        {
            _invoiceRepository = invoiceRepository ?? throw new ArgumentNullException(nameof(invoiceRepository));
        }

        public InvoiceResponse SaveInvoice(InvoiceModelView invoice)
        {
            InvoiceResponse response = new InvoiceResponse();
            try
            {
                var invoiceBd = Mapper.Map<Invoice>(invoice);
                if (_invoiceRepository.Count("WHERE InvoiceId = @id", new { id = invoiceBd.InvoiceId }) > 0)
                    invoiceBd = _invoiceRepository.Update(invoiceBd);
                else
                {
                    invoiceBd.CreationDate = DateTime.Now;
                    invoiceBd.TotalBill = 0;
                    invoiceBd.InvoiceId = _invoiceRepository.Insert<int>(invoiceBd);
                }

                invoice.Id = invoiceBd.InvoiceId;
                response.Ok(invoice, "Factura guardada correctamente");
            }
            catch (Exception ex)
            {
                response.Error(ex);
            }
            return response;
        }

        public InvoiceResponse GetInvoiceById(int invoiceId)
        {
            InvoiceResponse response = new InvoiceResponse();
            try
            {
                var invoice = _invoiceRepository.GetFindId(invoiceId);

                if (invoice == null)
                {
                    response.Error($"Invoice no encontrada por id {invoiceId}");
                    return response;
                }

                var invoiceResponse = Mapper.Map<InvoiceModelView>(invoice);
                response.Ok(invoiceResponse);
            }
            catch (Exception ex)
            {
                response.Error(ex);
            }
            return response;
        }

        public InvoiceResponseList GetInvoicesSearch(InvoiceFilter request)
        {
            var response = new InvoiceResponseList();
            try
            {
                var invoices = _invoiceRepository.GetInvoicesSearch(request.InvoiceNumber, request.CustomerId);
                var invoicesResponse = Mapper.Map<List<InvoiceModelView>>(invoices);
                response.Ok(invoicesResponse);
            }
            catch (Exception ex)
            {
                response.Error(ex);
            }
            return response;
        }
    }

    public interface IInvoiceServices
    {
        InvoiceResponse SaveInvoice(InvoiceModelView invoice);

        InvoiceResponse GetInvoiceById(int invoiceId);

        InvoiceResponseList GetInvoicesSearch(InvoiceFilter request);
    }
}