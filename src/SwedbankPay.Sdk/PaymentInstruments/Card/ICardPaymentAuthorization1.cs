using System;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public interface ICardPaymentAuthorization1
    {
        string AcquirerStan { get; }
        string AcquirerTerminalId { get; }
        DateTime AcquirerTransactionTime { get; }
        string AcquirerTransactionType { get; }
        string AuthenticationStatus { get; }
        string CardBrand { get; }
        string CardType { get; }
        string CountryCode { get; }
        bool Direct { get; }
        string ExpiryDate { get; }
        string ExternalNonPaymentToken { get; }
        string ExternalSiteId { get; }
        string IssuerAuthorizationApprovalCode { get; }
        string IssuingBank { get; }
        string MaskedPan { get; }
        string NonPaymentToken { get; }
        string PanToken { get; }
        string PaymentToken { get; }
        string RecurrenceToken { get; }
        ICardPaymentAuthorizationRequestTransaction Transaction { get; }
        string TransactionInitiator { get; }
    }
}