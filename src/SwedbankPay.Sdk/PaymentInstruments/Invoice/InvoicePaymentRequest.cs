using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    /// <summary>
    /// Object containing data needed for creating a invoice payment.
    /// </summary>
    public class InvoicePaymentRequest
    {
        /// <summary>
        /// Instantiates a <see cref="InvoicePaymentRequest"/> with the provided parameters.
        /// </summary>
        /// <param name="operation">The initial API operation for this invoice request.</param>
        /// <param name="intent">The initial payment intent for this invoice.</param>
        /// <param name="currency">The <seealso cref="Currency"/> this payment will be paid in.</param>
        /// <param name="prices">A list of objects detailing price differences between different payment instruments.</param>
        /// <param name="description">A textual description of what is being paid.</param>
        /// <param name="userAgent">The payers UserAgent string.</param>
        /// <param name="language">The payers prefered <seealso cref="Sdk.Language"/>.</param>
        /// <param name="urls">Object containing relevant URLs for this payment.</param>
        /// <param name="payeeInfo">Object with merchant information.</param>
        /// <param name="invoiceType">Specifies the invoice type, country, of the invoice.</param>
        /// <param name="generatePaymentToken">Set if you want to generate a payment token for later use for this payment.</param>
        /// <param name="generateRecurrenceToken">Set if you want this to be a recurring payment.</param>
        /// <param name="payerReference">A transactionally unique payer reference from the merchant system.</param>
        /// <param name="metadata">Used to store meta data on the payment.</param>
        /// <param name="paymentToken">A previously generated payment token for this payment.</param>
        /// <param name="prefillInfo">Pre-fills the payment window with known information about the payer.</param>
        public InvoicePaymentRequest(Operation operation,
                              PaymentIntent intent,
                              Currency currency,
                              List<IPrice> prices,
                              string description,
                              string userAgent,
                              Language language,
                              IUrls urls,
                              PayeeInfo payeeInfo,
                              InvoiceType invoiceType,
                              bool generatePaymentToken = false,
                              bool generateRecurrenceToken = false,
                              string payerReference = null,
                              Dictionary<string, object> metadata = null,
                              string paymentToken = null,
                              PrefillInfo prefillInfo = null)
        {
            Payment = new InvoicePaymentRequestDetails(operation, intent, currency, prices, description, payerReference, generatePaymentToken,
                                               generateRecurrenceToken, userAgent, language, urls, payeeInfo,
                                               metadata, paymentToken, prefillInfo);
            Invoice = new InvoicePayment(invoiceType);
        }

        /// <summary>
        /// Request details about the current invoice payment.
        /// </summary>
        public IPaymentRequestDetails Payment { get; }

        /// <summary>
        /// Request details about the invoice type.
        /// </summary>
        public IInvoiceDetails Invoice { get; }
    }

}