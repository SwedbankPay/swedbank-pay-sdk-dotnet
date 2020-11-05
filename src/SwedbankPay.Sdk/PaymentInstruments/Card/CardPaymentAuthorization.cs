using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentAuthorization : IdLink
    {
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
                             CardPaymentAuthorizationRequestTransaction transaction)
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
        }

        public string AcquirerStan { get; }
        public string AcquirerTerminalId { get; }
        public DateTime AcquirerTransactionTime { get; }
        public string AcquirerTransactionType { get; }
        public string AuthenticationStatus { get; }
        public string CardBrand { get; }
        public string CardType { get; }
        public string CountryCode { get; }

        public bool Direct { get; }
        public string ExpiryDate { get; }
        public string ExternalNonPaymentToken { get; }
        public string ExternalSiteId { get; }
        public string IssuerAuthorizationApprovalCode { get; }
        public string IssuingBank { get; }
        public string MaskedPan { get; }
        public string NonPaymentToken { get; }
        public string PanToken { get; }
        public string PaymentToken { get; }
        public string RecurrenceToken { get; }
        public CardPaymentAuthorizationRequestTransaction Transaction { get; }
        public string TransactionInitiator { get; }
    }
}