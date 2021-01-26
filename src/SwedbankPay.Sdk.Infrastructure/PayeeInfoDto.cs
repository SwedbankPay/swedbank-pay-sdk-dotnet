using System;

namespace SwedbankPay.Sdk
{
    internal class PayeeInfoDto
    {
        public PayeeInfoDto() { }

        public PayeeInfoDto(IPayeeInfo payeeInfo)
        {
            OrderReference = payeeInfo.OrderReference;
            PayeeId = payeeInfo.PayeeId;
            PayeeName = payeeInfo.PayeeName;
            PayeeReference = payeeInfo.PayeeReference;
            ProductCategory = payeeInfo.ProductCategory;
            Subsite = payeeInfo.Subsite;
        }

        public string Id { get; set; }

        public string OrderReference { get; set; }

        public Guid PayeeId { get; set; }

        public string PayeeName { get; set; }

        public string PayeeReference { get; set; }

        public string ProductCategory { get; set; }

        public string Subsite { get; set; }

        internal PayeeInfo Map()
        {
            var payeeInfo = new PayeeInfo(PayeeId, PayeeReference)
            {
                PayeeName = PayeeName,
                ProductCategory = ProductCategory,
                Subsite = Subsite,
                OrderReference = OrderReference
            };
            return payeeInfo;
        }
    }
}