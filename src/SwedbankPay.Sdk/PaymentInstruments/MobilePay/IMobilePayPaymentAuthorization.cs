using System;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    public interface IMobilePayPaymentAuthorization
    {
        string AcquirerStan { get; }
        string AcquirerTerminalId { get; }
        DateTime AcquirerTransactionTime { get; }
        string AcquirerTransactionType { get; }
        string CardBrand { get; }
        string CardType { get; }
        string CountryCode { get; }
        string ExpiryDate { get; }
        string MaskedPan { get; }
        string PanToken { get; }
        MobilePayPaymentAuthorizationTransaction Transaction { get; }
    }
}