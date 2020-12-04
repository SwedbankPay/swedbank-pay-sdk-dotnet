using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    internal class PaymentRequestDetailsDto
    {
        public PaymentRequestDetailsDto(IPaymentRequestDetails payment)
        {
            Currency = payment.Currency.ToString();
            Description = payment.Description;
            GeneratePaymentToken = payment.GeneratePaymentToken;
            GenerateRecurrenceToken = payment.GenerateRecurrenceToken;
            Intent = payment.Intent.ToString();
            Language = payment.Language.ToString();
            Operation = payment.Operation.Value;
            PayeeInfo = new PayeeInfoDto(payment.PayeeInfo);
            PayerReference = payment.PayerReference;
            PaymentToken = payment.PaymentToken;
            PrefillInfo = new PrefillInfoDto(payment.PrefillInfo);
            Prices = new List<PriceDto>();
            foreach (var item in payment.Prices)
            {
                Prices.Add(new PriceDto(item));
            }
            Urls = new UrlsDto(payment.Urls);
            UserAgent = payment.UserAgent;
            Metadata = payment.Metadata;
        }

        public string Currency { get; set; }

        public string Description { get; set; }

        public bool GeneratePaymentToken { get; set; }

        public bool GenerateRecurrenceToken { get; set; }

        public string Intent { get; set; }

        public string Language { get; set; }

        public string Operation { get; set; }

        public PayeeInfoDto PayeeInfo { get; set; }

        public string PayerReference { get; set; }

        public string PaymentToken { get; set; }

        public PrefillInfoDto PrefillInfo { get; set; }

        public List<PriceDto> Prices { get; set; }

        public UrlsDto Urls { get; set; }

        public string UserAgent { get; set; }

        public Dictionary<string, object> Metadata { get; set; }
    }
}