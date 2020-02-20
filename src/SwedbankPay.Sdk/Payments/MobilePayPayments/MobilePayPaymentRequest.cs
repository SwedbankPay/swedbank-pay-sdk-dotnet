using System;
using System.Collections.Generic;
using System.Globalization;

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
                              Uri shopslogoUrl,
                              string payerReference = null,
                              Dictionary<string, object> metaData = null,
                              PrefillInfo prefillInfo = null)

        {
            Payment = new PaymentRequestObject(operation, intent, currency, prices, description, payerReference, userAgent, language, urls, payeeInfo, metaData, prefillInfo);
            MobilePay = new MobilePayPaymentRequestObject(shopslogoUrl);
        }


        public PaymentRequestObject Payment { get; }
        public MobilePayPaymentRequestObject MobilePay { get; }

        public class PaymentRequestObject
        {
            protected internal PaymentRequestObject(Operation operation,
                                                    Intent intent,
                                                    CurrencyCode currency,
                                                    List<Price> prices,
                                                    string description,
                                                    string payerReference,
                                                    string userAgent,
                                                    CultureInfo language,
                                                    Urls urls,
                                                    PayeeInfo payeeInfo,
                                                    Dictionary<string, object> metaData = null,
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
                MetaData = metaData;
                PrefillInfo = prefillInfo;
            }


            public CurrencyCode Currency { get; set; }
            public string Description { get; set; }
            public Intent Intent { get; set; }
            public CultureInfo Language { get; set; }
            public Dictionary<string, object> MetaData { get; }
            public Operation Operation { get; set; }
            public PayeeInfo PayeeInfo { get; internal set; }
            public string PayerReference { get; set; }
            public List<Price> Prices { get; set; }
            public Urls Urls { get; }
            public string UserAgent { get; set; }
            public PrefillInfo PrefillInfo { get; set; }
        }


        public class MobilePayPaymentRequestObject
        {
            protected internal MobilePayPaymentRequestObject(Uri shoplogoUrl)
            {
                ShoplogoUrl = shoplogoUrl;
            }

            /// <summary>
            ///    URI to logo that will be visible at MobilePay payment menu
            /// </summary>
            public Uri ShoplogoUrl { get; set; }

        }
    }
}
