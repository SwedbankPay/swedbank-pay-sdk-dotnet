using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class InvoicePaymentRequestDetails : IPaymentRequestDetails
    {
        public InvoicePaymentRequestDetails(Operation operation,
                                                    PaymentIntent intent,
                                                    Currency currency,
                                                    List<IPrice> prices,
                                                    string description,
                                                    string payerReference,
                                                    bool generatePaymentToken,
                                                    bool generateRecurrenceToken,
                                                    string userAgent,
                                                    Language language,
                                                    IUrls urls,
                                                    PayeeInfo payeeInfo,
                                                    Dictionary<string, object> metadata = null,
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
            Metadata = metadata;
            GeneratePaymentToken = generatePaymentToken;
            GenerateRecurrenceToken = generateRecurrenceToken;
            PaymentToken = paymentToken;
            PrefillInfo = prefillInfo;
        }


        public Currency Currency { get; set; }
        public string Description { get; set; }
        public bool GeneratePaymentToken { get; set; }
        public bool GenerateRecurrenceToken { get; set; }
        public PaymentIntent Intent { get; set; }
        public Language Language { get; set; }
        public Dictionary<string, object> Metadata { get; }
        public Operation Operation { get; set; }
        public PayeeInfo PayeeInfo { get; set; }
        public string PayerReference { get; set; }
        public string PaymentToken { get; set; }
        public List<IPrice> Prices { get; set; }
        public IUrls Urls { get; }
        public string UserAgent { get; set; }
        public PrefillInfo PrefillInfo { get; set; }
    }

}