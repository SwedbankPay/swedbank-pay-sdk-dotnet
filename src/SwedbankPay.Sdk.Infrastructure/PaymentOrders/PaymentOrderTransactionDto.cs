namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderTransactionDto
    {
        public string Id { get; set; }
        public string Created { get; set; }
        public string Updated { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
        public string Number { get; set; }
        public int Amount { get; set; }
        public int VatAmount { get; set; }
        public string Description { get; set; }
        public string PayeeReference { get; set; }
    }

}