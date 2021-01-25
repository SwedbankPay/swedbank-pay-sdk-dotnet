using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    internal class VippsPaymentAuthorizationDto
    {
        public string Id { get; set; }
        public string VippsTransactionId { get; set; }
        public string MobileNumber { get; set; }
        public VippsPaymentAuthorizationTransactionDto Transaction { get; set; }

        internal IVippsPaymentAuthorization Map()
        {
            var uri = new Uri(Id, UriKind.RelativeOrAbsolute);
            return new VippsPaymentAuthorization(uri, VippsTransactionId, MobileNumber, Transaction.Map());
        }
    }
}