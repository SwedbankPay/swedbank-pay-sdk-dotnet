using SwedbankPay.Sdk.Extensions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments.SwishPayments
{
    public class SwishPayment
    {
        private SwishPayment(SwishPaymentPaymentResponse paymentResponse, HttpClient client)
        {
            PaymentResponse = paymentResponse.Payment;
            var operations = new SwishPaymentOperations();

            foreach (var httpOperation in paymentResponse.Operations)
            {
                operations.Add(httpOperation.Rel, httpOperation);

                switch (httpOperation.Rel.Value)
                {
                    case PaymentResourceOperations.UpdatePaymentAbort:
                        operations.Abort = async () =>
                            await client.SendAsJsonAsync<SwishPaymentPaymentResponse>(httpOperation.Method, httpOperation.Href, new PaymentAbortRequest());
                        break;

                    case PaymentResourceOperations.CreateSale:
                        operations.Sale = async payload =>
                            await client.SendAsJsonAsync<SwishPaymentSaleResponse>(httpOperation.Method, httpOperation.Href, payload);
                        break;
                    case PaymentResourceOperations.RedirectSale:
                        operations.RedirectSale = httpOperation;
                        break;

                    case PaymentResourceOperations.ViewSales:
                        operations.ViewSales = httpOperation;
                        break;
                    case PaymentResourceOperations.CreateReversal:
                        operations.Reverse = async payload =>
                            await client.SendAsJsonAsync<ReversalResponse>(httpOperation.Method, httpOperation.Href, payload);
                        break;
                    case PaymentResourceOperations.PaidPayment:
                        operations.PaidPayment = httpOperation;
                        break;
                }
            }

            Operations = operations;
        }


        public SwishPaymentOperations Operations { get; }

        public PaymentResponseObject PaymentResponse { get; }


        internal static async Task<SwishPayment> Create(SwishPaymentRequest paymentRequest,
                                                   HttpClient client,
                                                   string paymentExpand)
        {
            var url = new Uri($"/psp/swish/payments{paymentExpand}", UriKind.Relative);

            var paymentResponse = await client.PostAsJsonAsync<SwishPaymentPaymentResponse>(url, paymentRequest);
            return new SwishPayment(paymentResponse, client);
        }


        internal static async Task<SwishPayment> Get(Uri id, HttpClient client, string paymentExpand)
        {
            var url = !string.IsNullOrWhiteSpace(paymentExpand)
                ? new Uri(id.OriginalString + paymentExpand, UriKind.RelativeOrAbsolute)
                : id;

            var paymentResponse = await client.GetAsJsonAsync<SwishPaymentPaymentResponse>(url);
            return new SwishPayment(paymentResponse, client);
        }
    }
}