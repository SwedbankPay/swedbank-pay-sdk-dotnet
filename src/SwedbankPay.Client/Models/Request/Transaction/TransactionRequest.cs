namespace SwedbankPay.Client.Models.Request.Transaction
{
    using System.Collections.Generic;
    using SwedbankPay.Client.Models.Common;

    public class TransactionRequest
    {
        public long Amount { get; set; }
        public long VatAmount { get; set; }
        public string Description { get; set; }
        public string PayeeReference { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
