using SwedbankPay.Sdk.PaymentOrders;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// Holds details about a card payment.
    /// </summary>
    public class CardPaymentDetails
    {
        /// <summary>
        /// Instantiates a new <see cref="CardPaymentDetails"/> with the provided parameters.
        /// </summary>
        /// <param name="operation">The <see cref="Sdk.Operation"/> to perform.</param>
        /// <param name="intent">The initial <seealso cref="Sdk.PaymentInstruments.PaymentIntent"/> of the payment.</param>
        /// <param name="currency">The <seealso cref="Sdk.Currency"/> to be paid in.</param>
        /// <param name="prices">A list of price objects.</param>
        /// <param name="description">A textual description of the purchase.</param>
        /// <param name="payerReference">The payer reference.</param>
        /// <param name="generatePaymentToken">Set if you want a payment token to be generated.</param>
        /// <param name="generateRecurrenceToken">Set if you want a recurrence token to be generated.</param>
        /// <param name="userAgent">The payers user agent.</param>
        /// <param name="language">The payers prefered langauge.</param>
        /// <param name="urls">URLs relevant for this payment.</param>
        /// <param name="payeeInfo">Identifies the merchant.</param>
        /// <param name="riskIndicator">Risk indicator details.</param>
        /// <param name="cardholder">Information about the card holder.</param>
        /// <param name="creditCard">Information about the credit card.</param>
        /// <param name="metadata">Any relevant meta data to be stored.</param>
        /// <param name="paymentToken">Set this to true if you want to create a paymentToken for future use as One Click.</param>
        public CardPaymentDetails(Operation operation,
                                                PaymentIntent intent,
                                                Currency currency,
                                                List<IPrice> prices,
                                                string description,
                                                string payerReference,
                                                bool generatePaymentToken,
                                                bool generateRecurrenceToken,
                                                string userAgent,
                                                Language language,
                                                IUrls urls,
                                                PayeeInfo payeeInfo,
                                                IRiskIndicator riskIndicator = null,
                                                Cardholder cardholder = null,
                                                CreditCard creditCard = null,
                                                Dictionary<string, object> metadata = null,
                                                string paymentToken = null)
        {
            Operation = operation ?? throw new ArgumentNullException(nameof(operation));
            Intent = intent;
            Currency = currency;
            Prices = prices;
            Description = description;
            PayerReference = payerReference;
            UserAgent = userAgent;
            Language = language;
            Urls = urls;
            PayeeInfo = payeeInfo;
            RiskIndicator = riskIndicator;
            Cardholder = cardholder;
            CreditCard = creditCard;
            Metadata = metadata;
            GeneratePaymentToken = generatePaymentToken;
            GenerateRecurrenceToken = generateRecurrenceToken;
            PaymentToken = paymentToken;
        }

        /// <summary>
        /// Cardholder object that can hold information about a buyer (private or company).
        /// The information added increases the chance for frictionless flow and is related to 3-D Secure 2.0.
        /// </summary>
        public Cardholder Cardholder { get; }

        /// <summary>
        /// Holds information about the credit card used.
        /// </summary>
        public CreditCard CreditCard { get; }

        /// <summary>
        /// The currency used to pay the payment.
        /// </summary>
        public Currency Currency { get; }

        /// <summary>
        /// Description about the current payment.
        /// Max length of 40 characters.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// When making the initial purchase request, you need to generate a paymentToken.
        /// You can do this either by by setting the GeneratePaymentToken field to true,
        /// or set the initial operation to Verify.
        /// </summary>
        public bool GeneratePaymentToken { get; }

        /// <summary>
        /// Set this to true if you want to create a recurrenceToken for future use Recurring purchases (subscription payments).
        /// </summary>
        public bool GenerateRecurrenceToken { get; }

        /// <summary>
        /// The intent of the payment
        /// </summary>
        public PaymentIntent Intent { get; }

        /// <summary>
        /// The payers prefered language.
        /// </summary>
        public Language Language { get; }

        /// <summary>
        /// The operation that the payment is supposed to perform
        /// </summary>
        public Operation Operation { get; }

        /// <summary>
        /// Information about the payee.
        /// Thats the merchant or corporation that initiated the payment.
        /// This is your info
        /// </summary>
        public PayeeInfo PayeeInfo { get; }

        /// <summary>
        /// The reference to the payer in the merchant system,
        /// like e-mail address, mobile number, customer number etc.
        /// </summary>
        public string PayerReference { get; }

        /// <summary>
        /// Set this to true if you want to create a paymentToken for future use as One Click.
        /// </summary>
        public string PaymentToken { get; }

        /// <summary>
        /// A list of <see cref="IPrice"/> objects.
        /// </summary>
        public List<IPrice> Prices { get; }

        /// <summary>
        /// This optional object consist of information that helps verifying the payer.
        /// Providing these fields decreases the likelyhood of having to promt for 3-D Secure 
        /// 2.0 authentication of the payer when they are authenticating the purchase.
        /// </summary>
        public IRiskIndicator RiskIndicator { get; }

        /// <summary>
        /// The URI to the urls resource where all URIs related to the payment can be retrieved
        /// </summary>
        public IUrls Urls { get; }

        /// <summary>
        /// The User-Agent string of the payer’s web browser
        /// https://en.wikipedia.org/wiki/User_agent
        /// </summary>
        public string UserAgent { get; }

        /// <summary>
        /// <seealso cref="Dictionary{TKey, TValue}"/> with arbitrary data provided
        /// by the merchant.
        /// </summary>
        public Dictionary<string, object> Metadata { get; }
    }
}