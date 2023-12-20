using SwedbankPay.Sdk.PaymentOrder.Cancelled;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Cancelled;

internal record CancelledDetailsDto
{
    public string? NonPaymentToken { get; init; }
    public string? ExternalNonPaymentToken { get; init; }
    public string? PaymentAccountReference { get; init; }
    public string? CardBrand { get; init; }
    public string? CardType { get; init; }
    public string? MaskedPan { get; init; }
    public string? MaskedDPan { get; init; }
    public string? ExpiryDate { get; init; }
    public string? IssuerAuthorizationApprovalCode { get; init; }
    public string? AcquirerTransactionType { get; init; }
    public string? AcquirerStan { get; init; }
    public string? AcquirerTerminalId { get; init; }
    public DateTime? AcquirerTransactionTime { get; init; }
    public string? TransactionInitiator { get; init; }
    public string? Bin { get; init; }
    public string? Msisdn { get; init; }

    public ICancelledDetails Map()
    {
        return new CancelledDetails(this);
    }
}