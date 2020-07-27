using SwedbankPay.Sdk.Extensions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardVerify
    {

        public CardVerify(CardPaymentVerifyResponse verifyResponse, HttpClient client)
        {
            VerifyResponse = verifyResponse.Payment;
            var operations = new CardPaymentOperations(verifyResponse.Operations, client);
            Operations = operations;
        }


        public CardPaymentOperations Operations { get; }

        public PaymentVerifyResponseObject VerifyResponse { get; }


        internal static async Task<CardVerify> Get(Uri id, HttpClient client, string paymentExpand)
        {
            var url = !string.IsNullOrWhiteSpace(paymentExpand)
                ? new Uri(id.OriginalString + paymentExpand, UriKind.RelativeOrAbsolute)
                : id;

            var paymentResponseContainer = await client.GetAsJsonAsync<CardPaymentVerifyResponse>(url);
            return new CardVerify(paymentResponseContainer, client);
        }



        internal static async Task<CardVerify> Verify(CardPaymentVerifyRequest paymentVerifyRequest,
                                                    HttpClient client,
                                                    string paymentExpand)
        {
            var url = new Uri($"/psp/creditcard/payments{paymentExpand}", UriKind.Relative);

            var paymentVerifyResponse = await client.PostAsJsonAsync<CardPaymentVerifyResponse>(url, paymentVerifyRequest);
            return new CardVerify(paymentVerifyResponse, client);
        }
    }
}

