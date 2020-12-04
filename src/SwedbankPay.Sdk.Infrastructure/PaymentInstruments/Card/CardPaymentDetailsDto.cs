using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentDetailsDto
    {
        public CardPaymentDetailsDto(CardPaymentDetails payment)
        {
            Cardholder = new CardholderDto(payment.Cardholder);
            CreditCard = new CreditCardDto(payment.CreditCard);
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
            Prices = new List<PriceDto>();
            foreach (var item in payment.Prices)
            {
                Prices.Add(new PriceDto(item));
            };
            RiskIndicator = new RiskIndicatorDto(payment.RiskIndicator);
            Urls = new UrlsDto(payment.Urls);
            UserAgent = payment.UserAgent;
            Metadata = payment.Metadata;
            // The key ID is not allowed in this object.
            // It results in a error.
            Metadata.Remove("Id");
        }

        public CardholderDto Cardholder { get; set; }

        public CreditCardDto CreditCard { get; set; }

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

        public List<PriceDto> Prices { get; set; }

        public RiskIndicatorDto RiskIndicator { get; set; }

        public UrlsDto Urls { get; set; }

        public string UserAgent { get; set; }

        public Dictionary<string, object> Metadata { get; set; }
    }
}