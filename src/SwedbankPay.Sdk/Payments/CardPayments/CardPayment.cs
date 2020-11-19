using SwedbankPay.Sdk.Extensions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPayment
    {
        private CardPayment(CardPaymentResponse paymentResponse, HttpClient client)
        {
            PaymentResponse = paymentResponse.Payment;
            var operations = new CardPaymentOperations(paymentResponse.Operations, client);
            Operations = operations;
        }


        public CardPaymentOperations Operations { get; }

        public PaymentResponseObject PaymentResponse { get; }


        internal static async Task<CardPayment> Create(CardPaymentRequest paymentRequest,
                                                   HttpClient client,
                                                   string paymentExpand)
        {
            var url = new Uri($"/psp/creditcard/payments{paymentExpand}", UriKind.Relative);

            var paymentResponse = await client.PostAsJsonAsync<CardPaymentResponse>(url, paymentRequest);
            return new CardPayment(paymentResponse, client);
        }


        internal static async Task<CardPayment> Create(CardPaymentRecurRequest paymentRequest,
                                                       HttpClient client,
                                                       string paymentExpand)
        {
            var url = new Uri($"/psp/creditcard/payments{paymentExpand}", UriKind.Relative);

            var paymentResponse = await client.PostAsJsonAsync<CardPaymentResponse>(url, paymentRequest);
            return new CardPayment(paymentResponse, client);
        }


        internal static async Task<CardPayment> Get(Uri id, HttpClient client, string paymentExpand)
        {
            var url = !string.IsNullOrWhiteSpace(paymentExpand)
                ? new Uri(id.OriginalString + paymentExpand, UriKind.RelativeOrAbsolute)
                : id;

            var paymentResponseContainer = await client.GetAsJsonAsync<CardPaymentResponse>(url);
            return new CardPayment(paymentResponseContainer, client);
        }
    }
}