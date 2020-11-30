using SwedbankPay.Sdk.PaymentOrders;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    /// <summary>
    /// Object for specifying what to capture on a payment.
    /// </summary>
    public class CaptureTransaction : ICaptureTransaction
    {
        /// <summary>
        /// Instantiates a new <see cref="CaptureTransaction"/> using the provided parameters.
        /// </summary>
        /// <param name="transactionActivity">The API operation to perform.</param>
        /// <param name="amount">The amount to capture in this transaction.</param>
        /// <param name="vatAmount">The VAT amount to capture in this transaction.</param>
        /// <param name="orderItems">List of <seealso cref="OrderItem"/> to be captured in this transaction.</param>
        /// <param name="description">A textual description of the capture.</param>
        /// <param name="payeeReference">Transactionally unique reference from the merchant system.</param>
        /// <param name="itemDescriptions">A list of <seealso cref="Sdk.PaymentInstruments.ItemDescriptions"/>
        /// involved in the capture.</param>
        /// <param name="vatSummary">List of <seealso cref="Sdk.PaymentInstruments.VatSummary"/> involved
        /// in the capture.</param>
        public CaptureTransaction(Operation transactionActivity,
                                              Amount amount,
                                              Amount vatAmount,
                                              List<OrderItem> orderItems,
                                              string description,
                                              string payeeReference,
                                              List<ItemDescriptions> itemDescriptions,
                                              List<VatSummary> vatSummary)
        {
            TransactionActivity = transactionActivity;
            Amount = amount;
            VatAmount = vatAmount;
            OrderItems = orderItems;
            Description = description;
            PayeeReference = payeeReference;
            ItemDescriptions = itemDescriptions;
            VatSummary = vatSummary;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Operation TransactionActivity { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Amount Amount { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public List<OrderItem> OrderItems { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string PayeeReference { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Amount VatAmount { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public List<ItemDescriptions> ItemDescriptions { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public List<VatSummary> VatSummary { get; set; }
    }
}