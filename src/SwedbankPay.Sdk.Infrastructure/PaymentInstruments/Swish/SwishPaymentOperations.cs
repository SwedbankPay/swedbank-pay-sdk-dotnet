using SwedbankPay.Sdk.Extensions;
using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SwishPaymentOperations : OperationsBase, ISwishPaymentOperations
    {
        public SwishPaymentOperations(IOperationList operations, HttpClient client)
        {
            foreach (var httpOperation in operations)
            {
                switch (httpOperation.Rel.Value)
                {
                    case PaymentResourceOperations.UpdatePaymentAbort:
                        Abort = async payload =>
                            await client.SendAsJsonAsync<SwishPaymentResponse>(httpOperation.Method, httpOperation.Href, payload);
                        break;

                    case PaymentResourceOperations.CreateSale:
                        Sale = async payload =>
                            await client.SendAsJsonAsync<SwishPaymentSaleResponse>(httpOperation.Method, httpOperation.Href, payload);
                        break;
                    case PaymentResourceOperations.RedirectSale:
                        RedirectSale = httpOperation;
                        break;

                    case PaymentResourceOperations.ViewSales:
                        ViewSales = httpOperation;
                        break;
                    case PaymentResourceOperations.CreateReversal:
                        Reverse = async payload =>
                            await client.SendAsJsonAsync<ReversalResponse>(httpOperation.Method, httpOperation.Href, payload);
                        break;
                    case PaymentResourceOperations.PaidPayment:
                        PaidPayment = httpOperation;
                        break;
                }
                Add(httpOperation.Rel, httpOperation);
            }
        }

        public Func<PaymentAbortRequest, Task<ISwishPaymentResponse>> Abort { get; }
        public Func<SwishPaymentReversalRequest, Task<ReversalResponse>> Reverse { get; }
        public Func<SwishPaymentSaleRequest, Task<SwishPaymentSaleResponse>> Sale { get; }
        public HttpOperation PaidPayment { get; }
        public HttpOperation RedirectSale { get; }
        public HttpOperation ViewSales { get; }
    }
}