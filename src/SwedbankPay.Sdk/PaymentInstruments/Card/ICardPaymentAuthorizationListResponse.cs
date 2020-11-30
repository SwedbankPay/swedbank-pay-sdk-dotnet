using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// Holds a list of <seealso cref="IPaymentAuthorization"/> if available when
    /// doing a GET on the <see cref="Id"/>.
    /// </summary>
    public interface ICardPaymentAuthorizationListResponse
    {
        /// <summary>
        /// The ID of this authorization list.
        /// </summary>
        public Uri Id { get; }

        /// <summary>
        /// List of avaialbe <see cref="IPaymentAuthorization"/> on the current payment.
        /// </summary>
        List<IPaymentAuthorization> AuthorizationList { get; }
    }
}