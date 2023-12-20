using SwedbankPay.Sdk.PaymentOrder.FinancialTransactions;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.FinancialTransactions;

internal record FinancialTransactionsResponse : Identifiable, IFinancialTransactionsResponse
{
    public IList<IFinancialTransactionListItem>? FinancialTransactionsList { get; }
    
    internal FinancialTransactionsResponse(FinancialTransactionsResponseDto dto) : base(dto.Id)
    {
        FinancialTransactionsList = dto.FinancialTransactionsList?.Select(x => x.Map()).ToList();
    }
}