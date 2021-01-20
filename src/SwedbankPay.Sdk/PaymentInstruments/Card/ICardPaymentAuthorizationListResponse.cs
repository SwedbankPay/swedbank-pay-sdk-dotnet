using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// Holds a list of <seealso cref="IPaymentAuthorization"/> if available when
    /// doing a GET on the <see cref="IIdentifiable.Id"/>.
    /// </summary>
    public interface ICardPaymentAuthorizationListResponse : IIdentifiable
    {
        /// <summary>
        /// List of avaialbe <see cref="IPaymentAuthorization"/> on the current payment.
        /// </summary>
        IList<IPaymentAuthorization> AuthorizationList { get; }
    }
}