using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// Transaction for a verified payment.
    /// </summary>
    public interface IVerifyTransaction: ITransaction
    {
        /// <summary>
        /// Textual reason for failure if there is one.
        /// </summary>
        string FailedReason { get; }

        /// <summary>
        /// Textual reason for failure activity if there is one.
        /// </summary>
        string FailedActivityName { get; }

        /// <summary>
        /// Textual reason for failure code if there is one.
        /// </summary>
        string FailedErrorCode { get; }

        /// <summary>
        /// Textual description for failure if there is one.
        /// </summary>
        string FailedErrorDescription { get; }

        /// <summary>
        /// Activities resource.
        /// </summary>
        Uri Activities { get; }
    }
}