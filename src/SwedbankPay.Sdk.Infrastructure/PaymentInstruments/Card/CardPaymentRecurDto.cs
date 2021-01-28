namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentRecurDto
    {
        public CardPaymentRecurDto(CardPaymentRecurDetails payment)
        {
            Operation = payment.Operation.Value;
            Intent = payment.Intent.ToString();
            RecurrenceToken = payment.RecurrenceToken;
            Currency = payment.Currency.ToString();
            Amount = payment.Amount.InLowestMonetaryUnit;
            VatAmount = payment.VatAmount.InLowestMonetaryUnit;
            Description = payment.Description;
            UserAgent = payment.UserAgent;
            Language = payment.Language.ToString();
            Urls = new UrlsDto(payment.Urls);
            PayeeInfo = new PayeeInfoResponseDto(payment.PayeeInfo);

            if (payment.Metadata != null)
            {
                Metadata = new MetadataDto(payment.Metadata);
            }
        }

        public string Operation { get; }

        public string Intent { get; }

        public string RecurrenceToken { get; }

        public string Currency { get; }

        public long Amount { get; }

        public long VatAmount { get; }

        public string Description { get; }

        public string UserAgent { get; }

        public string Language { get; }

        public UrlsDto Urls { get; }

        public PayeeInfoResponseDto PayeeInfo { get; }

        public MetadataDto Metadata { get; }
    }
}