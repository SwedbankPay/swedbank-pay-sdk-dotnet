namespace SwedbankPay.Sdk.Models.Response.Payment
{
    using System;
    using SwedbankPay.Sdk.Models.Vipps.TransactionAPI.Response;

    public class SaleResponse
    {
        public DateTime Date { get; set; }
        public string PayerAlias { get; set; }
        public string SwishPaymentReference { get; set; }
        public string SwishStatus { get; set; }

        public string Id { get; set; }
        public TransactionResponse Transaction { get; set; }

    }
}