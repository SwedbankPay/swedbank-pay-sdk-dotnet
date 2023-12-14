namespace SwedbankPay.Sdk.PaymentOrder.Models;

internal record HistoryListItemDto
{
    public DateTime Created { get; init; }
    public string? Name { get; init; }
    public string? Instrument { get; init; }
    public long? Number { get; init; }
    public string? InitiatedBy { get; init; }
    public bool? Prefill { get; init; }

    public HistoryListItem Map()
    {
        return new HistoryListItem(this);
    }
}