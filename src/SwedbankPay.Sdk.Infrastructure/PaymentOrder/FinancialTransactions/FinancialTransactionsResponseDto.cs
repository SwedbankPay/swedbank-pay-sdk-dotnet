using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.FinancialTransactions;

internal record FinancialTransactionsResponseDto : IdentifiableDto
{
    public IList<FinancialTransactionListItemDto>? FinancialTransactionsList { get; init; }

    public FinancialTransactionsResponseDto(string id) : base(id)
    {
    }

    public IFinancialTransactionsResponse Map()
    {
        return new FinancialTransactionsResponse(this);
    }
}