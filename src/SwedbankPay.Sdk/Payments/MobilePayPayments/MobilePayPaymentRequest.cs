using System;
using System.Collections.Generic;
using System.Globalization;

using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Payments.MobilePayPayments
{
    public class MobilePayPaymentRequest
    {
        public MobilePayPaymentRequest(Operation operation,
                              Intent intent,
                              CurrencyCode currency,
                              List<Price> prices,
                              string description,
                              string userAgent,
                              CultureInfo language,
                              Urls urls,
                              PayeeInfo payeeInfo,
                              Uri shopLogoUrl = null,
                              bool generatePaymentToken = false,
                              bool generateReccurenceToken = false,
                              string payerReference = null,
                              Dictionary<string, object> metaData = null,
                              string paymentToken = null,
                              PrefillInfo prefillInfo = null)

        {
            var requestObject = new MobilePayRequestObject(shopLogoUrl);
            payment = new PaymentRequestObject(operation, intent, currency, prices, description, payerReference, generatePaymentToken,
                                               generateReccurenceToken, userAgent, language, urls, payeeInfo, metaData, paymentToken, prefillInfo, requestObject);
        }


        private PaymentRequestObject payment;

        public CurrencyCode Currency => this.payment.Currency;
        public string Description => this.payment.Description;
        public bool GeneratePaymentToken => this.payment.GeneratePaymentToken;
        public bool GenerateReccurenceToken => this.payment.GenerateReccurenceToken;
        public Intent Intent => this.payment.Intent;
        public CultureInfo Language => this.payment.Language;
        public Dictionary<string, object> MetaData => this.payment.MetaData;
        public Operation Operation => this.payment.Operation;
        public PayeeInfo PayeeInfo => this.payment.PayeeInfo;
        public string PayerReference => this.payment.PayerReference;
        public string PaymentToken => this.payment.PaymentToken;
        public List<Price> Prices => this.payment.Prices;
        public Urls Urls => this.payment.Urls;
        public string UserAgent => this.payment.UserAgent;
        public PrefillInfo PrefillInfo => this.payment.PrefillInfo;
        public MobilePayRequestObject MobilePay => this.payment.MobilePay;

    private class PaymentRequestObject
        {
            protected internal PaymentRequestObject(Operation operation,
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
                                                    Dictionary<string, object> metaData = null,
                                                    string paymentToken = null,
                                                    PrefillInfo prefillInfo = null,
                                                    MobilePayRequestObject mobilePay = null)
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
                MetaData = metaData;
                GeneratePaymentToken = generatePaymentToken;
                GenerateReccurenceToken = generateReccurenceToken;
                PaymentToken = paymentToken;
                PrefillInfo = prefillInfo;
                MobilePay = mobilePay;
            }


            public CurrencyCode Currency { get; }
            public string Description { get; }
            public bool GeneratePaymentToken { get; }
            public bool GenerateReccurenceToken { get; }
            public Intent Intent { get; }
            public CultureInfo Language { get; }
            public Dictionary<string, object> MetaData { get; }

            public Operation Operation { get; }
            public PayeeInfo PayeeInfo { get; }
            public string PayerReference { get; }
            public string PaymentToken { get; }
            public List<Price> Prices { get; }
            public Urls Urls { get; }
            public string UserAgent { get; }
            public PrefillInfo PrefillInfo { get; }
            public MobilePayRequestObject MobilePay { get; }
        }
    }
}