using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    /// <summary>
    /// Object describing a Vipps authorization for a payment.
    /// </summary>
    public class VippsPaymentAuthorization : Identifiable, IVippsPaymentAuthorization
    {
        /// <summary>
        /// Instantiates a <see cref="VippsPaymentAuthorization"/> with the provided parameters.
        /// </summary>
        /// <param name="id">Unique ID for this authorization.</param>
        /// <param name="vippsTransactionId">The transaction ID found in Vipps systems.</param>
        /// <param name="mobileNumber">The payers MSISDN.</param>
        /// <param name="transaction">Authorization transaction details for this authorization.</param>
        public VippsPaymentAuthorization(
                             Uri id,
                             string vippsTransactionId,
                             string mobileNumber,
                             IAuthorizationTransaction transaction)
            : base(id)
        {
            VippsTransactionId = vippsTransactionId;
            MobileNumber = mobileNumber;
            Transaction = transaction;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string VippsTransactionId { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string MobileNumber { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IAuthorizationTransaction Transaction { get; }
    }
}