using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public interface IPricesListResponse
    {
        /// <summary>
        /// The unique id for this price resource.
        /// </summary>
        public Uri Id { get; }

        /// <summary>
        /// A list of <see cref="IPrice"/> giving details about amounts and types.
        /// </summary>
        List<IPrice> PriceList { get; }
    }
}