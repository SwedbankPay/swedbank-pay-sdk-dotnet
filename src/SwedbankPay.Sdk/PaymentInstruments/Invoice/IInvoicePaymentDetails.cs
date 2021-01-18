using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    /// <summary>
    /// Transactional details about a invoice payment.
    /// </summary>
    public interface IInvoicePaymentDetails
    {
        /// <summary>
        /// The amount (including VAT, if any) to charge the payer,
        /// entered in the monetary unit of the selected currency.
        /// </summary>
        Amount Amount { get; }

        /// <summary>
        /// The remaning <seealso cref="Sdk.Amount"/> to capture on this invoice.
        /// </summary>
        Amount RemainingCaptureAmount { get; }

        /// <summary>
        /// The remaning <seealso cref="Sdk.Amount"/> to cancel on this invoice.
        /// </summary>
        Amount RemainingCancellationAmount { get; }

        /// <summary>
        /// The remaning <seealso cref="Sdk.Amount"/> to reverse on this invoice.
        /// </summary>
        Amount RemainingReversalAmount { get; }

        /// <summary>
        /// Gets the available authorizations on this invoice.
        /// </summary>
        IInvoicePaymentAuthorizationListResponse Authorizations { get; }

        /// <summary>
        /// Gets the available cancellations on this invoice.
        /// </summary>
        ICancellationsListResponse Cancellations { get; }

        /// <summary>
        /// Gets the available captures on this invoice.
        /// </summary>
        ICapturesListResponse Captures { get; }

        /// <summary>
        /// The <seealso cref="DateTime"/> this invoice payment was created.
        /// </summary>
        DateTime Created { get; }

        /// <summary>
        /// The <seealso cref="DateTime"/> this invoice payment was last updated.
        /// </summary>
        DateTime Updated { get; }

        /// <summary>
        /// SEK, NOK, EUR etc
        /// </summary>
        Currency Currency { get; }

        /// <summary>
        /// A textual description of the transaction,
        /// as sent by merchant to Swedbank Pay.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// The relative URI and unique identifier of the Invoice
        /// </summary>
        Uri Id { get; }

        /// <summary>
        /// The payment instrument used to initiate or pay this invoice.
        /// </summary>
        PaymentInstrument Instrument { get; }

        /// <summary>
        /// The <seealso cref="PaymentIntent"/> of the request.
        /// </summary>
        PaymentIntent Intent { get; }

        /// <summary>
        /// Prefered <seealso cref="Sdk.Language"/> of the payer.
        /// </summary>
        Language Language { get; }

        /// <summary>
        /// The transaction number, useful when there’s need to reference the transaction in human communication.
        /// Not usable for programmatic identification of the transaction,
        /// where id should be used instead.
        /// </summary>
        long Number { get; }

        /// <summary>
        /// The operation you wish to perform on the Invoice.
        /// </summary>
        Operation Operation { get; }

        /// <summary>
        /// Information about the payee/merchant/corporation initing the payment.
        /// </summary>
        PayeeInfo PayeeInfo { get; }

        /// <summary>
        /// The reference to the payer from the merchant system,
        /// like e-mail address, mobile number, customer number etc.
        /// </summary>
        string PayerReference { get; }

        /// <summary>
        /// The user agent of the initiating system.
        /// </summary>
        string InitiatingSystemUserAgent { get; }

        /// <summary>
        /// The prices resource lists the prices related to this payment.
        /// </summary>
        IPricesListResponse Prices { get; }

        /// <summary>
        /// Gets the available reversals on this invoice.
        /// </summary>
        IReversalsListResponse Reversals { get; }

        /// <summary>
        /// The current <seealso cref="Sdk.State"/> of the payment.
        /// </summary>
        State State { get; }

        /// <summary>
        /// Gets the available transactions on this invoice.
        /// </summary>
        ITransactionListResponse Transactions { get; }

        /// <summary>
        /// The <seealso cref="IUrls"/> used to initate this payment.
        /// </summary>
        IUrls Urls { get; }

        /// <summary>
        /// The payers user agent used to iniate the payment.
        /// </summary>
        string UserAgent { get; }

        /// <summary>
        /// Metadata sent in by the merchant for this payment.
        /// </summary>
        Metadata Metadata { get; }
    }
}