using SwedbankPay.Sdk.PaymentInstruments.Card;
using SwedbankPay.Sdk.PaymentInstruments.Invoice;
using SwedbankPay.Sdk.PaymentInstruments.MobilePay;
using SwedbankPay.Sdk.PaymentInstruments.Swish;
using SwedbankPay.Sdk.PaymentInstruments.Trustly;
using SwedbankPay.Sdk.PaymentInstruments.Vipps;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public interface IPaymentsResource
    {
        ICardResource CardPayments { get; }
        ISwishResource SwishPayments { get; }
        IInvoiceResource InvoicePayments { get; }
        IVippsResource VippsPayments { get; }
        IMobilePayResource MobilePayPayments { get; }
        ITrustlyResource TrustlyPayments { get; }


    }
}