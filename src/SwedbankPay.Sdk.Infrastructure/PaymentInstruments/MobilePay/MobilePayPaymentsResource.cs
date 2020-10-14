using SwedbankPay.Sdk.Extensions;
using SwedbankPay.Sdk.Payments.MobilePayPayments;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments
{
    public class MobilePayPaymentsResource : ResourceBase, IMobilePayResource
    {
        public MobilePayPaymentsResource(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<IMobilePayPayment> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            Uri url = id.GetUrlWithQueryString(paymentExpand);

            var mobilepaymentResponseDto = await HttpClient.GetAsJsonAsync<MobilePayPaymentResponseDto>(url);
            return new MobilePayPayment(mobilepaymentResponseDto);
        }

        public async Task<IMobilePayPayment> Create(MobilePayPaymentRequest paymentRequest,
                                                            PaymentExpand paymentExpand = PaymentExpand.None)
        {
            var url = new Uri($"/psp/mobilepay/payments{paymentExpand}", UriKind.Relative);

            var mobilepaymentResponseDto = await HttpClient.PostAsJsonAsync<MobilePayPaymentResponseDto>(url, paymentRequest);
            return new MobilePayPayment(mobilepaymentResponseDto);
        }
    }
}
