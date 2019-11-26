namespace SwedbankPay.Sdk.Payments
{
    using System.Collections.Generic;
    using SwedbankPay.Sdk.PaymentOrders;

    public class PaymentRequest
    {
        public PaymentRequest(string useragent, string description, string payerReference, string payeeReference, params Price[] prices)
        {
            UserAgent = useragent;
            Description = description;
            if (prices != null)
                Prices.AddRange(prices);

            PayerReference = payerReference;
            PayeeInfo.PayeeReference = payeeReference;
        }

        public string Operation { get; set; } = "Purchase";
        public string Intent { get; set; } = "Authorization";

        public CurrencyCode Currency { get; set; }

        public List<Price> Prices { get; set; } = new List<Price>();

        public string Description { get; set; }

        public string PayerReference { get; set; }

        public string UserAgent { get; set; }

        public Language Language { get; set; }

        public Urls Urls { get; } = new Urls();

        public PayeeInfo PayeeInfo { get; } = new PayeeInfo();

        public PrefillInfo PrefillInfo { get; } = new PrefillInfo();

        public bool GeneratePaymentToken { get; set; } = false;

        public string PaymentToken { get; set; }

        public long Amount { get; set; }

        public long VatAmount { get; set; }
    }
}