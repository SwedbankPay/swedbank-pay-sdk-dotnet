using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SwishSaleListItem : ISwishSaleListItem
    {
        public SwishSaleListItem(DateTime date,
                            string paymentRequestToken,
                            string payerAlias,
                            string swishPaymentReference,
                            string swishStatus,
                            Uri id,
                            ITransaction transaction)
        {
            Date = date;
            PaymentRequestToken = paymentRequestToken;
            PayerAlias = payerAlias;
            SwishPaymentReference = swishPaymentReference;
            SwishStatus = swishStatus;
            Id = id;
            Transaction = transaction;
        }


        public DateTime Date { get; }

        /// <summary>
        /// A unique <seealso cref="Uri"/> to access this sale item.
        /// </summary>
        public Uri Id { get; }
        public string PayerAlias { get; }
        public string PaymentRequestToken { get; }
        public string SwishPaymentReference { get; }
        public string SwishStatus { get; }

        /// <summary>
        /// Detailed information about this transaction.
        /// </summary>
        public ITransaction Transaction { get; }
    }
}