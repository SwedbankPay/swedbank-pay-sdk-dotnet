using System.Collections.Generic;

namespace SwedbankPay.Sdk
{
    public interface IPaymentAuthorizationListResponse
    {
        List<IPaymentAuthorization> AuthorizationList { get; }
    }
}