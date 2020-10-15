using SwedbankPay.Sdk.Extensions;
using SwedbankPay.Sdk.Payments.VippsPayments;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments
{
    public class VippsPaymentsResource : ResourceBase, IVippsResource
    {
        public VippsPaymentsResource(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<IVippsPayment> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            Uri url = id.GetUrlWithQueryString(paymentExpand);

            var paymentResponseContainer = await HttpClient.GetAsJsonAsync<VippsPaymentResponseDto>(url);
            return new VippsPayment(paymentResponseContainer);
        }

        public async Task<IVippsPayment> Create(VippsPaymentRequest paymentRequest,
                                                            PaymentExpand paymentExpand = PaymentExpand.None)
        {
            var url = new Uri($"/psp/vipps/payments{paymentExpand}", UriKind.Relative);

            var paymentResponse = await HttpClient.PostAsJsonAsync<VippsPaymentResponseDto>(url, paymentRequest);
            return new VippsPayment(paymentResponse);
        }
    }
}
