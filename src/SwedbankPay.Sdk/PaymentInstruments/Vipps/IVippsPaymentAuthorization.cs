namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    public interface IVippsPaymentAuthorization
    {
        string MobileNumber { get; }
        AuthorizationTransaction Transaction { get; }
        string VippsTransactionId { get; }
    }
}