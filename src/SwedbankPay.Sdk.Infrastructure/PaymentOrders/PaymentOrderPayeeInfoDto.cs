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
        public string Subsite { get; set; }
        public string OrderReference { get; set; }

        internal PayeeInfoResponse Map()
        {
            var uri = new Uri(Id, UriKind.RelativeOrAbsolute);

            if (string.IsNullOrEmpty(PayeeId))
            {
                return new PayeeInfoResponse(uri);
            }

            return new PayeeInfoResponse(this);
        }
    }
}