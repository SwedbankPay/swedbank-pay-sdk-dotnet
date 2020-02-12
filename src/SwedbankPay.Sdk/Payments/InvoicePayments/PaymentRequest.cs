using System;
using System.Collections.Generic;
using System.Globalization;

using SwedbankPay.Sdk.Payments;

namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public class PaymentRequest
    {
        public PaymentRequest(Operation operation,
                              Intent intent,
                              CurrencyCode currency,
                              List<Price> prices,
                              string description,
                              string userAgent,
                              CultureInfo language,
                              Urls urls,
                              PayeeInfo payeeInfo,
                              InvoiceType invoice,
                              bool generatePaymentToken = false,
                              bool generateReccurenceToken = false,
                              string payerReference = null,
                              Dictionary<string, object> metaData = null,
                              string paymentToken = null,
                              PrefillInfo prefillInfo = null)
        {
            Payment = new PaymentRequestObject(operation, intent, currency, prices, description, payerReference, generatePaymentToken,
                                               generateReccurenceToken, userAgent, language, urls, payeeInfo, invoice,
                                               metaData, paymentToken, prefillInfo);
        }


        public PaymentRequestObject Payment { get; }

        public class PaymentRequestObject
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
                                                    InvoiceType invoice,
                                                    Dictionary<string, object> metaData = null,
                                                    string paymentToken = null,
                                                    PrefillInfo prefillInfo = null)
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
                Invoice = invoice;
                MetaData = metaData;
                GeneratePaymentToken = generatePaymentToken;
                GenerateReccurenceToken = generateReccurenceToken;
                PaymentToken = paymentToken;
                PrefillInfo = prefillInfo;
            }


            public CurrencyCode Currency { get; set; }
            public string Description { get; set; }
            public bool GeneratePaymentToken { get; set; }
            public bool GenerateReccurenceToken { get; set; }
            public Intent Intent { get; set; }
            public CultureInfo Language { get; set; }
            public Dictionary<string, object> MetaData { get; }
            public InvoiceType Invoice { get; set; }
            public Operation Operation { get; set; }
            public PayeeInfo PayeeInfo { get; internal set; }
            public string PayerReference { get; set; }
            public string PaymentToken { get; set; }
            public List<Price> Prices { get; set; }
            public Urls Urls { get; }
            public string UserAgent { get; set; }
            public PrefillInfo PrefillInfo { get; set; }
        }
    }
}