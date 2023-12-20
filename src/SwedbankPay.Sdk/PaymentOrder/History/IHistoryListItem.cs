namespace SwedbankPay.Sdk.PaymentOrder.History;

public interface IHistoryListItem
{
    public DateTime Created { get; }
    public string? Name { get; }
    public string? Instrument { get; }
    public long? Number { get; }
    public string? InitiatedBy { get; }
    public bool? Prefill { get; }
}