namespace SwedbankPay.Sdk.PaymentOrder.Models;

internal record FinancialTransactionsResponseDto : IdentifiableDto
{
    public IList<FinancialTransactionListItemDto>? FinancialTransactionsList { get; set; }

    public FinancialTransactionsResponseDto(string id) : base(id)
    {
    }

    public FinancialTransactionsResponse Map()
    {
        return new FinancialTransactionsResponse(this);
    }
}