namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentVerifyRequestDetailsDto
    {
        public CardPaymentVerifyRequestDetailsDto(CardPaymentVerifyRequestDetails payment)
        {
            Operation = payment.Operation.Value;
            Intent = payment.Intent.ToString();
            RecurrenceToken = payment.RecurrenceToken;
            Currency = payment.Currency.ToString();
            Description = payment.Description;
            UserAgent = payment.UserAgent;
            Language = payment.Language.ToString();
            Urls = new UrlsDto(payment.Urls);
            PayeeInfo = new PayeeInfoResponseDto(payment.PayeeInfo);
            GenerateRecurrenceToken = payment.GenerateRecurrenceToken;
            GeneratePaymentToken = payment.GeneratePaymentToken;

            if (payment.Metadata != null)
            {
                Metadata = new MetadataDto(payment.Metadata);
            }
        }

        public string Operation { get; }

        public string Intent { get; }

        public string RecurrenceToken { get; }

        public string Currency { get; }

        public string Description { get; }

        /// <summary>
        ///     When making the initial purchase request, you need to generate a paymentToken.
        ///     You can do this either by by setting the GeneratePaymentToken field to true,
        ///     or set the initial operation to Verify.
        /// </summary>
        public bool GeneratePaymentToken { get; set; }

        /// <summary>
        ///     Set this to true if you want to create a recurrenceToken for future use Recurring purchases (subscription
        ///     payments).
        /// </summary>
        public bool GenerateRecurrenceToken { get; set; }

        public string UserAgent { get; }

        public string Language { get; }

        public UrlsDto Urls { get; }

        public PayeeInfoResponseDto PayeeInfo { get; }

        public MetadataDto Metadata { get; }
    }
}