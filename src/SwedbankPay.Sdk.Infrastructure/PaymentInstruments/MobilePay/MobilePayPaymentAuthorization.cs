using System;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay;

internal class MobilePayPaymentAuthorization : Identifiable, IMobilePayPaymentAuthorization
{
    public MobilePayPaymentAuthorization(Uri id, MobilePayPaymentAuthorizationDto dto)
        : base(id)
    {
        MaskedPan = dto.MaskedPan;
        ExpiryDate = dto.ExpiryDate;
        PanToken = dto.PanToken;
        CardBrand = dto.CardBrand;
        CardType = dto.CardType;
        CountryCode = dto.CountryCode;
        AcquirerTransactionType = dto.AcquirerTransactionType;
        AcquirerStan = dto.AcquirerStan;
        AcquirerTerminalId = dto.AcquirerTerminalId;
        AcquirerTransactionTime = dto.AcquirerTransactionTime;
        Transaction = dto.Transaction.Map();
    }

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
    public IAuthorizationTransaction Transaction { get; }
}