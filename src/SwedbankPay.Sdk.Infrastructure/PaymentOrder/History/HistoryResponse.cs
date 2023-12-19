using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.History;

internal record HistoryResponse : Identifiable, IHistoryResponse
{
    public IList<IHistoryListItem>? HistoryList { get; }

    internal HistoryResponse(HistoryResponseDto dto) : base(dto.Id)
    {
        HistoryList = dto.HistoryList?.Select(x => x.Map()).ToList();
    }
}