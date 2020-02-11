using System;

namespace SwedbankPay.Sdk.Payments.VippsPayments
{
    public class Authorization : IdLink
    {
        public Authorization(bool direct,
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
                             AuthorizationTransaction transaction)
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
        public AuthorizationTransaction Transaction { get; }
        public string TransactionInitiator { get; }
    }

    public class AuthorizationTransaction : IdLink
    {
        public AuthorizationTransaction(DateTime created,
                                        DateTime updated,
                                        string type,
                                        State state,
                                        string number,
                                        Amount amount,
                                        Amount vatAmount,
                                        string description,
                                        string payeeReference,
                                        string failedReason,
                                        string failedActivityName,
                                        string failedErrorCode,
                                        string failedErrorDescription,
                                        bool isOperational,
                                        ProblemResponse problem,
                                        OperationList operations)
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


        public Amount Amount { get; }

        public DateTime Created { get; }
        public string Description { get; }
        public string FailedActivityName { get; }
        public string FailedErrorCode { get; }
        public string FailedErrorDescription { get; }
        public string FailedReason { get; }
        public bool IsOperational { get; }
        public string Number { get; }
        public OperationList Operations { get; }
        public string PayeeReference { get; }
        public ProblemResponse Problem { get; }
        public State State { get; }
        public string Type { get; }
        public DateTime Updated { get; }
        public Amount VatAmount { get; }
    }
}