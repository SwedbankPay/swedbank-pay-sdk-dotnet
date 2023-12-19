using SwedbankPay.Sdk.PaymentOrder;
using SwedbankPay.Sdk.PaymentOrder.Paid;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Paid;

internal record PaidResponse : Identifiable, IPaidResponse
{
    public string? Instrument { get; }
    public long Number { get; }
    public string? PayeeReference { get; }
    public TransactionType? TransactionType { get; }
    public Amount Amount { get; }
    public Amount SubmittedAmount { get; }
    public Amount FeeAmount { get; }
    public Amount DiscountAmount { get; }
    public IList<ITokenItem>? Tokens { get; }
    public IPaidDetails? Details { get; }

    internal PaidResponse(PaidResponseDto dto) : base(dto.Id)
    {
        Instrument = dto.Instrument;
        Number = dto.Number;
        PayeeReference = dto.PayeeReference;
        TransactionType = dto.TransactionType;
        Amount = new Amount(dto.Amount);
        SubmittedAmount = new Amount(dto.SubmittedAmount);
        FeeAmount = new Amount(dto.FeeAmount);
        DiscountAmount = new Amount(dto.DiscountAmount);
        Tokens = dto.Tokens?.Select(x => x.Map()).ToList();
        Details = dto.Details?.Map();
    }
}