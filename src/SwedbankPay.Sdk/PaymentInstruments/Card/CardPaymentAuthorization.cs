using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// Holds details on a card payment being authorized.
    /// </summary>
    public class CardPaymentAuthorization : Identifiable, ICardPaymentAuthorization
    {
        /// <summary>
        /// Instantiates a new <seealso cref="CardPaymentAuthorization"/> with the provided parameters.
        /// </summary>
        /// <param name="direct"></param>
        /// <param name="paymentToken"></param>
        /// <param name="recurrenceToken"></param>
        /// <param name="maskedPan"></param>
        /// <param name="expiryDate"></param>
        /// <param name="panToken"></param>
        /// <param name="cardBrand"></param>
        /// <param name="cardType"></param>
        /// <param name="issuingBank"></param>
        /// <param name="countryCode"></param>
        /// <param name="acquirerTransactionType"></param>
        /// <param name="issuerAuthorizationApprovalCode"></param>
        /// <param name="acquirerStan"></param>
        /// <param name="acquirerTerminalId"></param>
        /// <param name="acquirerTransactionTime"></param>
        /// <param name="authenticationStatus"></param>
        /// <param name="nonPaymentToken"></param>
        /// <param name="externalNonPaymentToken"></param>
        /// <param name="externalSiteId"></param>
        /// <param name="transactionInitiator"></param>
        /// <param name="transaction"></param>
        /// <param name="id"></param>
        public CardPaymentAuthorization(bool direct,
                             string paymentToken,
                             string recurrenceToken,
                             string maskedPan,
                             string expiryDate,
                             string panToken,
                             string cardBrand,
                             string cardType,
                             string issuingBank,
                             string countryCode,
                             string acquirerTransactionType,
                             string issuerAuthorizationApprovalCode,
                             string acquirerStan,
                             string acquirerTerminalId,
                             DateTime acquirerTransactionTime,
                             string authenticationStatus,
                             string nonPaymentToken,
                             string externalNonPaymentToken,
                             string externalSiteId,
                             string transactionInitiator,
                             ICardPaymentCardDetails transaction,
                             Uri id)
        {
            Direct = direct;
            PaymentToken = paymentToken;
            RecurrenceToken = recurrenceToken;
            MaskedPan = maskedPan;
            ExpiryDate = expiryDate;
            PanToken = panToken;
            CardBrand = cardBrand;
            CardType = cardType;
            IssuingBank = issuingBank;
            CountryCode = countryCode;
            AcquirerTransactionType = acquirerTransactionType;
            IssuerAuthorizationApprovalCode = issuerAuthorizationApprovalCode;
            AcquirerStan = acquirerStan;
            AcquirerTerminalId = acquirerTerminalId;
            AcquirerTransactionTime = acquirerTransactionTime;
            AuthenticationStatus = authenticationStatus;
            NonPaymentToken = nonPaymentToken;
            ExternalNonPaymentToken = externalNonPaymentToken;
            ExternalSiteId = externalSiteId;
            TransactionInitiator = transactionInitiator;
            Transaction = transaction;
            Id = id;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string AcquirerStan { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string AcquirerTerminalId { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public DateTime AcquirerTransactionTime { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string AcquirerTransactionType { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string AuthenticationStatus { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string CardBrand { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string CardType { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string CountryCode { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public bool Direct { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string ExpiryDate { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string ExternalNonPaymentToken { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string ExternalSiteId { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string IssuerAuthorizationApprovalCode { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string IssuingBank { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string MaskedPan { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string NonPaymentToken { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string PanToken { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string PaymentToken { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string RecurrenceToken { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ICardPaymentCardDetails Transaction { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string TransactionInitiator { get; }
    }
}