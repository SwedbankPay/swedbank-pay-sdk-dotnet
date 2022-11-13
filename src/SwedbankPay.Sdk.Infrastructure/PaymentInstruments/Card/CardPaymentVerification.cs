namespace SwedbankPay.Sdk.PaymentInstruments.Card;

using System;

internal class CardPaymentVerification : Identifiable, ICardPaymentVerification
{
    public CardPaymentVerification(VerificationDto dto)
        : base(dto.Id)
    {
        Direct = dto.Direct;
        CardBrand = dto.CardBrand;
        CardType = dto.CardType;
        IssuingBank = dto.IssuingBank;
        RecurrenceToken = dto.RecurrenceToken;
        MaskedPan = dto.MaskedPan;
        ExpiryDate = dto.ExpiryDate;
        PanToken = dto.PanToken;
        PanEnrolled = dto.PanEnrolled;
        IssuerAuthorizationApprovalCode = dto.IssuerAuthorizationApprovalCode;
        AcquirerTransactionType = dto.AcquirerTransactionType;
        AcquirerStan = dto.AcquirerStan;
        AcquirerTerminalId = dto.AcquirerTerminalId;
        AcquirerTransactionTime = dto.AcquirerTransactionTime;
        NonPaymentToken = dto.NonPaymentToken;
        TransactionInitiator = dto.TransactionInitiator;
        
        PaymentToken = dto.PaymentToken;
        IsOperational = dto.IsOperational;

        if(dto.Transaction != null)
        {
            Transaction = new VerifyTransaction(dto.Transaction);
        }
        
        Problem = dto.Problem?.Map();
    }

    public bool Direct { get; }
    public string CardBrand { get; }
    public string CardType { get; }
    public string IssuingBank { get; }
    public string PaymentToken { get; }
    public string RecurrenceToken { get; }
    public string MaskedPan { get; }
    public string ExpiryDate { get; }
    public string PanToken { get; }
    public bool PanEnrolled { get; }
    public string IssuerAuthorizationApprovalCode { get; }
    public string AcquirerTransactionType { get; set; }
    public string AcquirerStan { get; set; }
    public string AcquirerTerminalId { get; set; }
    public DateTime AcquirerTransactionTime { get; set; }
    public string NonPaymentToken { get; set; }
    public string TransactionInitiator { get; set; }


    public IVerifyTransaction Transaction { get; }
    public bool IsOperational { get; }
    public IProblem Problem { get; }
}