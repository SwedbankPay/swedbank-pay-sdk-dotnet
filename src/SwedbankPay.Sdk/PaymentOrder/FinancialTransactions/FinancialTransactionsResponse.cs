namespace SwedbankPay.Sdk.PaymentOrder.FinancialTransactions;

public record FinancialTransactionsResponse : Identifiable
{
    public IList<FinancialTransactionListItem>? FinancialTransactionsList { get; }
    
    internal FinancialTransactionsResponse(FinancialTransactionsResponseDto dto) : base(dto.Id)
    {
        FinancialTransactionsList = dto.FinancialTransactionsList?.Select(x => x.Map()).ToList();
    }
}