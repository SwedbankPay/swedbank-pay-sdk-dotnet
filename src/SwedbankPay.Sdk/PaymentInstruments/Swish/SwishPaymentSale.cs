using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SwishPaymentSale : ISwishPaymentSale
    {
        public SwishPaymentSale(DateTime created, DateTime updated, string paymentRequestToken, Uri id, ITransaction transaction)
        {
            Created = created;
            Updated = updated;
            PaymentRequestToken = paymentRequestToken;
            Id = id;
            Transaction = transaction;
        }

        /// <summary>
        /// The <seealso cref="DateTime"/> this sale was created.
        /// </summary>
        public DateTime Created { get; }

        /// <summary>
        /// The <seealso cref="DateTime"/> this sale was last updated.
        /// </summary>
        public DateTime Updated { get; }

        /// <summary>
        /// The relative URI and unique identifier of the payment resource.
        /// </summary>
        public Uri Id { get; }
        public string PaymentRequestToken { get; }

        /// <summary>
        /// A summary of the sales transaction.
        /// </summary>
        public ITransaction Transaction { get; }
    }
}