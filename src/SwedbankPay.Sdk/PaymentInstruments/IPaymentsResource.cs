using SwedbankPay.Sdk.Payments.CardPayments;
using SwedbankPay.Sdk.Payments.SwishPayments;
using SwedbankPay.Sdk.Payments.InvoicePayments;
using SwedbankPay.Sdk.Payments.VippsPayments;
using SwedbankPay.Sdk.Payments.MobilePayPayments;
using SwedbankPay.Sdk.Payments.TrustlyPayments;

namespace SwedbankPay.Sdk.Payments
{
    public interface IPaymentsResource
    {
        ICardResource CardPayments { get; }
        ISwishPaymentsResource SwishPayments { get; }
        IInvoicePaymentsResource InvoicePayments { get; }
        IVippsPaymentsResource VippsPayments { get; }
        IMobilePayPaymentsResource MobilePayPayments { get; }
        ITrustlyPaymentsResource TrustlyPayments { get; }


    }
}