namespace SwedbankPay.Sdk.PaymentOrder.Models;

internal record PaidDetailsDto
{
    public string? NonPaymentToken { get; set; }
    public string? ExternalNonPaymentToken { get; set; }
    public string? PaymentAccountReference { get; set; }
    public string? CardBrand { get; set; }
    public string? CardType { get; set; }
    public string? MaskedPan { get; set; }
    public string? MaskedDPan { get; set; }
    public string? ExpiryDate { get; set; }
    public string? IssuerAuthorizationApprovalCode { get; set; }
    public string? AcquirerTransactionType { get; set; }
    public string? AcquirerStan { get; set; }
    public string? AcquirerTerminalId { get; set; }
    public string? AcquirerTransactionTime { get; set; }
    public string? TransactionInitiator { get; set; }
    public string? Bin { get; set; }
    public string? Msisdn { get; set; }

    public PaidDetails Map()
    {
        return new PaidDetails(this);
    }
}