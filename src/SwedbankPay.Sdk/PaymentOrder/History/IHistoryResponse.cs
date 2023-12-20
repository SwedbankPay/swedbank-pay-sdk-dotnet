namespace SwedbankPay.Sdk.PaymentOrder.History;

public interface IHistoryResponse
{
    IList<IHistoryListItem>? HistoryList { get; }
}