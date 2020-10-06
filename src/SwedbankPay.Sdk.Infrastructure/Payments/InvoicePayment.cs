using SwedbankPay.Sdk.Extensions;
using Swedbankpay.Sdk.Payments.InvoicePayments;
using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public class InvoicePayment
    {
        private InvoicePayment(InvoicePaymentResponse paymentResponse, HttpClient client)
        {
            PaymentResponse = paymentResponse.Payment;
            var operations = new InvoicePaymentOperations(paymentResponse.Operations, client);
            Operations = operations;
        }

        public InvoicePaymentOperations Operations { get; }

        public PaymentResponseObject PaymentResponse { get; }


        internal static async Task<InvoicePayment> Create(InvoicePaymentRequest paymentRequest,
                                                   HttpClient client,
                                                   string paymentExpand)
        {
            var url = new Uri($"/psp/invoice/payments{paymentExpand}", UriKind.Relative);

            var paymentResponse = await client.PostAsJsonAsync<InvoicePaymentResponse>(url, paymentRequest);
            return new InvoicePayment(paymentResponse, client);
        }


        internal static async Task<InvoicePayment> Get(Uri id, HttpClient client, string paymentExpand)
        {
            var url = !string.IsNullOrWhiteSpace(paymentExpand)
                ? new Uri(id.OriginalString + paymentExpand, UriKind.RelativeOrAbsolute)
                : id;

            var paymentResponseContainer = await client.GetAsJsonAsync<InvoicePaymentResponse>(url);
            return new InvoicePayment(paymentResponseContainer, client);
        }
    }
}