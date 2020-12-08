using SwedbankPay.Sdk.Extensions;
using SwedbankPay.Sdk.PaymentOrders;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    internal class SwishPaymentOperations : OperationsBase, ISwishPaymentOperations
    {
        public SwishPaymentOperations(IOperationList operations, HttpClient client)
        {
            foreach (var httpOperation in operations)
            {
                switch (httpOperation.Rel.Value)
                {
                    case PaymentResourceOperations.UpdatePaymentAbort:
                        Abort = async payload => {
                            var payloadDto = new PaymentAbortRequestDto(payload);
                            var dto = await client.SendAsJsonAsync<SwishPaymentResponseDto>(httpOperation.Method, httpOperation.Href, payloadDto);
                            return new SwishPaymentResponse(dto, client);
                        };
                        break;

                    case PaymentResourceOperations.CreateSale:
                        Sale = async payload => {
                            var payloadDto = new SwishPaymentSaleRequestDto(payload);
                            var dto = await client.SendAsJsonAsync<SwishPaymentSaleResponseDto>(httpOperation.Method, httpOperation.Href, payloadDto);
                            return new SwishPaymentSaleResponse(dto.Payment, dto.Sale.Map());
                        };
                        break;
                    case PaymentResourceOperations.RedirectSale:
                        RedirectSale = httpOperation;
                        break;

                    case PaymentResourceOperations.ViewSales:
                        ViewSales = httpOperation;
                        break;
                    case PaymentResourceOperations.CreateReversal:
                        Reverse = async payload => {
                            var payloadDto = new SwishPaymentReversalRequestDto(payload);
                            var dto = await client.SendAsJsonAsync<ReversalResponseDto>(httpOperation.Method, httpOperation.Href, payloadDto);
                            return new ReversalResponse(dto.Payment, dto.Reversal.Map());
                        };
                        break;
                    case PaymentResourceOperations.PaidPayment:
                        PaidPayment = httpOperation;
                        break;
                }
                Add(httpOperation.Rel, httpOperation);
            }
        }

        public Func<PaymentAbortRequest, Task<ISwishPaymentResponse>> Abort { get; }
        public Func<SwishPaymentReversalRequest, Task<IReversalResponse>> Reverse { get; }
        public Func<SwishPaymentSaleRequest, Task<ISwishPaymentSaleResponse>> Sale { get; }
        public HttpOperation PaidPayment { get; }
        public HttpOperation RedirectSale { get; }
        public HttpOperation ViewSales { get; }
    }
}