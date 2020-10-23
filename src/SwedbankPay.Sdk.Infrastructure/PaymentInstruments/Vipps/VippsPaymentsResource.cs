using SwedbankPay.Sdk.Common;
using SwedbankPay.Sdk.Extensions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    public class VippsPaymentsResource : ResourceBase, IVippsResource
    {
        public VippsPaymentsResource(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<IVippsPaymentReponse> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Uri url = id.GetUrlWithQueryString(paymentExpand);

            var paymentResponseContainer = await HttpClient.GetAsJsonAsync<VippsPaymentResponseDto>(url);
            return new VippsPaymentResponse(paymentResponseContainer, HttpClient);
        }

        public async Task<IVippsPaymentReponse> Create(VippsPaymentRequest paymentRequest,
                                                            PaymentExpand paymentExpand = PaymentExpand.None)
        {
            var url = new Uri("/psp/vipps/payments", UriKind.Relative).GetUrlWithQueryString(paymentExpand);

            var paymentResponse = await HttpClient.PostAsJsonAsync<VippsPaymentResponseDto>(url, paymentRequest);
            return new VippsPaymentResponse(paymentResponse, HttpClient);
        }
    }
}
