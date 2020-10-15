namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public interface ISwishPaymentResponse
    {
        ISwishPaymentOperations Operations { get; }
        ISwishPayment Payment { get; }
    }
}