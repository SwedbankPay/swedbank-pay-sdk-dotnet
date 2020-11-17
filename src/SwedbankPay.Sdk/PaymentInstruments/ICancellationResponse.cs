using System;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public interface ICancellationResponse
    {
        /// <summary>
        /// A unique <seealso cref="Uri"/> to access this cancellation resource.
        /// </summary>
        Uri Payment { get; }

        /// <summary>
        /// Transactional information about this cancellation.
        /// </summary>
        ITransactionResponse Cancellation { get; }
    }
}