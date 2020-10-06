namespace SwedbankPay.Sdk.Payments.TrustlyPayments
{
    public interface ITrustlyPayment
    {
        ITrustlyPaymentOperations Operations { get; }
        TrustlyPaymentResponseObject PaymentResponse { get; }
    }
}