namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// Object to hold details for verifying a card payment
    /// </summary>
    public class CardPaymentVerifyRequestDetails
    {
        /// <summary>
        /// Instantiates a new Verify request for a card payment.
        /// </summary>
        /// <param name="intent"></param>
        /// <param name="currency"></param>
        /// <param name="description"></param>
        /// <param name="userAgent"></param>
        /// <param name="language"></param>
        /// <param name="urls"></param>
        /// <param name="payeeInfo"></param>
        public CardPaymentVerifyRequestDetails(PaymentIntent intent, Currency currency, string description, string userAgent, Language language, IUrls urls, IPayeeInfo payeeInfo)
        {
            Intent = intent;
            Currency = currency;
            Description = description;
            UserAgent = userAgent;
            Language = language;
            Urls = urls;
            PayeeInfo = payeeInfo;
        }

        /// <summary>
        /// The initial <seealso cref="Sdk.Operation" /> of the payment.
        /// </summary>
        public Operation Operation { get; } = Operation.Verify;

        /// <summary>
        /// The initial <seealso cref="PaymentIntent" /> of the payment.
        /// </summary>
        public PaymentIntent Intent { get; }

        /// <summary>
        /// The provided reccurence token.
        /// </summary>
        public string RecurrenceToken { get; }

        /// <summary>
        /// The <seealso cref="Sdk.Currency" /> to be paid.
        /// </summary>
        public Currency Currency { get; }

        /// <summary>
        /// A textual description of the payment.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// The payers user agent.
        /// </summary>
        public string UserAgent { get; }

        /// <summary>
        /// The payers preferred <see cref="Sdk.Language" />.
        /// </summary>
        public Language Language { get; }

        /// <summary>
        /// Urls relevant for the payment.
        /// </summary>
        public IUrls Urls { get; }

        /// <summary>
        /// The merchant information.
        /// </summary>
        public IPayeeInfo PayeeInfo { get; }

        /// <summary>
        /// When making the initial purchase request, you need to generate a paymentToken.
        /// You can do this either by by setting the GeneratePaymentToken field to true,
        /// or set the initial operation to Verify.
        /// </summary>
        public bool GeneratePaymentToken { get; set; }

        /// <summary>
        /// Set this to true if you want to create a recurrenceToken for future use Recurring purchases (subscription
        /// payments).
        /// </summary>
        public bool GenerateRecurrenceToken { get; set; }

        /// <summary>
        /// Metadata can be used to store data associated to a payment that can be
        /// retrieved later by performing a GET on the payment.
        /// Swedbank Pay does not use or process metadata,
        /// it is only stored on the payment so it can be retrieved later alongside the payment.
        /// An example where metadata might be useful is when several internal systems
        /// are involved in the payment process and the payment creation is done in one system
        /// and post-purchases take place in another.
        /// In order to transmit data between these two internal systems,
        /// the data can be stored in metadata on the payment so the internal
        /// systems do not need to communicate with each other directly.
        /// </summary>
        public Metadata Metadata { get; set; }
    }
}