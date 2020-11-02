using SwedbankPay.Sdk.PaymentOrders;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class CaptureTransaction : ICaptureTransaction
    {
        protected internal CaptureTransaction(Operation transactionActivity,
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

        public Operation TransactionActivity { get; set; }
        public Amount Amount { get; }
        public string Description { get; }
        public List<OrderItem> OrderItems { get; }
        public string PayeeReference { get; }
        public Amount VatAmount { get; }
        public List<ItemDescriptions> ItemDescriptions { get; set; }
        public List<VatSummary> VatSummary { get; set; }
    }
}