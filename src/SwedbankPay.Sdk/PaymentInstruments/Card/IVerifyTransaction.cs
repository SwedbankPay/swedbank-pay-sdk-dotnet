using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// Transaction for a verified payment.
    /// </summary>
    public interface IVerifyTransaction: ITransaction
    {
        /// <summary>
        /// Activities resource.
        /// </summary>
        Uri Activities { get; }
    }
}