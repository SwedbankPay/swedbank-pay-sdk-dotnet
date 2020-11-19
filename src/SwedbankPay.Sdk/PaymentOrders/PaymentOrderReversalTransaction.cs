using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderReversalTransaction
    {
        protected internal PaymentOrderReversalTransaction(Amount amount,
                                               Amount vatAmount,
                                               List<OrderItem> orderItems,
                                               string description,
                                               string payeeReference)
        {
            Amount = amount;
            VatAmount = vatAmount;
            OrderItems = orderItems;
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
        public List<OrderItem> OrderItems { get; }

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