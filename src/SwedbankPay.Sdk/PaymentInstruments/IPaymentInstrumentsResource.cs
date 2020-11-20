using SwedbankPay.Sdk.PaymentInstruments.Card;
using SwedbankPay.Sdk.PaymentInstruments.Invoice;
using SwedbankPay.Sdk.PaymentInstruments.MobilePay;
using SwedbankPay.Sdk.PaymentInstruments.Swish;
using SwedbankPay.Sdk.PaymentInstruments.Trustly;
using SwedbankPay.Sdk.PaymentInstruments.Vipps;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public interface IPaymentInstrumentsResource
    {
        /// <summary>
        /// Used to gain access to credit card payments.
        /// </summary>
        ICardResource CardPayments { get; }

        /// <summary>
        /// Used to gain access to Swish payments.
        /// </summary>
        ISwishResource SwishPayments { get; }

        /// <summary>
        /// Used to gain access to SwedbankPay invoice payments.
        /// </summary>
        IInvoiceResource InvoicePayments { get; }

        /// <summary>
        /// Used to gain access to Vipps payments.
        /// </summary>
        IVippsResource VippsPayments { get; }

        /// <summary>
        /// Used to gain access to MobilePay Online payments.
        /// </summary>
        IMobilePayResource MobilePayPayments { get; }

        /// <summary>
        /// Used to gain access to Trustly payments.
        /// </summary>
        ITrustlyResource TrustlyPayments { get; }
    }
}