namespace SwedbankPay.Client.Models.Response
{
    using SwedbankPay.Client.Models.Vipps.PaymentAPI.Request;
    using System;
    using SwedbankPay.Client.Models.Common;
    using IdLink = SwedbankPay.Client.Models.Vipps.PaymentAPI.Response.IdLink;

    public class PaymentOrderResponse : IdLink
    {
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Operation { get; set; }
        public string State { get; set; }
        public string Currency { get; set; }
        public long Amount { get; set; }
        public long VatAmount { get; set; }
        public long RemainingCaptureAmount { get; set; }
        public long RemainingCancellationAmount { get; set; }
        public long RemainingReversalAmount { get; set; }
        public string Description { get; set; }
        public string UserAgent { get; set; }
        public string Language { get; set; }
        public Urls Urls { get; set; }
        public PayeeInfo PayeeInfo { get; set; }
        public IdLink Settings { get; set; }
        public IdLink Payers { get; set; }
        public IdLink OrderItems { get; set; }
        public IdLink MetaData { get; set; }
        public IdLink Payments { get; set; }
        public IdLink CurrentPayment { get; set; }
    }
}
