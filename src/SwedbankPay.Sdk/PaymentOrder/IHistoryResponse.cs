namespace SwedbankPay.Sdk.PaymentOrder;

public interface IHistoryResponse
{
    IList<IHistoryListItem>? HistoryList { get; }
}