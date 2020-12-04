using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Trustly
{
    internal class TrustlyPaymentDetailsDto
    {
        public TrustlyPaymentDetailsDto(TrustlyPaymentDetails payment)
        {
            Currency = payment.Currency.ToString();
            Description = payment.Description;
            Intent = payment.Intent.ToString();
            Language = payment.Language.ToString();
            Operation = payment.Operation.Value;
            PayeeInfo = new PayeeInfoDto(payment.PayeeInfo);
            PayerReference = payment.PayerReference;
            Prices = new List<PriceDto>();
            foreach (var item in payment.Prices)
            {
                Prices.Add(new PriceDto(item));
            }
            Urls = new UrlsDto(payment.Urls);
            UserAgent = payment.UserAgent;
            PrefillInfo = new TrustlyPrefillInfoDto(payment.PrefillInfo);
        }

        public string Currency { get; set; }

        public string Description { get; set; }

        public string Intent { get; set; }

        public string Language { get; set; }

        public string Operation { get; set; }

        public PayeeInfoDto PayeeInfo { get; set; }

        public string PayerReference { get; set; }

        public List<PriceDto> Prices { get; set; }

        public UrlsDto Urls { get; }

        public string UserAgent { get; set; }

        public TrustlyPrefillInfoDto PrefillInfo { get; set; }
    }
}