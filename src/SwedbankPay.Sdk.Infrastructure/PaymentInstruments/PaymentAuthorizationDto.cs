﻿using SwedbankPay.Sdk.PaymentInstruments.Card;
using System;

namespace SwedbankPay.Sdk.PaymentInstruments;

internal class PaymentAuthorizationDto
{
    public string AcquirerStan { get; set; }
    public string AcquirerTerminalId { get; set; }
    public DateTime AcquirerTransactionTime { get; set; }
    public string AcquirerTransactionType { get; set; }
    public string AuthenticationStatus { get; set; }
    public string CardBrand { get; set; }
    public string CardType { get; set; }
    public string CountryCode { get; set; }
    public bool Direct { get; set; }
    public string ExpiryDate { get; set; }
    public string ExternalNonPaymentToken { get; set; }
    public string ExternalSiteId { get; set; }
    public string IssuerAuthorizationApprovalCode { get; set; }
    public string IssuingBank { get; set; }
    public string MaskedPan { get; set; }
    public string NonPaymentToken { get; set; }
    public string PanToken { get; set; }
    public string PaymentToken { get; set; }
    public string RecurrenceToken { get; set; }
    public CardPaymentAuthorizationRequestTransactionDto Transaction { get; set; }
    public string TransactionInitiator { get; set; }
    public string Id { get; set; }

    internal IPaymentAuthorization Map()
    {
        return new PaymentAuthorization(this);
    }

    internal CardPaymentAuthorization MapToCard()
    {
        var uri = new Uri(Id, UriKind.RelativeOrAbsolute);
        return new CardPaymentAuthorization(Direct,
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
                                            Transaction?.Map(),
                                            uri);
    }
}