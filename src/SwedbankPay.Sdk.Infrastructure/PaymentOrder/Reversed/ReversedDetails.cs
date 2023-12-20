using System.Globalization;

using SwedbankPay.Sdk.PaymentOrder.Reversed;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Reversed;

internal record ReversedDetails : IReversedDetails
{
    public string? NonPaymentToken { get; }
    public string? ExternalNonPaymentToken { get; }
    public string? PaymentAccountReference { get; }
    public string? CardBrand { get; }
    public string? CardType { get; }
    public string? MaskedPan { get; }
    public string? MaskedDPan { get; }
    public string? ExpiryDate { get; }
    public string? IssuerAuthorizationApprovalCode { get; }
    public string? AcquirerTransactionType { get; }
    public string? AcquirerStan { get; }
    public string? AcquirerTerminalId { get; }
    public DateTime? AcquirerTransactionTime { get; }
    public string? TransactionInitiator { get; }
    public string? Bin { get; }
    public string? Msisdn { get; }
    
    public ReversedDetails(ReversedDetailsDto dto)
    {
        NonPaymentToken = dto.NonPaymentToken;
        ExternalNonPaymentToken = dto.ExternalNonPaymentToken;
        PaymentAccountReference = dto.PaymentAccountReference;
        CardBrand = dto.CardBrand;
        CardType = dto.CardType;
        MaskedPan = dto.MaskedPan;
        MaskedDPan = dto.MaskedDPan;
        ExpiryDate = dto.ExpiryDate;
        IssuerAuthorizationApprovalCode = dto.IssuerAuthorizationApprovalCode;
        AcquirerTransactionType = dto.AcquirerTransactionType;
        AcquirerStan = dto.AcquirerStan;
        AcquirerTerminalId = dto.AcquirerTerminalId;
        AcquirerTransactionTime = dto.AcquirerTransactionTime;
        TransactionInitiator = dto.TransactionInitiator;
        Bin = dto.Bin;
        Msisdn = dto.Msisdn;
    }
}