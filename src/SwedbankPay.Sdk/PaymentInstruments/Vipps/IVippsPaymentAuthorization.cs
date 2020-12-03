namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    /// <summary>
    /// Transactional details for a Vipps authorization.
    /// </summary>
    public interface IVippsPaymentAuthorization
    {
        /// <summary>
        /// Payers MSISDN.
        /// </summary>
        string MobileNumber { get; }

        /// <summary>
        /// Details on the current authorization transaction.
        /// </summary>
        AuthorizationTransaction Transaction { get; }

        /// <summary>
        /// ID to find this transaction in Vipps systems.
        /// </summary>
        string VippsTransactionId { get; }
    }
}