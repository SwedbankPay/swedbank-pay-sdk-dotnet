namespace SwedbankPay.Sdk.PaymentOrder.Models;

internal record FinancialTransactionsResponseDto : IdentifiableDto
{
    public IList<FinancialTransactionListItemDto>? FinancialTransactionsList { get; init; }

    public FinancialTransactionsResponseDto(string id) : base(id)
    {
    }

    public FinancialTransactionsResponse Map()
    {
        return new FinancialTransactionsResponse(this);
    }
}