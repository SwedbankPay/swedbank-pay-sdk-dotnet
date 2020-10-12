using System;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments.MobilePayPayments
{
    public interface IMobileResource
    {
        Task<IMobilePayPayment> Create(MobilePayPaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None);

        Task<IMobilePayPayment> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None);
    }
}
