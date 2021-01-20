using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// Transactional details about a credit card authorization.
    /// </summary>
    public interface ICardPaymentAuthorization : IIdentifiable
    {
        /// <summary>
        /// The System Trace Audit Number assigned by the acquirer to uniquely identify the transaction
        /// </summary>
        string AcquirerStan { get; }

        /// <summary>
        /// The ID of the acquirer terminal
        /// </summary>
        string AcquirerTerminalId { get; }

        /// <summary>
        /// The ISO-8601 <seealso cref="DateTime"/> of the acquirer transaction
        /// </summary>
        DateTime AcquirerTransactionTime { get; }

        /// <summary>
        /// 3DSECURE or SSL.
        /// Indicates the transaction type of the acquirer
        /// </summary>
        string AcquirerTransactionType { get; }

        /// <summary>
        /// Y, A, U or N
        /// Indicates the status of the authentication
        /// </summary>
        string AuthenticationStatus { get; }

        /// <summary>
        /// Visa, MC, etc.
        /// The brand of the card
        /// </summary>
        string CardBrand { get; }

        /// <summary>
        /// Credit Card or Debit Card
        /// Indicates the type of card used for the authorization.
        /// </summary>
        string CardType { get; }

        /// <summary>
        /// The country the card is issued in
        /// </summary>
        string CountryCode { get; }

        /// <summary>
        /// The type of the authorization
        /// </summary>
        bool Direct { get; }

        /// <summary>
        /// The month and year of when the card expires
        /// Format: MM/YY
        /// </summary>
        string ExpiryDate { get; }

        /// <summary>
        /// Result of external tokenization.
        /// This value varies depending on cards, acquirer, customer, etc.
        /// For ICA cards, the token comes in response from Swedbank.
        /// For Mass Transit(SL) it is populated with PAR if it comes in response from the redeemer (Visa).
        /// If not, token stored by SwedbankPay (Mastercard / Amex)
        /// </summary>
        string ExternalNonPaymentToken { get; }

        /// <summary>
        /// ID of the external site.
        /// </summary>
        string ExternalSiteId { get; }

        /// <summary>
        /// Code given from authorization issuer for the approval.
        /// </summary>
        string IssuerAuthorizationApprovalCode { get; }

        /// <summary>
        /// The name of the bank that issued the card used for the authorization
        /// </summary>
        string IssuingBank { get; }

        /// <summary>
        /// The masked PAN number of the card
        /// </summary>
        string MaskedPan { get; }

        /// <summary>
        /// Result of Swedbank Pay tokenizing the PAN of the card used
        /// </summary>
        string NonPaymentToken { get; }

        /// <summary>
        /// The token representing the specific PAN of the card
        /// </summary>
        string PanToken { get; }

        /// <summary>
        /// The payment token created for the card used in the authorization
        /// </summary>
        string PaymentToken { get; }

        /// <summary>
        /// The created recurrenceToken, if operation: Verify, operation: Recur or generateRecurrenceToken: true was used.
        /// </summary>
        string RecurrenceToken { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        ICardPaymentCardDetails Transaction { get; }

        /// <summary>
        /// Hints to who initiated the transaction.
        /// </summary>
        string TransactionInitiator { get; }
    }
}