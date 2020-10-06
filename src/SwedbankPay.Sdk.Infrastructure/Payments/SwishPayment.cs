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
            var operations = new SwishPaymentOperations(paymentResponse.Operations, client);
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