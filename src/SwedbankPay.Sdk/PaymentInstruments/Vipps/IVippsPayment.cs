namespace SwedbankPay.Sdk.Payments.VippsPayments
{
    public interface IVippsPayment
    {
        IVippsPaymentOperations Operations { get; }
        PaymentResponseObject PaymentResponse { get; }
    }
}