namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderPayeeInfoDto
    {
        public string Id { get; set; }
        public string PayeeId { get; set; }
        public string PayeeReference { get; set; }
        public string PayeeName { get; set; }
        public string CorporationId { get; set; }
        public string CorporationName { get; set; }
    }
}