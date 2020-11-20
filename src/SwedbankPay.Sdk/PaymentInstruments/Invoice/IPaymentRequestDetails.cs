using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public interface IPaymentRequestDetails
    {
        /// <summary>
        /// The currency code for this invoice.
        /// </summary>
        Currency Currency { get; set; }

        /// <summary>
        /// A 40 character length textual description of the purchase.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Set this to true if you want to create a paymentToken for future use as One Click.
        /// </summary>
        bool GeneratePaymentToken { get; set; }

        /// <summary>
        /// Set this to true if you want to create a recurrenceToken for future use Recurring purchases (subscription payments).
        /// </summary>
        bool GenerateRecurrenceToken { get; set; }

        /// <summary>
        /// The initial intent of the invoice request.
        /// </summary>
        PaymentIntent Intent { get; set; }

        /// <summary>
        /// The prefered langauge of the payer.
        /// </summary>
        Language Language { get; set; }

        /// <summary>
        /// FinancingConsumer
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
        string PaymentToken { get; set; }

        /// <summary>
        /// The payers MSISDN if known, fills out relevant payment menthods to make the payment flow more seamless.
        /// </summary>
        PrefillInfo PrefillInfo { get; set; }

        /// <summary>
        /// List of <seealso cref="IPrice"/> objects showing the amount to be paid with each payment instrument.
        /// </summary>
        List<IPrice> Prices { get; set; }

        /// <summary>
        /// The <seealso cref="IUrls"/> this payment supports.
        /// </summary>
        IUrls Urls { get; }

        /// <summary>
        /// The payers UserAgent string.
        /// </summary>
        string UserAgent { get; set; }

        /// <summary>
        /// Metadata sent in by the merchant.
        /// Not processed or used by SwedbankPay.
        /// </summary>
        Dictionary<string, object> Metadata { get; }
    }
}