using SwedbankPay.Sdk.PaymentOrder;
using SwedbankPay.Sdk.PaymentOrder.Cancelled;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Cancelled;

internal record CancelledResponse : Identifiable, ICancelledResponse
{
    public string? CancelReason { get; }
    public string? Instrument { get; }
    public long Number { get; }
    public string? PayeeReference { get; }
    public string? OrderReference { get; }
    public string? TransactionType { get; }
    public Amount Amount { get; }
    public Amount SubmittedAmount { get; }
    public Amount FeeAmount { get; }
    public Amount DiscountAmount { get; }
    public IList<IRecurringTokenItem>? Tokens { get; }
    public ICancelledDetails? Details { get; }

    internal CancelledResponse(CancelledResponseDto dto) : base(dto.Id)
    {
        CancelReason = dto.CancelReason;
        Instrument = dto.Instrument;
        Number = dto.Number;
        PayeeReference = dto.PayeeReference;
        OrderReference = dto.OrderReference;
        TransactionType = dto.TransactionType;
        Amount= dto.Amount;
        SubmittedAmount = dto.SubmittedAmount;
        FeeAmount = dto.FeeAmount;
        DiscountAmount = dto.DiscountAmount;
        Tokens = dto.Tokens?.Select(x => x.Map()).ToList();
        Details = dto.Details?.Map();
    }
}