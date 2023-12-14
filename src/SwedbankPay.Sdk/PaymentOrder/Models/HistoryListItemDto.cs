namespace SwedbankPay.Sdk.PaymentOrder.Models;

internal record HistoryListItemDto
{
    public DateTime Created { get; set; }
    public string? Name { get; set; }
    public string? Instrument { get; set; }
    public long? Number { get; set; }
    public string? InitiatedBy { get; set; }
    public bool? Prefill { get; set; }

    public HistoryListItem Map()
    {
        return new HistoryListItem(this);
    }
}