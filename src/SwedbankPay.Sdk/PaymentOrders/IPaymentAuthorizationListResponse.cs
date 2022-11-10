using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders;

internal interface IPaymentAuthorizationListResponse
{
    /// <summary>
    /// A unique <seealso cref="Uri"/> to access this authorization list.
    /// </summary>
    public Uri Id { get; }

    /// <summary>
    /// Contains all currently available payment authorizations.
    /// </summary>
    public IList<IPaymentAuthorization> AuthorizationList { get; }
}