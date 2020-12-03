using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    internal class VippsPaymentAuthorizationDto
    {
        public Uri Id { get; set; }
        public string VippsTransactionId { get; set; }
        public string MobileNumber { get; set; }
        public VippsPaymentAuthorizationTransactionDto Transaction { get; set; }

        internal IVippsPaymentAuthorization Map()
        {
            return new VippsPaymentAuthorization(Id, VippsTransactionId, MobileNumber, Transaction.Map());
        }
    }
}