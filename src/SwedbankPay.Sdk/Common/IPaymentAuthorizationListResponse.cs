using System.Collections.Generic;

namespace SwedbankPay.Sdk.Common
{
    public interface IPaymentAuthorizationListResponse
    {
        List<IPaymentAuthorization> AuthorizationList { get; }
    }
}