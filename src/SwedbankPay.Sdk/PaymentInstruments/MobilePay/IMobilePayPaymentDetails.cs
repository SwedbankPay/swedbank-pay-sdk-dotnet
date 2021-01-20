using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    /// <summary>
    /// Transactional detail about a payment for Mobile Pay.
    /// </summary>
    public interface IMobilePayPaymentDetails
    {
        /// <summary>
        /// The currency code of the payment.
        /// </summary>
        Currency Currency { get; set; }

        /// <summary>
        /// A textual description of what the payment contains.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// The payment intent of the current payment.
        /// </summary>
        PaymentIntent Intent { get; set; }

        /// <summary>
        /// The prefered langauge of the payer.
        /// </summary>
        Language Language { get; set; }

        /// <summary>
        /// The <seealso cref="Sdk.Operation"/> used to initate this payment.
        /// </summary>
        Operation Operation { get; set; }

        /// <summary>
        /// Identifies the merchant that initiated the payment.
        /// </summary>
        PayeeInfo PayeeInfo { get; }

        /// <summary>
        /// The reference to the payer from the merchant system, like e-mail address, mobile number, customer number etc.
        /// </summary>
        string PayerReference { get; set; }

        /// <summary>
        /// Holds prefill information that can be inserted on the payment page.
        /// </summary>
        PrefillInfo PrefillInfo { get; set; }

        /// <summary>
        /// Lists the prices related to a specific payment.
        /// </summary>
        IList<IPrice> Prices { get; }

        /// <summary>
        /// The URI to the urls resource where all URIs related to the payment can be retrieved.
        /// </summary>
        IUrls Urls { get; }

        /// <summary>
        ///  	The user agent string of the payer’s browser.
        /// </summary>
        string UserAgent { get; set; }

        /// <summary>
        /// Metadata can be used to store data associated to a payment that can be retrieved later by performing a GET on the payment.
        /// Swedbank Pay does not use or process metadata, it is only stored on the payment so it can be retrieved later alongside the payment.
        /// An example where metadata might be useful is when several internal systems are involved in the payment process and the payment
        /// creation is done in one system and post-purchases take place in another.
        /// In order to transmit data between these two internal systems,
        /// the data can be stored in metadata on the payment so the internal systems do not need to communicate with each other directly.
        /// </summary>
        Metadata Metadata { get; }
    }
}