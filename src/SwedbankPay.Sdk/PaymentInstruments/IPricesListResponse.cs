using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    /// <summary>
    /// Resource for getting the list of <seealso cref="IPrice"/> available on a payment.
    /// </summary>
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