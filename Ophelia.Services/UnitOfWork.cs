using Ophelia.Data;
using System;

namespace Ophelia.Services
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region [Properties]

        private readonly IProductsRepository _productsRepository;
        private readonly IInvoiceDetailRepository _invoiceDetailRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IParametersRepository _parametersRepository;

        #endregion [Properties]

        #region [Constructor]

        public UnitOfWork(IProductsRepository productsRepository, IInvoiceDetailRepository invoiceDetailRepository, IInvoiceRepository invoiceRepository, IParametersRepository parametersRepository)
        {
            _productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
            _invoiceDetailRepository = invoiceDetailRepository ?? throw new ArgumentNullException(nameof(invoiceDetailRepository));
            _invoiceRepository = invoiceRepository ?? throw new ArgumentNullException(nameof(invoiceRepository));
            _parametersRepository = parametersRepository ?? throw new ArgumentNullException(nameof(parametersRepository));
        }

        #endregion [Constructor]

        #region [Properties]

        public IProductsRepository ProductsRepository => _productsRepository;

        public IInvoiceDetailRepository InvoiceDetailRepository => _invoiceDetailRepository;

        public IInvoiceRepository InvoiceRepository => _invoiceRepository;

        public IParametersRepository ParametersRepository => _parametersRepository;

        #endregion [Properties]

        #region [Dispose]

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)

                    if (_parametersRepository != null)
                        _parametersRepository.Dispose();

                    if (_invoiceDetailRepository != null)
                        _invoiceDetailRepository.Dispose();

                    if (_invoiceRepository != null)
                        _invoiceRepository.Dispose();

                    if (_productsRepository != null)
                        _productsRepository.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion [Dispose]
    }

    public interface IUnitOfWork : IDisposable
    {
        IProductsRepository ProductsRepository { get; }
        IInvoiceDetailRepository InvoiceDetailRepository { get; }

        IInvoiceRepository InvoiceRepository { get; }

        IParametersRepository ParametersRepository { get; }
    }
}