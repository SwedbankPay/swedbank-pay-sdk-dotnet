using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.History;

internal record HistoryResponseDto : IdentifiableDto
{
    public IList<HistoryListItemDto>? HistoryList { get; init; }

    public HistoryResponseDto(string id) : base(id)
    {
    }

    public IHistoryResponse Map()
    {
        return new HistoryResponse(this);
    }
}