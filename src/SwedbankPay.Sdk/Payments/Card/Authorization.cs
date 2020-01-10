using System;

namespace SwedbankPay.Sdk.Payments.Card
{
    public class Authorization : IdLink
    {
        public Authorization(bool direct, string paymentToken, string recurrenceToken, string maskedPan, string expiryDate, string panToken, string cardBrand, string cardType, string issuingBank, string countryCode, string acquirerTransactionType, string issuerAuthorizationApprovalCode, string acquirerStan, string acquirerTerminalId, DateTime acquirerTransactionTime, string authenticationStatus, string nonPaymentToken, string externalNonPaymentToken, string externalSiteId, string transactionInitiator, AuthorizationTransaction transaction)
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

        public bool Direct { get; }
        public string PaymentToken { get; }
        public string RecurrenceToken { get; }
        public string MaskedPan { get; }
        public string ExpiryDate { get; }
        public string PanToken { get; }
        public string CardBrand { get; }
        public string CardType { get; }
        public string IssuingBank { get; }
        public string CountryCode { get; }
        public string AcquirerTransactionType { get; }
        public string IssuerAuthorizationApprovalCode { get; }
        public string AcquirerStan { get; }
        public string AcquirerTerminalId { get; }
        public DateTime AcquirerTransactionTime { get; }
        public string AuthenticationStatus { get; }
        public string NonPaymentToken { get; }
        public string ExternalNonPaymentToken { get; }
        public string ExternalSiteId { get; }
        public string TransactionInitiator { get; }
        public AuthorizationTransaction Transaction { get; }
    }

    public class AuthorizationTransaction : IdLink
    {
        public AuthorizationTransaction(DateTime created, DateTime updated, string type, State state, string number, Amount amount, Amount vatAmount, string description, string payeeReference, string failedReason, string failedActivityName, string failedErrorCode, string failedErrorDescription, bool isOperational, ProblemResponse problem, OperationList operations)
        {
            Created = created;
            Updated = updated;
            Type = type;
            State = state;
            Number = number;
            Amount = amount;
            VatAmount = vatAmount;
            Description = description;
            PayeeReference = payeeReference;
            FailedReason = failedReason;
            FailedActivityName = failedActivityName;
            FailedErrorCode = failedErrorCode;
            FailedErrorDescription = failedErrorDescription;
            IsOperational = isOperational;
            Problem = problem;
            Operations = operations;
        }

        public DateTime Created { get; }
        public DateTime Updated { get; }
        public string Type { get; }
        public State State { get; }
        public string Number { get; }
        public Amount Amount { get; }
        public Amount VatAmount { get; }
        public string Description { get; }
        public string PayeeReference { get; }
        public string FailedReason { get; }
        public string FailedActivityName { get; }
        public string FailedErrorCode { get; }
        public string FailedErrorDescription { get; }
        public bool IsOperational { get; }
        public ProblemResponse Problem { get; }
        public OperationList Operations { get; }
    }
}