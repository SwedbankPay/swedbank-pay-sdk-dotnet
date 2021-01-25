using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class PaymentOrderPayeeInfoDto
    {
        public string Id { get; set; }
        public string PayeeId { get; set; }
        public string PayeeReference { get; set; }
        public string PayeeName { get; set; }
        public string CorporationId { get; set; }
        public string CorporationName { get; set; }
        public string ProductCategory { get; set; }

        internal PayeeInfo Map()
        {
            var uri = new Uri(Id, UriKind.RelativeOrAbsolute);
            if (string.IsNullOrEmpty(PayeeId))
            {
                return new PayeeInfo(uri);
            }

            var payeeInfo = new PayeeInfo(Guid.Parse(PayeeId), PayeeReference)
            {
                PayeeName = PayeeName,
                ProductCategory = ProductCategory
            };
            return payeeInfo;
        }
    }
}