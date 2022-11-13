using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card;

internal class VerificationDto
{
    public bool Direct { get; set; }
    public string CardBrand { get; set; }
    public string CardType { get; set; }
    public string IssuingBank { get; set; }
    public string RecurrenceToken { get; set; }
    public string MaskedPan { get; set; }
    public string ExpiryDate { get; set; }
    public string PanToken { get; set; }
    public bool PanEnrolled { get; set; }
    public string IssuerAuthorizationApprovalCode { get; set; }
    public string AcquirerTransactionType { get; set; }
    public string AcquirerStan { get; set; } 
    public string AcquirerTerminalId { get; set; }
    public DateTime AcquirerTransactionTime { get; set; }
    public string NonPaymentToken { get; set; }
    public string TransactionInitiator { get; set; }
    public string Id { get; set; }
    public VerifyTransactionDto Transaction { get; set; }
    
    
    
    public string PaymentToken { get; set; }
    public bool IsOperational { get; set; }
    public ProblemDto Problem { get; set; }
}