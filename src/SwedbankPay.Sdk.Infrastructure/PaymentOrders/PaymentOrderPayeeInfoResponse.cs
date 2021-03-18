namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class PaymentOrderPayeeInfoResponse : Identifiable, IPaymentOrderPayeeInfo
    {
        public PaymentOrderPayeeInfoResponse(PaymentOrderPayeeInfoDto dto)
            : base(dto.Id)
        {
            OrderReference = dto.OrderReference;
            PayeeId = dto.PayeeId;
            PayeeName = dto.PayeeName;
            PayeeReference = dto.PayeeReference;
            ProductCategory = dto.ProductCategory;
            Subsite = dto.Subsite;
            CorporationId = dto.CorporationId;
            CorporationName = dto.CorporationName;
        }

        public string OrderReference { get; }
        public string PayeeId { get; }
        public string PayeeName { get; }
        public string PayeeReference { get; }
        public string ProductCategory { get; }
        public string Subsite { get; }
        public string CorporationId { get; }
        public string CorporationName { get; }
    }
}