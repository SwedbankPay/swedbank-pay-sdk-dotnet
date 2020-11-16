using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public interface ISwishSaleListItem
    {
        /// <summary>
        /// The relative URI and unique identifier of the sales resource this sales payment belongs to.
        /// </summary>
        public Uri Id { get; }
        public DateTime Date { get; }
        public string PayerAlias { get; }
        public string PaymentRequestToken { get; }
        public string SwishPaymentReference { get; }
        public string SwishStatus { get; }

        /// <summary>
        /// The current sales transaction for this sale item.
        /// </summary>
        public ITransaction Transaction { get; }
    }
}