namespace SwedbankPay.Sdk.PaymentOrder.Models;

public class HistoryListItem
{
    public DateTime Created { get; }
    public string? Name { get; }
    public string? Instrument { get; }
    public long? Number { get; }
    public string? InitiatedBy { get; }
    public bool? Prefill { get; }

    internal HistoryListItem(HistoryListItemDto dto)
    {
        Created = dto.Created;
        Name = dto.Name;
        Instrument = dto.Instrument;
        Number = dto.Number;
        InitiatedBy = dto.InitiatedBy;
        Prefill = dto.Prefill;
    }
}