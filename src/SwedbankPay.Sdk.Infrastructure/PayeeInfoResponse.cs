using System;

namespace SwedbankPay.Sdk
{
    internal class PayeeInfoResponse : Identifiable, IPayeeInfo
    {
        public PayeeInfoResponse(Uri id) : base(id)
        {
        }

        public PayeeInfoResponse(Uri id, string orderReference, Guid payeeId, string payeeName, string payeeReference, string productCategory, string subsite): base(id)
        {
            OrderReference = orderReference;
            PayeeId = payeeId;
            PayeeName = payeeName;
            PayeeReference = payeeReference;
            ProductCategory = productCategory;
            Subsite = subsite;
        }

        public string OrderReference { get; }
        public Guid PayeeId { get; }
        public string PayeeName { get; }
        public string PayeeReference { get; }
        public string ProductCategory { get; }
        public string Subsite { get; }
    }
}
