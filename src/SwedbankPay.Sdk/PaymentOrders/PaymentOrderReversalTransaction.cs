using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    /// Reverses captured funds back to the payer.
    /// </summary>
    public class PaymentOrderReversalTransaction
    {
        /// <summary>
        /// Instantaites a <see cref="PaymentOrderReversalTransaction"/> with the provided parameters.
        /// </summary>
        /// <param name="amount">The amount to refund to the payer.</param>
        /// <param name="vatAmount">The amount of VAT to refund.</param>
        /// <param name="description">Textual description of the reversal.</param>
        /// <param name="payeeReference">Unique ID set by the merchant for this transaction.</param>
        protected internal PaymentOrderReversalTransaction(Amount amount,
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
        /// The <seealso cref="Sdk.Amount"/> that is being reversed to the payer.
        /// </summary>
        public Amount Amount { get; }

        /// <summary>
        /// A human readable reason for the description.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// The <seealso cref="OrderItem"/>s involved in the reversal.
        /// </summary>
        public List<OrderItem> OrderItems { get; } = new List<OrderItem>();

        /// <summary>
        /// A unique reference from the merchant system.
        /// It is set per operation to ensure an exactly-once delivery of a transactional operation.
        /// </summary>
        public string PayeeReference { get; }

        /// <summary>
        /// The amount in the reversal being value added taxes.
        /// </summary>
        public Amount VatAmount { get; }
    }
}