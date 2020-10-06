using swedbankpay.Sdk.Payments.VippsPayments;
using SwedbankPay.Sdk.Extensions;
using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace SwedbankPay.Sdk.Payments.VippsPayments
{
    public class VippsPayment
    {
        private VippsPayment(VippsPaymentResponse paymentResponse, HttpClient client)
        {
            PaymentResponse = paymentResponse.Payment;
            var operations = new VippsPaymentOperations(paymentResponse.Operations, client);
            Operations = operations;
        }

        public VippsPaymentOperations Operations { get; }

        public PaymentResponseObject PaymentResponse { get; }


        internal static async Task<VippsPayment> Create(VippsPaymentRequest paymentRequest,
                                                   HttpClient client,
                                                   string paymentExpand)
        {
            var url = new Uri($"/psp/vipps/payments{paymentExpand}", UriKind.Relative);

            var paymentResponse = await client.PostAsJsonAsync<VippsPaymentResponse>(url, paymentRequest);
            return new VippsPayment(paymentResponse, client);
        }


        internal static async Task<VippsPayment> Get(Uri id, HttpClient client, string paymentExpand)
        {
            var url = !string.IsNullOrWhiteSpace(paymentExpand)
                ? new Uri(id.OriginalString + paymentExpand, UriKind.RelativeOrAbsolute)
                : id;

            var paymentResponseContainer = await client.GetAsJsonAsync<VippsPaymentResponse>(url);
            return new VippsPayment(paymentResponseContainer, client);
        }
    }
}