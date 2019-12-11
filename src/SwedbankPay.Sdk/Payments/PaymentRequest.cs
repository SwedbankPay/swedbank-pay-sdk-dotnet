using System;

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
        }
        public PaymentRequest(Operation operation, string intent, CurrencyCode currency, List<Price> prices, string description, string payerReference, string userAgent, Language language, Urls urls, PayeeInfo payeeInfo, PrefillInfo prefillInfo, bool generatePaymentToken, string paymentToken, long amount, long vatAmount)
        {
            Operation = operation ?? throw new ArgumentNullException(nameof(operation));
            Intent = intent;
            Currency = currency;
            Prices = prices;
            Description = description;
            PayerReference = payerReference;
            UserAgent = userAgent;
            Language = language;
            Urls = urls;
            PayeeInfo = payeeInfo;
            PrefillInfo = prefillInfo;
            GeneratePaymentToken = generatePaymentToken;
            PaymentToken = paymentToken;
            Amount = amount;
            VatAmount = vatAmount;
        }

        public Operation Operation { get; set; }
        public string Intent { get; set; }

        public CurrencyCode Currency { get; set; }

        public List<Price> Prices { get; set; }

        public string Description { get; set; }

        public string PayerReference { get; set; }

        public string UserAgent { get; set; }

        public Language Language { get; set; }

        public Urls Urls { get; }

        public PayeeInfo PayeeInfo { get; internal set; }

        public PrefillInfo PrefillInfo { get; }

        public bool GeneratePaymentToken { get; set; }

        public string PaymentToken { get; set; }

        public long Amount { get; set; }

        public long VatAmount { get; set; }
    }
}