using System;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class CancellationResponse : ICancellationResponse
    {
        public CancellationResponse(Uri payment, ITransactionResponse cancellation)
        {
            Payment = payment;
            Cancellation = cancellation;
        }

        /// <summary>
        /// A unique <seealso cref="Uri"/> to access this resource.
        /// </summary>
        public Uri Payment { get; }

        /// <summary>
        /// Holds transactional information about this cancellation.
        /// </summary>
        public ITransactionResponse Cancellation { get; }
    }
}