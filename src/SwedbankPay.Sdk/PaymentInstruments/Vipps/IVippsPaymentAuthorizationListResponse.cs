using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    public interface IVippsPaymentAuthorizationListResponse
    {
        public Uri Id { get;  }
        public List<IVippsPaymentAuthorization> AuthorizationList { get; }
    }
}