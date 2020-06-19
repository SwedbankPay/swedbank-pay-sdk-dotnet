using System;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments.MobilePayPayments
{
    public interface IMobilePayPaymentsResource
    {
        Task<MobilePayPayment> Create(MobilePayPaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None);

        Task<MobilePayPayment> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None);
    }
}
