using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentAuthorizationDto
    {
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
        public string TransactionInitiator { get; }
        public CardPaymentAuthorizationRequestTransactionDto Transaction { get; }
        
        public CardPaymentAuthorization Map()
        {
            return new CardPaymentAuthorization(
                Direct,
                PaymentToken,
                RecurrenceToken,
                MaskedPan,
                ExpiryDate,
                PanToken,
                CardBrand,
                CardType,
                IssuingBank,
                CountryCode,
                AcquirerTransactionType,
                IssuerAuthorizationApprovalCode,
                AcquirerStan,
                AcquirerTerminalId,
                AcquirerTransactionTime,
                AuthenticationStatus,
                NonPaymentToken,
                ExternalNonPaymentToken,
                ExternalSiteId,
                TransactionInitiator,
                Transaction.Map());
        }
    }
}