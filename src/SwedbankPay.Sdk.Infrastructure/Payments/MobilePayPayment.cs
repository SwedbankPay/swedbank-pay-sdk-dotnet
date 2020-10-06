using Swedbankpay.Sdk.Payments;
using SwedbankPay.Sdk.Extensions;
using SwedbankPay.Sdk.Payments.MobilePayPayments;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments
{
    public class MobilePayPayment : IMobilePayPayment
    {
        private MobilePayPayment(MobilePayPaymentResponse paymentResponse, HttpClient client)
        {
            PaymentResponse = paymentResponse.Payment;
            var operations = new MobilePayPaymentOperations(paymentResponse.Operations, client);
            Operations = operations;
        }

        public IMobilePayPaymentOperations Operations { get; }

        public MobilePayPaymentResponseObject PaymentResponse { get; }


        internal static async Task<IMobilePayPayment> Create(MobilePayPaymentRequest paymentRequest,
                                                   HttpClient client,
                                                   string paymentExpand)
        {
            var url = new Uri($"/psp/mobilepay/payments{paymentExpand}", UriKind.Relative);

            var paymentResponse = await client.PostAsJsonAsync<MobilePayPaymentResponse>(url, paymentRequest);
            return new MobilePayPayment(paymentResponse, client);
        }


        internal static async Task<IMobilePayPayment> Get(Uri id, HttpClient client, string paymentExpand)
        {
            var url = !string.IsNullOrWhiteSpace(paymentExpand)
                ? new Uri(id.OriginalString + paymentExpand, UriKind.RelativeOrAbsolute)
                : id;

            var paymentResponseContainer = await client.GetAsJsonAsync<MobilePayPaymentResponse>(url);
            return new MobilePayPayment(paymentResponseContainer, client);
        }
    }
}