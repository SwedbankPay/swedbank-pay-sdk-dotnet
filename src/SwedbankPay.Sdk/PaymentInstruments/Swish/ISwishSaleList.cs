using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    /// <summary>
    /// Resource to retreive and inspect sale items for Swish.
    /// </summary>
    public interface ISwishSaleList : IIdentifiable
    {
        /// <summary>
        /// A list of Swish sale list items.
        /// </summary>
        public IList<ISwishSaleListItem> SaleList { get; }
    }
}