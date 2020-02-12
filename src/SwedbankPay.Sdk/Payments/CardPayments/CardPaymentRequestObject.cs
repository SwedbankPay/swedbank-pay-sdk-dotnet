using System;
using System.Collections.Generic;
using System.Globalization;

using SwedbankPay.Sdk.PaymentOrders;
using SwedbankPay.Sdk.Payments.CardPayments;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentRequestObject
    {
        protected internal CardPaymentRequestObject(Operation operation,
                                                Intent intent,
                                                CurrencyCode currency,
                                                List<Price> prices,
                                                string description,
                                                string payerReference,
                                                bool generatePaymentToken,
                                                bool generateReccurenceToken,
                                                string userAgent,
                                                CultureInfo language,
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


        public Cardholder Cardholder { get; }
        public CreditCard CreditCard { get; }
        public CurrencyCode Currency { get; set; }
        public string Description { get; set; }
        public bool GeneratePaymentToken { get; set; }
        public bool GenerateReccurenceToken { get; set; }
        public Intent Intent { get; set; }
        public CultureInfo Language { get; set; }
        public Dictionary<string, object> MetaData { get; }

        public Operation Operation { get; set; }
        public PayeeInfo PayeeInfo { get; internal set; }
        public string PayerReference { get; set; }
        public string PaymentToken { get; set; }
        public List<Price> Prices { get; set; }
        public RiskIndicator RiskIndicator { get; }
        public Urls Urls { get; }
        public string UserAgent { get; set; }
    }
}