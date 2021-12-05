using AutoMapper;
using Ophelia.Models;
using Ophelia.Services.ModelView;
using Ophelia.Services.Responses;
using Ophelia.Tools;
using System;
using System.Collections.Generic;

namespace Ophelia.Services
{
    public class InvoiceDetailServices : BaseServices, IInvoiceDetailServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public InvoiceDetailServices(IUnitOfWork unitOfWork, IMapper mapper) : base(mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public InvoiceDetailResponse SaveInvoiceDetail(InvoiceDetailModelView invoice)
        {
            var response = new InvoiceDetailResponse();

            try
            {
                var invoiceModel = Mapper.Map<InvoiceDetail>(invoice);
                if (invoiceModel.ProductQuantity == 0)
                {
                    response.Error("The amount must be greater than 0");
                    return response;
                }

                var product = _unitOfWork.ProductsRepository.GetFindId(invoiceModel.ProductId);
                var allowedAmount = _unitOfWork.ParametersRepository.GetValueFromByKey<int>("allowedAmount");
                var quantity = product.InventoryQuantity;
                var quantityNow = quantity - invoiceModel.ProductQuantity;

                if (quantityNow < allowedAmount)
                {
                    response.Error("The purchase cannot be made, since the number of minimum inventory products remains");
                    return response;
                }

                if (quantityNow < 0)
                {
                    response.Error("The purchase cannot be made as the product is not available in inventory");
                    return response;
                }

                invoiceModel.CreationDate = DateTime.Now;
                invoiceModel.ProductValue = product.PriceByUnit;
                invoiceModel.TotalValue = invoiceModel.ProductQuantity * invoiceModel.ProductValue;

                invoiceModel = _unitOfWork.InvoiceDetailRepository.SaveInvoiceDetail(invoiceModel);
                invoice.Invoice = invoiceModel.InvoiceDetailId;
                response.Ok(invoice, "Purchase detail saved correctly");
            }
            catch (Exception ex)
            {
                Logger.ErrorFatal(ex);
                response.Error(ex);
            }
            return response;
        }

        public InvoiceDetailResponseList GetInvoiceDetailFromByInvoiceId(int invoiceId)
        {
            var response = new InvoiceDetailResponseList();

            try
            {
                var invoiceDetail = _unitOfWork.InvoiceDetailRepository.GetList(new { InvoiceId = invoiceId });

                var invoiceDetailResponse = Mapper.Map<List<InvoiceDetailModelView>>(invoiceDetail);
                response.Ok(invoiceDetailResponse);
            }
            catch (Exception ex)
            {
                Logger.ErrorFatal(ex);
                response.Error(ex);
            }
            return response;
        }

        public ResponseData<int> DeleteInvoiceDetail(int invoiceDetailId)
        {
            var response = new ResponseData<int>();

            try
            {
                var rowsAffected = _unitOfWork.InvoiceDetailRepository.DeleteInvoiceDetail(invoiceDetailId);
                response.Ok(rowsAffected, "Detail successfully removed");
            }
            catch (Exception ex)
            {
                Logger.ErrorFatal(ex);
                response.Error(ex);
            }
            return response;
        }
    }

    public interface IInvoiceDetailServices
    {
        InvoiceDetailResponse SaveInvoiceDetail(InvoiceDetailModelView invoice);

        InvoiceDetailResponseList GetInvoiceDetailFromByInvoiceId(int invoiceId);

        ResponseData<int> DeleteInvoiceDetail(int invoiceDetailId);
    }
}