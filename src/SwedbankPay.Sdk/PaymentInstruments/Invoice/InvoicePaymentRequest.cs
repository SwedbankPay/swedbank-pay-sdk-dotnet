using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class InvoicePaymentRequest
    {
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
                              bool GenerateRecurrenceToken = false,
                              string payerReference = null,
                              Dictionary<string, object> metadata = null,
                              string paymentToken = null,
                              PrefillInfo prefillInfo = null)
        {
            Payment = new InvoicePaymentRequestDetails(operation, intent, currency, prices, description, payerReference, generatePaymentToken,
                                               GenerateRecurrenceToken, userAgent, language, urls, payeeInfo,
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