using System.Collections.Generic;
using System.Globalization;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class InvoicePaymentRequest
    {
        public InvoicePaymentRequest(Operation operation,
                              PaymentIntent intent,
                              CurrencyCode currency,
                              List<IPrice> prices,
                              string description,
                              string userAgent,
                              Language language,
                              IUrls urls,
                              PayeeInfo payeeInfo,
                              InvoiceType invoiceType,
                              bool generatePaymentToken = false,
                              bool generateReccurenceToken = false,
                              string payerReference = null,
                              Dictionary<string, object> metadata = null,
                              string paymentToken = null,
                              PrefillInfo prefillInfo = null)
        {
            Payment = new PaymentRequestObject(operation, intent, currency, prices, description, payerReference, generatePaymentToken,
                                               generateReccurenceToken, userAgent, language, urls, payeeInfo,
                                               metadata, paymentToken, prefillInfo);
            Invoice = new InvoicePaymentRequestObject(invoiceType);
        }


        public IPaymentRequestObject Payment { get; }
        public IInvoicePaymentRequestObject Invoice { get; }
    }

}