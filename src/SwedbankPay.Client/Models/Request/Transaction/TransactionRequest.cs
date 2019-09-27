namespace SwedbankPay.Client.Models.Request.Transaction
{
    public class TransactionRequest
    {
        public long Amount { get; set; }
        public long VatAmount { get; set; }
        public string Description { get; set; }
        public string PayeeReference { get; set; }
    }
}
