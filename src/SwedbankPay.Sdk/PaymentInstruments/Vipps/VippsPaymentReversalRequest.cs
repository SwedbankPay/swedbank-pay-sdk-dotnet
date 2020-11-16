namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    public class VippsPaymentReversalRequest
    {
        public VippsPaymentReversalRequest(Amount amount, Amount vatAmount, string description, string payeeReference)
        {
            Transaction = new VippsReversalTransaction(amount, vatAmount, description, payeeReference);
        }

        /// <summary>
        /// Transactional details needed to reverse a Vipps payment.
        /// </summary>
        public VippsReversalTransaction Transaction { get; }
    }
}
