namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    public class VippsPaymentAuthorizationDto
    {
        public string VippsTransactionId { get; set; }
        public string MobileNumber { get; set; }
        public VippsPaymentAuthorizationTransactionDto Transaction { get; set; }

        internal IVippsPaymentAuthorization Map()
        {
            return new VippsPaymentAuthorization(VippsTransactionId, MobileNumber, Transaction.Map());
        }
    }
}