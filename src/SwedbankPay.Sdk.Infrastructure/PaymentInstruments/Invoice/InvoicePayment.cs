using SwedbankPay.Sdk.Extensions;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using SwedbankPay.Sdk.Payments.InvoicePayments;
using Swedbankpay.Sdk.Payments;

namespace SwedbankPay.Sdk.Payments
{
    public class InvoicePayment : IInvoicePayment
    {
        private InvoicePayment(InvoicePaymentResponse paymentResponse, HttpClient client)
        {
            PaymentResponse = paymentResponse.Payment;
            var operations = new InvoicePaymentOperations(paymentResponse.Operations, client);
            Operations = operations;
        }

        public IInvoicePaymentOperations Operations { get; }

        public PaymentResponseObject PaymentResponse { get; }


        internal static async Task<IInvoicePayment> Create(InvoicePaymentRequest paymentRequest,
                                                   HttpClient client,
                                                   string paymentExpand)
        {
            var url = new Uri($"/psp/invoice/payments{paymentExpand}", UriKind.Relative);

            var paymentResponse = await client.PostAsJsonAsync<InvoicePaymentResponse>(url, paymentRequest);
            return new InvoicePayment(paymentResponse, client);
        }


        internal static async Task<IInvoicePayment> Get(Uri id, HttpClient client, string paymentExpand)
        {
            var url = !string.IsNullOrWhiteSpace(paymentExpand)
                ? new Uri(id.OriginalString + paymentExpand, UriKind.RelativeOrAbsolute)
                : id;

            var paymentResponseContainer = await client.GetAsJsonAsync<InvoicePaymentResponse>(url);
            return new InvoicePayment(paymentResponseContainer, client);
        }
    }
}