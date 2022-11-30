using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders;

/// <summary>
/// Transactional details for creating a payment order.
/// </summary>
public class PaymentOrderRequestDetails
{
    /// <summary>
    /// Request details for creating a payment order.
    /// </summary>
    /// <param name="operation">Initial API operation to perform.</param>
    /// <param name="currency">The wanted currency for the payment.</param>
    /// <param name="amount">The amount to pay in the payment.</param>
    /// <param name="vatAmount">The amount to pay that is value added taxes.</param>
    /// <param name="description">Textual description of the payment order.</param>
    /// <param name="userAgent">The payers UserAgent string.</param>
    /// <param name="language">The payers preferred language.</param>
    /// <param name="generateRecurrenceToken">Set if you want a recurrence token for recur payments.</param>
    /// <param name="urls">Object with URLs relevant for the payment.</param>
    /// <param name="payeeInfo">Object with information about the Merchant.</param>
    protected internal PaymentOrderRequestDetails(Operation operation,
                                                 Currency currency,
                                                 Amount amount,
                                                 Amount vatAmount,
                                                 string description,
                                                 string userAgent,
                                                 Language language,
                                                 bool generateRecurrenceToken,
                                                 IUrls urls,
                                                 IPayeeInfo payeeInfo)
    {
        Operation = operation ?? throw new ArgumentNullException(nameof(operation));
        Currency = currency ?? throw new ArgumentNullException(nameof(currency));
        Amount = amount ?? throw new ArgumentNullException(nameof(amount));
        VatAmount = vatAmount ?? throw new ArgumentNullException(nameof(vatAmount));
        Description = description ?? throw new ArgumentNullException(nameof(description));
        UserAgent = userAgent ?? throw new ArgumentNullException(nameof(userAgent));
        Language = language ?? throw new ArgumentNullException(nameof(language));
        Urls = urls ?? throw new ArgumentNullException(nameof(urls));
        GenerateRecurrenceToken = generateRecurrenceToken;
        PayeeInfo = payeeInfo;
    }


    /// <summary>
    ///     The amount including VAT in the lowest monetary unit of the currency. E.g. 10000 equals 100.00 NOK and 5000 equals
    ///     50.00 NOK.
    /// </summary>
    public Amount Amount { get; }

    /// <summary>
    ///     The currency of the payment.
    /// </summary>
    public Currency Currency { get; }

    /// <summary>
    ///     The description of the payment order.
    /// </summary>
    public string Description { get; }

    /// <summary>
    ///     Determines if a recurrence token should be generated. A recurrence token is primarily used to enable future
    ///     recurring payments - with the same token - through server-to-server calls. Default value is false
    /// </summary>
    public bool GenerateRecurrenceToken { get; }

    /// <summary>
    ///     The array of items that will affect how the payment is performed.
    /// </summary>
    public IList<PaymentOrderPaymentOptionsItems> Items { get; set; }

    /// <summary>
    ///     The language of the payer.
    /// </summary>
    public Language Language { get; }

    /// <summary>
    ///     The keys and values that should be associated with the payment order. Can be additional identifiers and data you
    ///     want to associate with the payment.
    /// </summary>
    public Metadata Metadata { get; set; }

    /// <summary>
    ///     The operation that the payment order is supposed to perform.
    /// </summary>
    public Operation Operation { get; }

    /// <summary>
    ///     The array of items being purchased with the order. Used to print on invoices if the payer chooses to pay with
    ///     invoice, among other things.
    /// </summary>
    public IList<IOrderItem> OrderItems { get; set; } = new List<IOrderItem>();

    /// <summary>
    ///     Information about the payee of the payment order
    /// </summary>
    public IPayeeInfo PayeeInfo { get; }

    /// <summary>
    ///     Information about the payee of the payment order
    /// </summary>
    public Payer Payer { get; set; }

    /// <summary>
    /// Information about risk indicator
    /// </summary>
    public IRiskIndicator RiskIndicator { get; set; }

    /// <summary>
    ///     The urls property of the paymentOrder contains the URIs related to a payment order, including where the consumer
    ///     gets redirected when going forward
    ///     with or cancelling a payment session, as well as the callback URI that is used to inform the payee (merchant) of
    ///     changes or updates made to underlying payments or transaction.
    /// </summary>
    public IUrls Urls { get; }

    /// <summary>
    ///     The user agent of the payer.
    /// </summary>
    public string UserAgent { get; }

    /// <summary>
    ///     The amount of VAT in the lowest monetary unit of the currency. E.g. 10000 equals 100.00 NOK and 5000 equals 50.00
    ///     NOK.
    /// </summary>
    public Amount VatAmount { get; }

    /// <summary>
    /// If set to true, disables the frame around the payment menu. Usefull when only showing one payment instrument.
    /// </summary>
    public bool? DisablePaymentMenu { get; set; }
}