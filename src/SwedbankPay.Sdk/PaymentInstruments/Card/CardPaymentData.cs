using SwedbankPay.Sdk.PaymentOrders;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentData
    {
        public CardPaymentData(Operation operation,
                                                PaymentIntent intent,
                                                CurrencyCode currency,
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
        public CurrencyCode Currency { get; }

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