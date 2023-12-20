namespace SwedbankPay.Sdk.PaymentOrder.Paid;

public interface IPaidDetails
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
    public string? AcquirerTransactionTime { get; }
    public string? TransactionInitiator { get; }
    public string? Bin { get; }
    public string? Msisdn { get; }
}