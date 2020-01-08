using Newtonsoft.Json;

using SwedbankPay.Sdk.PaymentOrders;

using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments.Swish
{
    public class PaymentRequest : SwedbankPay.Sdk.Payments.PaymentRequest
    {
        public PaymentRequest(CurrencyCode currency,
                              List<Price> prices,
                              string description,
                              string payerReference,
                              string userAgent,
                              Language language,
                              Urls urls,
                              PayeeInfo payeeInfo,
                              PrefillInfo prefillInfo,
                              SwishRequest swishRequest)
        {
            Operation = Operation.Purchase;
            Intent = "Sale";
            Currency = currency;
            Prices = prices;
            Description = description;
            PayerReference = payerReference;
            UserAgent = userAgent;
            Language = language;
            Urls = urls;
            PayeeInfo = payeeInfo;
            PrefillInfo = prefillInfo;
            SwishRequest = swishRequest;
        }


        public Operation Operation { get; }
        public string Intent { get;}
        public CurrencyCode Currency { get; }
        public List<Price> Prices { get; }
        public string Description { get; }
        public string PayerReference { get; }
        public string UserAgent { get; }
        public Language Language { get; }
        public Urls Urls { get; }
        public PayeeInfo PayeeInfo { get; }
        public PrefillInfo PrefillInfo { get; }

        [JsonProperty("swish")]
        public SwishRequest SwishRequest { get; }
    }
}
