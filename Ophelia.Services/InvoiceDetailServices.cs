using AutoMapper;
using Ophelia.Data;
using System;

namespace Ophelia.Services
{
    public class InvoiceDetailServices : BaseServices, IInvoiceDetailServices
    {
        private readonly IInvoiceDetailRepository _invoiceDetailRepository;

        public InvoiceDetailServices(IInvoiceDetailRepository invoiceDetailRepository, IMapper mapper) : base(mapper)
        {
            _invoiceDetailRepository = invoiceDetailRepository ?? throw new ArgumentNullException(nameof(invoiceDetailRepository));
        }
    }

    public interface IInvoiceDetailServices
    { }
}