using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    /// <summary>
    /// Transactional details about a Vipps payment.
    /// </summary>
    public interface IVippsPayment
    {
        /// <summary>
        /// The <seealso cref="Sdk.Amount"/> set for this payment.
        /// </summary>
        public Amount Amount { get; }

        /// <summary>
        /// Resrouce to get available authorizations on this payment.
        /// </summary>
        public IVippsPaymentAuthorizationListResponse Authorizations { get; }

        /// <summary>
        /// Resoruce to get available cancellations on this payment.
        /// </summary>
        public ICancellationsListResponse Cancellations { get; }

        /// <summary>
        /// Resource to get available captures on this payment.
        /// </summary>
        public ICapturesListResponse Captures { get; }

        /// <summary>
        /// The <seealso cref="DateTime"/> this payment was created.
        /// </summary>
        public DateTime Created { get; }

        /// <summary>
        /// The <seealso cref="DateTime"/> this payment was last updated.
        /// </summary>
        public DateTime Updated { get; }

        /// <summary>
        /// The set <seealso cref="Sdk.Currency"/> for this payment.
        /// </summary>
        public Currency Currency { get; }

        /// <summary>
        /// A textual description of what is being paid for.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// A unique <seealso cref="Uri"/> to access this payment.
        /// </summary>
        public Uri Id { get; }

        /// <summary>
        /// The <seealso cref="PaymentInstrument"/> this payment is set to.
        /// <seealso cref="PaymentInstrument.Vipps"/> for Vipps payments.
        /// </summary>
        public PaymentInstrument Instrument { get; }

        /// <summary>
        /// The intended <seealso cref="PaymentIntent"/> for this payment.
        /// </summary>
        public PaymentIntent Intent { get; }

        /// <summary>
        /// Payers prefered language.
        /// </summary>
        public Language Language { get; }

        /// <summary>
        /// The transaction number, useful when there’s need to reference the transaction in human communication.
        /// Not usable for programmatic identification of the transaction, where <see cref="Id"/> should be used instead.
        /// </summary>
        public long Number { get; }

        /// <summary>
        /// Operation used to create this payment.
        /// </summary>
        public Operation Operation { get; }

        /// <summary>
        /// Identifies the merchant that initiated the payment.
        /// </summary>
        public PayeeInfo PayeeInfo { get; }

        /// <summary>
        /// The reference to the payer from the merchant system, like e-mail address, mobile number, customer number etc.
        /// </summary>
        public string PayerReference { get; }

        /// <summary>
        /// The initiating systems UserAgent.
        /// </summary>
        public string InitiatingSystemUserAgent { get; }

        /// <summary>
        /// The prices resource lists the prices related to a specific payment.
        /// </summary>
        public IPricesListResponse Prices { get; }

        /// <summary>
        /// Resource to get available reversals on this payment
        /// </summary>
        public IReversalsListResponse Reversals { get; }

        /// <summary>
        /// The current <seealso cref="Sdk.State"/> of the payment.
        /// </summary>
        public State State { get; }

        /// <summary>
        /// Resource to get all available transactions on this payment.
        /// </summary>
        public ITransactionListResponse Transactions { get; }

        /// <summary>
        /// Resource to get <seealso cref="IUrls"/> set for this payment.
        /// </summary>
        public IUrls Urls { get; }

        /// <summary>
        /// The user agent string of the payer’s browser.
        /// </summary>
        public string UserAgent { get; }

        /// <summary>
        /// Metadata can be used to store data associated to a payment that can be retrieved later by performing a GET on the payment.
        /// Swedbank Pay does not use or process metadata,
        /// it is only stored on the payment so it can be retrieved later alongside the payment.
        /// An example where metadata might be useful is when several internal systems are involved in the payment process and
        /// the payment creation is done in one system and post-purchases take place in another.
        /// In order to transmit data between these two internal systems,
        /// the data can be stored in metadata on the payment so the internal systems do not need to communicate with each other directly.
        /// </summary>
        public Metadata Metadata { get; }
    }
}