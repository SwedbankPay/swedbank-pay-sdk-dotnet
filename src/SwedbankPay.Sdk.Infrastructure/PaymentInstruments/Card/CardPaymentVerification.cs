namespace SwedbankPay.Sdk.PaymentInstruments.Card;

internal class CardPaymentVerification : Identifiable, ICardPaymentVerification
{
    public CardPaymentVerification(CardPaymentVerificationDto dto)
        : base(dto.Id)
    {
        PaymentToken = dto.PaymentToken;
        RecurrenceToken = dto.RecurrenceToken;
        MaskedPan = dto.MaskedPan;
        ExpiryDate = dto.ExpiryDate;
        PanToken = dto.PanToken;
        CardBrand = dto.CardBrand;
        CardType = dto.CardType;
        IsOperational = dto.IsOperational;

        if(dto.Transaction != null)
        {
            Transaction = new VerifyTransaction(dto.Transaction);
        }
        
        Problem = dto.Problem?.Map();
    }

    public string CardBrand { get; }
    public string CardType { get; }
    public string PaymentToken { get; }
    public string RecurrenceToken { get; }
    public string MaskedPan { get; }
    public string ExpiryDate { get; }
    public string PanToken { get; }
    public IVerifyTransaction Transaction { get; }
    public bool IsOperational { get; }
    public IProblem Problem { get; }
}