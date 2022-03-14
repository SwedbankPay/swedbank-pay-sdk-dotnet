using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    /// <summary>
    /// Object describing a Mobile Pay payment.
    /// </summary>
    public class MobilePayPaymentRequest
    {
        /// <summary>
        /// Instantiates a new <see cref="MobilePayPaymentRequest"/> with the provided parameters.
        /// </summary>
        /// <param name="operation">The initial API operation for this payment.</param>
        /// <param name="intent">The initial <seealso cref="PaymentIntent"/> for this payment.</param>
        /// <param name="currency">The wanted <seealso cref="Currency"/> for this payment.</param>
        /// <param name="prices">Object describing the amount to pay in different payment instruments.</param>
        /// <param name="description">A textual description of this payment.</param>
        /// <param name="urls">Object describing relevant URLs for this payment.</param>
        /// <param name="payeeInfo">Information about the merchant performing this payment.</param>
        /// <param name="shopslogoUrl">Custom logo to use for the payment window.</param>
        public MobilePayPaymentRequest(Operation operation,
                                       PaymentIntent intent,
                                       Currency currency,
                                       IEnumerable<IPrice> prices,
                                       string description,
                                       Language language,
                                       IUrls urls,
                                       IPayeeInfo payeeInfo,
                                       Uri shopslogoUrl) : this(operation, intent, currency, prices, description, null, language, urls, payeeInfo, shopslogoUrl)

        {
        }


        /// <summary>
        /// Instantiates a new <see cref="MobilePayPaymentRequest"/> with the provided parameters.
        /// </summary>
        /// <param name="operation">The initial API operation for this payment.</param>
        /// <param name="intent">The initial <seealso cref="PaymentIntent"/> for this payment.</param>
        /// <param name="currency">The wanted <seealso cref="Currency"/> for this payment.</param>
        /// <param name="prices">Object describing the amount to pay in different payment instruments.</param>
        /// <param name="description">A textual description of this payment.</param>
        /// <param name="userAgent">The payers UserAgent string.</param>
        /// <param name="language">The payers preferred <seealso cref="Sdk.Language"/>.</param>
        /// <param name="urls">Object describing relevant URLs for this payment.</param>
        /// <param name="payeeInfo">Information about the merchant performing this payment.</param>
        /// <param name="shopslogoUrl">Custom logo to use for the payment window.</param>
        public MobilePayPaymentRequest(Operation operation,
                          PaymentIntent intent,
                          Currency currency,
                          IEnumerable<IPrice> prices,
                          string description,
                          string userAgent,
                          Language language,
                          IUrls urls,
                          IPayeeInfo payeeInfo,
                          Uri shopslogoUrl)

        {
            Payment = new MobilePayPaymentDetails(operation, intent, currency, prices, description, userAgent, language, urls, payeeInfo);
            MobilePay = new MobilePayRequestData
            {
                ShoplogoUrl = shopslogoUrl
            };
        }

        /// <summary>
        /// Information about the payment to be created.
        /// </summary>
        public IMobilePayPaymentDetails Payment { get; }

        /// <summary>
        /// MobilePay specific payment data, making a custom logo for the merchant available.
        /// </summary>
        public MobilePayRequestData MobilePay { get; }
    }
}
