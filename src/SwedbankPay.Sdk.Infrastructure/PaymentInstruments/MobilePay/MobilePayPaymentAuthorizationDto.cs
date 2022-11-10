using System;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay;

internal class MobilePayPaymentAuthorizationDto
{
    public string AcquirerStan { get; }
    public string AcquirerTerminalId { get; }
    public DateTime AcquirerTransactionTime { get; }
    public string AcquirerTransactionType { get; }
    public string CardBrand { get; }
    public string CardType { get; }
    public string CountryCode { get; }
    public string ExpiryDate { get; }
    public string MaskedPan { get; }
    public string PanToken { get; }
    public AuthorizationTransactionDto Transaction { get; }
}