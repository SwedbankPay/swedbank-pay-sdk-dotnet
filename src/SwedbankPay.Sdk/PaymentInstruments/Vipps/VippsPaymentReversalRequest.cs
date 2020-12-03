namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    /// <summary>
    /// API request details for reversing a Vipps payment.
    /// </summary>
    public class VippsPaymentReversalRequest
    {
        /// <summary>
        /// Instantiates a <see cref="VippsPaymentReversalRequest"/> with the provided parameters.
        /// </summary>
        /// <param name="amount">The amount to reverse back to the payer.</param>
        /// <param name="vatAmount">The amount of VAT to reverse back.</param>
        /// <param name="description">A textual description of the reversal.</param>
        /// <param name="payeeReference">Transactionally unique reference from the merchant system.</param>
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
