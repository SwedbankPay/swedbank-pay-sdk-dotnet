using SwedbankPay.Sdk.PaymentInstruments.MobilePay;
using System;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments.MobilePayPayments
{
    public interface IMobilePayResource
    {
        Task<IMobilePayPaymentResponse> Create(MobilePayPaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None);

        Task<IMobilePayPaymentResponse> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None);
    }
}
