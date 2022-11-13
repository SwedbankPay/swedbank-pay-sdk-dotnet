﻿using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice;

/// <summary>
/// Object for storing a authorization request to the invoice API.
/// </summary>
public class InvoicePaymentAuthorizationRequest
{
    /// <summary>
    /// Instantiates a new <see cref="InvoicePaymentAuthorizationRequest"/>.
    /// </summary>
    /// <param name="operation">The initial API operation for this invoice request.</param>
    /// <param name="intent">The initial payment intent for this invoice.</param>
    /// <param name="currency">The <seealso cref="Currency"/> this payment will be paid in.</param>
    /// <param name="prices">A list of objects detailing price differences between different payment instruments.</param>
    /// <param name="description">A textual description of what is being paid.</param>
    /// <param name="userAgent">The payers UserAgent string.</param>
    /// <param name="language">The payers prefered <seealso cref="Language"/>.</param>
    /// <param name="urls">Object containing relevant URLs for this payment.</param>
    /// <param name="payeeInfo">Object with merchant information.</param>
    /// <param name="invoiceType">Specifies the invoice type, country, of the invoice.</param>
    public InvoicePaymentAuthorizationRequest(Operation operation,
                          PaymentIntent intent,
                          Currency currency,
                          IEnumerable<IPrice> prices,
                          string description,
                          string userAgent,
                          Language language,
                          IUrls urls,
                          IPayeeInfo payeeInfo,
                          InvoiceType invoiceType)
    {
        Payment = new InvoicePaymentRequestDetails(operation, intent, currency, prices, description, userAgent, language, urls, payeeInfo);
        Invoice = new InvoicePaymentRequestData(invoiceType);
    }

    /// <summary>
    /// Details needed to authorize this payment.
    /// </summary>
    public IPaymentRequestDetails Payment { get; }

    /// <summary>
    /// Request details about the invoice type.
    /// </summary>
    public IInvoiceDetails Invoice { get; }
}