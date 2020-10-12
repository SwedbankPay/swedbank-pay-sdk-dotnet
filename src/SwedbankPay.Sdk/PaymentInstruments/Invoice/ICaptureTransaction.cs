using SwedbankPay.Sdk.PaymentOrders;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public interface ICaptureTransaction
    {
        Amount Amount { get; }
        string Description { get; }
        List<ItemDescriptions> ItemDescriptions { get; set; }
        List<OrderItem> OrderItems { get; }
        string PayeeReference { get; }
        Operation TransactionActivity { get; set; }
        Amount VatAmount { get; }
        List<VatSummary> VatSummary { get; set; }
    }
}