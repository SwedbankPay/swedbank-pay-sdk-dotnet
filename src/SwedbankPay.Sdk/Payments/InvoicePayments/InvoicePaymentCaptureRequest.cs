using System.Collections.Generic;

using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public class InvoicePaymentCaptureRequest
    {
        public InvoicePaymentCaptureRequest(Operation transactionActivity,
                                            Amount amount,
                                            Amount vatAmount, 
                                            List<OrderItem> orderItems, 
                                            string description, 
                                            string payeeReference, 
                                            List<ItemDescriptions> itemDescriptions, 
                                            List<VatSummary> vatSummary)
        {
            Transaction = new CaptureTransaction(transactionActivity,
                                                 amount,
                                                 vatAmount,
                                                 orderItems,
                                                 description,
                                                 payeeReference,
                                                 itemDescriptions,
                                                 vatSummary);
        }


        public CaptureTransaction Transaction { get; }

        public class CaptureTransaction
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
}