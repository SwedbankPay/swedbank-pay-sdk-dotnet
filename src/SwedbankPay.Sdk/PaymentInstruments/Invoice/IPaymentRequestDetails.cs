using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice;

/// <summary>
/// Transactional details for creating a invoice payment.
/// </summary>
public interface IPaymentRequestDetails
{
    /// <summary>
    /// The currency code for this invoice.
    /// </summary>
    Currency Currency { get; }

    /// <summary>
    /// A 40 character length textual description of the purchase.
    /// </summary>
    string Description { get; }

    /// <summary>
    /// Set this to true if you want to create a paymentToken for future use as One Click.
    /// </summary>
    bool GeneratePaymentToken { get; }

    /// <summary>
    /// Set this to true if you want to create a recurrenceToken for future use Recurring purchases (subscription payments).
    /// </summary>
    bool GenerateRecurrenceToken { get; }

    /// <summary>
    /// The initial intent of the invoice request.
    /// </summary>
    PaymentIntent Intent { get; }

    /// <summary>
    /// The prefered langauge of the payer.
    /// </summary>
    Language Language { get; }

    /// <summary>
    /// FinancingConsumer
    /// </summary>
    Operation Operation { get; }

    /// <summary>
    /// Identifies the merchant that initiated the payment.
    /// </summary>
    IPayeeInfo PayeeInfo { get; }

    /// <summary>
    /// The reference to the payer from the merchant system, like e-mail address, mobile number, customer number etc.
    /// </summary>
    string PayerReference { get; }

    /// <summary>
    /// If a paymentToken is included in the request,
    /// the card details stored in the paymentToken will be prefilled on the payment page.
    /// The payer still has to enter the cvc to complete the purchase.
    /// This is called a “One Click” purchase.
    /// </summary>
    string PaymentToken { get; }

    /// <summary>
    /// The payers MSISDN if known, fills out relevant payment menthods to make the payment flow more seamless.
    /// </summary>
    PrefillInfo PrefillInfo { get; }

    /// <summary>
    /// List of <seealso cref="IPrice"/> objects showing the amount to be paid with each payment instrument.
    /// </summary>
    IList<IPrice> Prices { get; }

    /// <summary>
    /// The <seealso cref="IUrls"/> this payment supports.
    /// </summary>
    IUrls Urls { get; }

    /// <summary>
    /// The payers UserAgent string.
    /// </summary>
    string UserAgent { get; }

    /// <summary>
    /// Metadata sent in by the merchant.
    /// Not processed or used by SwedbankPay.
    /// </summary>
    Metadata Metadata { get; set; }
}