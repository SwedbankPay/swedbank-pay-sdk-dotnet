using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// Transactional details about a card payment being captured.
    /// </summary>
    public class CardPaymentCaptureTransaction
    {
        /// <summary>
        /// Instantiates a new <see cref="CardPaymentCaptureTransaction"/> with the provided parameters.
        /// </summary>
        /// <param name="amount">The <see cref="Sdk.Amount"/> to capture.</param>
        /// <param name="vatAmount">The <see cref="Sdk.Amount"/> to capture as VAT.</param>
        /// <param name="description">A textual description of the purchase.</param>
        /// <param name="payeeReference">A unique payee refrence for the capture.</param>
        protected internal CardPaymentCaptureTransaction(Amount amount,
                                                Amount vatAmount,
                                                string description,
                                                string payeeReference)
        {
            Amount = amount;
            VatAmount = vatAmount;
            Description = description;
            PayeeReference = payeeReference;
        }

        /// <summary>
        /// The amount (including VAT, if any) to charge the payer,
        /// entered in the lowest monetary unit of the selected currency.
        /// </summary>
        public Amount Amount { get; }

        /// <summary>
        /// A 40 character length textual description of the purchase.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// List of <seealso cref="IOrderItem"/> that is being captured.
        /// Only required if payment was authorizied with the OrderItems field.
        /// </summary>
        public IList<IOrderItem> OrderItems { get; } = new List<IOrderItem>();

        /// <summary>
        /// A unique reference from the merchant system.
        /// It is set per operation to ensure an exactly-once delivery of a transactional operation.
        /// </summary>
        public string PayeeReference { get; }

        /// <summary>
        /// The payment’s VAT (Value Added Tax) amount, entered in the lowest monetary unit of the selected currency.
        /// The vatAmount entered will not affect the amount shown on the payment page, which only shows the total amount.
        /// This field is used to specify how much ofthe total amount the VAT will be.
        /// Set to 0 (zero) if there is no VAT amount charged.
        /// </summary>
        public Amount VatAmount { get; }
    }
}