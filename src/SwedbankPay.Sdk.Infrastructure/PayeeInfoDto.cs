using System;

namespace SwedbankPay.Sdk
{
    internal class PayeeInfoDto
    {
        public PayeeInfoDto() { }

        public PayeeInfoDto(PayeeInfo payeeInfo)
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
            return new PayeeInfo(PayeeId, PayeeReference, PayeeName, ProductCategory, Subsite, OrderReference);
        }
    }
}