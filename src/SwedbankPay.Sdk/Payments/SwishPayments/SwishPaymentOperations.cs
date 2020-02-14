using SwedbankPay.Sdk.Extensions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments.SwishPayments
{
    public class SwishPaymentOperations : OperationsBase
    {
        public SwishPaymentOperations(OperationList operations, HttpClient client)
        {
            foreach (var httpOperation in operations)
            {
                switch (httpOperation.Rel.Value)
                {
                    case PaymentResourceOperations.Abort:
                        Abort = async () =>
                            await client.SendAsJsonAsync<SwishPaymentPaymentResponse>(httpOperation.Method, httpOperation.Href, new PaymentAbortRequest());
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
                this.Add(httpOperation.Rel, httpOperation);
            }
        }

        public Func<Task<SwishPaymentPaymentResponse>> Abort { get; }
        public Func<SwishPaymentReversalRequest, Task<ReversalResponse>> Reverse { get; }
        public Func<SwishPaymentSaleRequest, Task<SwishPaymentSaleResponse>> Sale { get; }
        public HttpOperation PaidPayment { get; internal set; }
        public HttpOperation RedirectSale { get; internal set; }
        public HttpOperation ViewSales { get; internal set; }
    }
}