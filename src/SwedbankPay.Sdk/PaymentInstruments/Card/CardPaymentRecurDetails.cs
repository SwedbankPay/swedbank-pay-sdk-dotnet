namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// Details on initiating a recurring payment for credit card.
    /// </summary>
    public class CardPaymentRecurDetails
    {
        /// <summary>
        /// Instantiates a new <see cref="CardPaymentRecurDetails"/> with the provided parameters.
        /// </summary>
        /// <param name="operation">The initial <see cref="Sdk.Operation"/> of the payment.</param>
        /// <param name="intent">The initial intent of the payment.</param>
        /// <param name="recurrenceToken">A previosuly created recurrence token, from a verify request.</param>
        /// <param name="currency">The <see cref="Sdk.Currency"/> to be paid.</param>
        /// <param name="amount">The <seealso cref="Sdk.Amount"/> to be paid.</param>
        /// <param name="vatAmount">The <seealso cref="Sdk.Amount"/> to be paid in VAT.</param>
        /// <param name="description">A textual description of the recurring payment.</param>
        /// <param name="userAgent">The payers user agent.</param>
        /// <param name="language">The payers prefered <seealso cref="Sdk.Language"/>.</param>
        /// <param name="urls">Relevant URLs for the payment.</param>
        /// <param name="payeeInfo">Merchant payee information.</param>
        public CardPaymentRecurDetails(Operation operation,
                                       PaymentIntent intent,
                                       string recurrenceToken,
                                       Currency currency,
                                       Amount amount,
                                       Amount vatAmount,
                                       string description,
                                       string userAgent,
                                       Language language,
                                       IUrls urls,
                                       IPayeeInfo payeeInfo)
        {
            Operation = operation;
            Intent = intent;
            RecurrenceToken = recurrenceToken;
            Currency = currency;
            Amount = amount;
            VatAmount = vatAmount;
            Description = description;
            UserAgent = userAgent;
            Language = language;
            Urls = urls;
            PayeeInfo = payeeInfo;
        }

        /// <summary>
        /// The initial <seealso cref="Sdk.Operation"/> of the payment.
        /// </summary>
        public Operation Operation { get; }

        /// <summary>
        /// The initial <seealso cref="PaymentIntent"/> of the payment.
        /// </summary>
        public PaymentIntent Intent { get; }

        /// <summary>
        /// The provided reccurence token.
        /// </summary>
        public string RecurrenceToken { get; }

        /// <summary>
        /// The <seealso cref="Sdk.Currency"/> to be paid.
        /// </summary>
        public Currency Currency { get; }

        /// <summary>
        /// The <seealso cref="Sdk.Amount"/> to be paid.
        /// </summary>
        public Amount Amount { get; }

        /// <summary>
        /// Any VAT<seealso cref="Sdk.Amount"/> to be paid.
        /// </summary>
        public Amount VatAmount { get; }

        /// <summary>
        /// A textual description of the payment.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// The payers user agent.
        /// </summary>
        public string UserAgent { get; }

        /// <summary>
        /// The payers prefered <see cref="Sdk.Language"/>.
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