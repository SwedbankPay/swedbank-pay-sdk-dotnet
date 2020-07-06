using System;
using System.Collections.Generic;
using System.Globalization;

namespace SwedbankPay.Sdk.Payments.TrustlyPayments
{
    public class TrustlyPaymentRequest
    {
        public TrustlyPaymentRequest(
            CurrencyCode currency,
            List<Price> prices,
            string description,
            string payerReference,
            string userAgent,
            CultureInfo language,
            Urls urls,
            PayeeInfo payeeInfo,
            PrefillInfo prefillInfo)
        {
            Payment = new PaymentRequestObject(currency, prices, description, payerReference, userAgent, language,
                urls, payeeInfo, prefillInfo);
        }

        public PaymentRequestObject Payment { get; }
    }

    public class PaymentRequestObject
    {
        protected internal PaymentRequestObject(CurrencyCode currency,
                                                List<Price> prices,
                                                string description,
                                                string payerReference,
                                                string userAgent,
                                                CultureInfo language,
                                                Urls urls,
                                                PayeeInfo payeeInfo,
                                                PrefillInfo prefillInfo = null)
        {
            Operation = Operation.Purchase;
            Intent = Intent.Sale;
            Currency = currency;
            Prices = prices;
            Description = description;
            PayerReference = payerReference;
            UserAgent = userAgent;
            Language = language;
            Urls = urls;
            PayeeInfo = payeeInfo;
            PrefillInfo = prefillInfo;
        }


        public CurrencyCode Currency { get; set; }
        public string Description { get; set; }
        public Intent Intent { get; set; }
        public CultureInfo Language { get; set; }
        public Operation Operation { get; set; }
        public PayeeInfo PayeeInfo { get; internal set; }
        public string PayerReference { get; set; }
        public List<Price> Prices { get; set; }
        public Urls Urls { get; }
        public string UserAgent { get; set; }
        public PrefillInfo PrefillInfo { get; set; }
    }
}