using System;
using System.Collections.Generic;

using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Payments.Card
{
    public class PaymentRequest : Payments.PaymentRequest
    {
        public PaymentRequest(Operation operation,
                              string intent,
                              CurrencyCode currency,
                              List<Price> prices,
                              string description,
                              string payerReference,
                              bool generatePaymentToken,
                              bool generateReccurenceToken,
                              string userAgent,
                              Language language,
                              Urls urls,
                              PayeeInfo payeeInfo,
                              RiskIndicator riskIndicator = null,
                              Cardholder cardholder = null,
                              CreditCard creditCard = null,
                              Dictionary<string, object> metaData = null,
                              string paymentToken = null)
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
            RiskIndicator = riskIndicator;
            Cardholder = cardholder;
            CreditCard = creditCard;
            MetaData = metaData;
            GeneratePaymentToken = generatePaymentToken;
            GenerateReccurenceToken = generateReccurenceToken;
            PaymentToken = paymentToken;
        }

        public Operation Operation { get; set; }
        public string Intent { get; set; }
        public CurrencyCode Currency { get; set; }
        public List<Price> Prices { get; set; }
        public string Description { get; set; }
        public bool GeneratePaymentToken { get; set; }
        public bool GenerateReccurenceToken { get; set; }
        public string UserAgent { get; set; }
        public Language Language { get; set; }
        public Urls Urls { get; }
        public PayeeInfo PayeeInfo { get; internal set; }
        public RiskIndicator RiskIndicator { get; }
        public Cardholder Cardholder { get; }
        public CreditCard CreditCard { get; }
        public Dictionary<string, object> MetaData { get; }
        public string PayerReference { get; set; }
        public string PaymentToken { get; set; }
    }
}