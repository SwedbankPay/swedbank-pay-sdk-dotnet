using SwedbankPay.Sdk.PaymentInstruments.Card;
using System;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    internal class PaymentAuthorization : IPaymentAuthorization
    {
        public PaymentAuthorization(PaymentAuthorizationDto dto)
        {
            AcquirerStan = dto.AcquirerStan;
            AcquirerTerminalId = dto.AcquirerTerminalId;
            AcquirerTransactionTime = dto.AcquirerTransactionTime;
            AcquirerTransactionType = dto.AcquirerTransactionType;
            AuthenticationStatus = dto.AuthenticationStatus;
            CardBrand = dto.CardBrand;
            CardType = dto.CardType;
            CountryCode = dto.CountryCode;
            Direct = dto.Direct;
            ExpiryDate = dto.ExpiryDate;
            ExternalNonPaymentToken = dto.ExternalNonPaymentToken;
            ExternalSiteId = dto.ExternalSiteId;
            IssuerAuthorizationApprovalCode = dto.IssuerAuthorizationApprovalCode;
            IssuingBank = dto.IssuingBank;
            MaskedPan = dto.MaskedPan;
            NonPaymentToken = dto.NonPaymentToken;
            PanToken = dto.PanToken;
            PaymentToken = dto.PaymentToken;
            RecurrenceToken = dto.RecurrenceToken;
            Transaction = dto.Transaction.Map();
            TransactionInitiator = dto.TransactionInitiator;
            Id = new Uri(dto.Id, UriKind.RelativeOrAbsolute);
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
        public ICardPaymentCardDetails Transaction { get; }
        public string TransactionInitiator { get; }
        public Uri Id { get; }

    }
}