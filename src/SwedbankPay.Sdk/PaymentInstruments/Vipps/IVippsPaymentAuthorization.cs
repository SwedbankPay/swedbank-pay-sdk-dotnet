namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    public interface IVippsPaymentAuthorization
    {
        string MobileNumber { get; }
        /// <summary>
        /// Details on the current authorization transaction.
        /// </summary>
        AuthorizationTransaction Transaction { get; }
        string VippsTransactionId { get; }
    }
}