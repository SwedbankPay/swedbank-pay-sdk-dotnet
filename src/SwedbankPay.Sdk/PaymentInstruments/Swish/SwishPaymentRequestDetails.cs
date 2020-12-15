using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    /// <summary>
    /// Detailes needed for creating a Swish payment.
    /// </summary>
    public class SwishPaymentRequestDetails
    {
        /// <summary>
        /// Instantiates a new <see cref="SwishPaymentRequestDetails"/> with the provided parameters.
        /// </summary>
        /// <param name="description">Textual description of the payment.</param>
        /// <param name="payerReference">Refence to the payer in the merchant systems.</param>
        /// <param name="userAgent">The UserAgent string of the payers device.</param>
        /// <param name="language">The payers prefered langauge.</param>
        /// <param name="urls">Object describing relevant URLs for this payment.</param>
        /// <param name="payeeInfo">Object holding information about the merchant-</param>
        /// <param name="prefillInfo">Known information about the payer than can be
        /// pre-filled in the payment window.</param>
        /// <param name="swishRequest">Sets Swish payment specific options.</param>
        protected internal SwishPaymentRequestDetails(string description,
                                                string payerReference,
                                                string userAgent,
                                                Language language,
                                                IUrls urls,
                                                PayeeInfo payeeInfo,
                                                PrefillInfo prefillInfo,
                                                SwishRequestData swishRequest)
        {
            Operation = Operation.Purchase;
            Intent = PaymentIntent.Sale;
            Currency = new Currency("SEK");
            Description = description;
            PayerReference = payerReference;
            UserAgent = userAgent;
            Language = language;
            Urls = urls;
            PayeeInfo = payeeInfo;
            PrefillInfo = prefillInfo;
            Swish = swishRequest;
        }

        /// <summary>
        /// SEK is the currency for Swish
        /// </summary>
        public Currency Currency { get; }

        /// <summary>
        /// A 40 character max length textual description of the purchase.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// <see cref="PaymentIntent.Sale"/> is the only allowed value for this request.
        /// </summary>
        public PaymentIntent Intent { get; }

        /// <summary>
        /// Sets the payers prefered language.
        /// </summary>
        public Language Language { get; }

        /// <summary>
        /// <see cref="Operation.Purchase"/> is the only allwoed value for this request.
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
        /// An object holding information which,
        /// when available, will be prefilled on the payment page.
        /// </summary>
        public PrefillInfo PrefillInfo { get; }

        /// <summary>
        /// Lists the prices related to a specific payment.
        /// </summary>
        public List<IPrice> Prices { get; set; } = new List<IPrice>();

        /// <summary>
        /// An object that holds different scenarios for Swish payments.
        /// </summary>
        public SwishRequestData Swish { get; }

        /// <summary>
        /// The urls resource lists urls that redirects users to relevant sites.
        /// </summary>
        public IUrls Urls { get; }

        /// <summary>
        /// The User-Agent string of the payer’s web browser.
        /// </summary>
        public string UserAgent { get; }

        /// <summary>
        /// Metadata can be used to store data associated to a payment that can be retrieved later by performing a GET on the payment.
        /// Swedbank Pay does not use or process metadata, it is only stored on the payment so it can be retrieved later alongside the payment.
        /// An example where metadata might be useful is when several internal systems are involved in the payment process and the payment
        /// creation is done in one system and post-purchases take place in another.
        /// In order to transmit data between these two internal systems,
        /// the data can be stored in metadata on the payment so the internal systems do not need to communicate with each other directly. 
        /// </summary>
        public Dictionary<string, object> Metadata { get; set; }
    }
}