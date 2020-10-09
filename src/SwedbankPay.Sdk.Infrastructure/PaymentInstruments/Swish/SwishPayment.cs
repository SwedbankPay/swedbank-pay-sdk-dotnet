using SwedbankPay.Sdk.Extensions;
using SwedbankPay.Sdk.Payments.SwishPayments;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments
{
    public class SwishPayment : ISwishPayment
    {
        private SwishPayment(SwishPaymentResponse paymentResponse, HttpClient client)
        {
            PaymentResponse = paymentResponse.Payment;
            var operations = new SwishPaymentOperations(paymentResponse.Operations, client);
            Operations = operations;
        }


        public ISwishPaymentOperations Operations { get; }

        public SwishPaymentResponseObject PaymentResponse { get; }


        internal static async Task<ISwishPayment> Create(SwishPaymentRequest paymentRequest,
                                                   HttpClient client,
                                                   string paymentExpand)
        {
            var url = new Uri($"/psp/swish/payments{paymentExpand}", UriKind.Relative);

            var paymentResponse = await client.PostAsJsonAsync<SwishPaymentResponse>(url, paymentRequest);
            return new SwishPayment(paymentResponse, client);
        }


        internal static async Task<ISwishPayment> Get(Uri id, HttpClient client, string paymentExpand)
        {
            var url = !string.IsNullOrWhiteSpace(paymentExpand)
                ? new Uri(id.OriginalString + paymentExpand, UriKind.RelativeOrAbsolute)
                : id;

            var paymentResponse = await client.GetAsJsonAsync<SwishPaymentResponse>(url);
            return new SwishPayment(paymentResponse, client);
        }
    }
}