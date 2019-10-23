using System;
using System.Collections.Generic;
using SwedbankPay.Client.Models.Vipps.TransactionAPI.Response;

namespace SwedbankPay.Client.Models.Response.Payment
{
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