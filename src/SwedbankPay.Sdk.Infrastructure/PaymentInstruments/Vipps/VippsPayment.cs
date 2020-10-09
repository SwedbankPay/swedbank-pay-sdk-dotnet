using swedbankpay.Sdk.Payments;
using SwedbankPay.Sdk.Extensions;
using SwedbankPay.Sdk.Payments.VippsPayments;
using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace SwedbankPay.Sdk.Payments
{
    public class VippsPayment : IVippsPayment
    {
        private VippsPayment(VippsPaymentResponse paymentResponse, HttpClient client)
        {
            PaymentResponse = paymentResponse.Payment;
            var operations = new VippsPaymentOperations(paymentResponse.Operations, client);
            Operations = operations;
        }

        public IVippsPaymentOperations Operations { get; }

        public PaymentResponseObject PaymentResponse { get; }


        internal static async Task<IVippsPayment> Create(VippsPaymentRequest paymentRequest,
                                                   HttpClient client,
                                                   string paymentExpand)
        {
            var url = new Uri($"/psp/vipps/payments{paymentExpand}", UriKind.Relative);

            var paymentResponse = await client.PostAsJsonAsync<VippsPaymentResponse>(url, paymentRequest);
            return new VippsPayment(paymentResponse, client);
        }


        internal static async Task<IVippsPayment> Get(Uri id, HttpClient client, string paymentExpand)
        {
            var url = !string.IsNullOrWhiteSpace(paymentExpand)
                ? new Uri(id.OriginalString + paymentExpand, UriKind.RelativeOrAbsolute)
                : id;

            var paymentResponseContainer = await client.GetAsJsonAsync<VippsPaymentResponse>(url);
            return new VippsPayment(paymentResponseContainer, client);
        }
    }
}