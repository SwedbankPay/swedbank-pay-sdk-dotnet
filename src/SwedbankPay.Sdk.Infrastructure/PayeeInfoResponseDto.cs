using System;

namespace SwedbankPay.Sdk
{
    internal class PayeeInfoResponseDto
    {
        public PayeeInfoResponseDto() { }

        public PayeeInfoResponseDto(IPayeeInfo payeeInfo)
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

        public string PayeeId { get; set; }

        public string PayeeName { get; set; }

        public string PayeeReference { get; set; }

        public string ProductCategory { get; set; }

        public string Subsite { get; set; }

        internal PayeeInfoResponse Map()
        {
            return new PayeeInfoResponse(this);
        }
    }
}