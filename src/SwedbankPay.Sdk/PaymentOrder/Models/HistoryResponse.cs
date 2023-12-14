namespace SwedbankPay.Sdk.PaymentOrder.Models;

public record HistoryResponse : Identifiable
{
    public IList<HistoryListItem>? HistoryList { get; }

    internal HistoryResponse(HistoryResponseDto dto) : base(dto.Id)
    {
        HistoryList = dto.HistoryList?.Select(x => x.Map()).ToList();
    }
}