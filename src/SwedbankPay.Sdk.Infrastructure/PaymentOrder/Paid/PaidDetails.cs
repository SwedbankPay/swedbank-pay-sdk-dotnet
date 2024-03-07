using SwedbankPay.Sdk.PaymentOrder.Paid;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Paid;

internal record PaidDetails : IPaidDetails
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
    public Msisdn? Msisdn { get; }

    internal PaidDetails(PaidDetailsDto dto)
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
        
        if (!string.IsNullOrWhiteSpace(dto.Msisdn))
        {
            Msisdn = new Msisdn(dto.Msisdn!);
        }
    }
}