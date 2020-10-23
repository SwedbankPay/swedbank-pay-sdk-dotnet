using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    public interface IMobilePayPaymentAuthorizationListResponse
    {
        public List<IMobilePayPaymentAuthorization> AuthorizationList { get; }
    }
}