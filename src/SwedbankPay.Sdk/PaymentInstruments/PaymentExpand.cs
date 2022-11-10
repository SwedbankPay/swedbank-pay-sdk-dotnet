using System;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    /// <summary>
    /// Expands optional resources on a payment.
    /// </summary>
    [Flags]
    public enum PaymentExpand
    {
        /// <summary>
        /// Don't expand any sub-resource.
        /// </summary>
        None = 0,
        /// <summary>
        /// Expand the Prices sub-resource.
        /// </summary>
        Prices = 1,
        /// <summary>
        /// Expand the PayeeInfo sub-resource.
        /// </summary>
        PayeeInfo = 2,
        /// <summary>
        /// Expand the Urls sub-resource.
        /// </summary>
        Urls = 4,
        /// <summary>
        /// Expand the Transactions sub-resource.
        /// </summary>
        Transactions = 8,
        /// <summary>
        /// Expand the Authorizations sub-resource.
        /// </summary>
        Authorizations = 16,
        /// <summary>
        /// Expand the Captures sub-resource.
        /// </summary>
        Captures = 32,
        /// <summary>
        /// Expand the Reversals sub-resource.
        /// </summary>
        Reversals = 64,
        /// <summary>
        /// Expand the Cancellations sub-resource.
        /// </summary>
        Cancellations = 128,
        /// <summary>
        /// Expand the Sales sub-resource.
        /// </summary>
        Sales = 256,
        /// <summary>
        /// Expand the MetaData sub-resource.
        /// </summary>
        Metadata = 512,
        /// <summary>
        /// Expand the Verifications sub-resource.
        /// </summary>
        Verifications = 1024,
        /// <summary>
        /// Expand all sub-resources.
        /// </summary>
        All = 2047
    }
}