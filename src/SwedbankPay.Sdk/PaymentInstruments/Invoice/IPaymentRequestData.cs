using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public interface IPaymentRequestData
    {
        CurrencyCode Currency { get; set; }
        string Description { get; set; }
        bool GeneratePaymentToken { get; set; }
        bool GenerateReccurenceToken { get; set; }
        PaymentIntent Intent { get; set; }
        Language Language { get; set; }
        Dictionary<string, object> Metadata { get; }
        Operation Operation { get; set; }
        PayeeInfo PayeeInfo { get; }
        string PayerReference { get; set; }
        string PaymentToken { get; set; }
        PrefillInfo PrefillInfo { get; set; }
        List<IPrice> Prices { get; set; }
        IUrls Urls { get; }
        string UserAgent { get; set; }
    }
}