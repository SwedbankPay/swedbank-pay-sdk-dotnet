namespace SwedbankPay.Sdk.PaymentInstruments.Trustly;

internal class TrustlyPaymentResponseDto
{
    public TrustlyPaymentDto Payment { get; set; }
    public OperationListDto Operations { get; set; }
}