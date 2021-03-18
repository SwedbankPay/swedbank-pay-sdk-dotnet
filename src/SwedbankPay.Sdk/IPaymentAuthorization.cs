using SwedbankPay.Sdk.PaymentInstruments.Card;
using System;

namespace SwedbankPay.Sdk
{
    /// <summary>
    /// Contains information about a Card payment authorization.
    /// </summary>
    public interface IPaymentAuthorization : IIdentifiable
    {
        /// <summary>
        /// The System Trace Audit Number assigned by the acquirer to uniquely identify the transaction.
        /// </summary>
        public string AcquirerStan { get; }

        /// <summary>
        /// The ID of the acquirer terminal.
        /// </summary>
        public string AcquirerTerminalId { get; }

        /// <summary>
        /// 3DSECURE or SSL. Indicates the transaction type of the acquirer.
        /// </summary>
        public DateTime AcquirerTransactionTime { get; }

        /// <summary>
        /// 3DSECURE or SSL. Indicates the transaction type of the acquirer.
        /// </summary>
        public string AcquirerTransactionType { get; }

        /// <summary>
        /// Y, A, U or N. Indicates the status of the authentication.
        /// </summary>
        public string AuthenticationStatus { get; }

        /// <summary>
        /// Visa, MC, etc. The brand of the card.
        /// </summary>
        public string CardBrand { get; }

        /// <summary>
        /// Credit Card or Debit Card. Indicates the type of card used for the authorization.
        /// </summary>
        public string CardType { get; }

        /// <summary>
        /// The country the card is issued in.
        /// </summary>
        public string CountryCode { get; }

        /// <summary>
        /// The type of the authorization.
        /// </summary>
        public bool Direct { get; }

        /// <summary>
        /// The month and year of when the card expires.
        /// Format: mm/yyyy
        /// </summary>
        public string ExpiryDate { get; }

        /// <summary>
        /// Result of external tokenization.
        /// This value varies depending on cards, acquirer, customer, etc.
        /// For ICA cards, the token comes in response from Swedbank.
        /// For Mass Transit(SL) it is populated with PAR if it comes in response from the redeemer (Visa).
        /// If not, our own token (Mastercard / Amex).
        /// </summary>
        public string ExternalNonPaymentToken { get; }

        /// <summary>
        /// 
        /// </summary>
        public string ExternalSiteId { get; }

        /// <summary>
        /// 
        /// </summary>
        public string IssuerAuthorizationApprovalCode { get; }

        /// <summary>
        /// The name of the bank that issued the card used for the authorization.
        /// </summary>
        public string IssuingBank { get; }

        /// <summary>
        /// The masked PAN number of the card.
        /// </summary>
        public string MaskedPan { get; }

        /// <summary>
        /// Result of our own tokenization of the card used. Activated in POS on merchant or merchant group.
        /// </summary>
        public string NonPaymentToken { get; }

        /// <summary>
        /// The token representing the specific PAN of the card.
        /// </summary>
        public string PanToken { get; }

        /// <summary>
        /// The payment token created for the card used in the authorization.
        /// </summary>
        public string PaymentToken { get; }

        /// <summary>
        /// The created recurrenceToken, if <seealso cref="Operation.Verify"/>, <seealso cref="Operation.Recur"/> or "generateRecurrenceToken = true" was used.
        /// </summary>
        public string RecurrenceToken { get; }

        /// <summary>
        /// The transaction object, containing information about the current transaction.
        /// </summary>
        public ICardPaymentCardDetails Transaction { get; }

        /// <summary>
        /// 
        /// </summary>
        public string TransactionInitiator { get; }
    }
}