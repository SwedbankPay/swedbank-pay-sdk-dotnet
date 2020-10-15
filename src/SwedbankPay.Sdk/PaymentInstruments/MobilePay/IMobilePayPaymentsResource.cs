using System;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    public interface IMobilePayResource
    {
        Task<IMobilePayPaymentResponse> Create(MobilePayPaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None);

        Task<IMobilePayPaymentResponse> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None);
    }
}
