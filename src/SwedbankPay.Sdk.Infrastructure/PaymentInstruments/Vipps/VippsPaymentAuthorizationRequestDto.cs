namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    internal class VippsPaymentAuthorizationRequestDto
    {
        public VippsPaymentAuthorizationRequestDto(VippsPaymentAuthorizationRequest payload)
        {
            Transaction = new VippsAuthorizationTransactionDto(payload.Transaction);
        }

        public VippsAuthorizationTransactionDto Transaction { get; }
    }
}