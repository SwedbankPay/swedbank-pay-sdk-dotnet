namespace SwedbankPay.Sdk.PaymentOrder.FinancialTransactions;

public interface IFinancialTransactionsResponse
{
    IList<IFinancialTransactionListItem>? FinancialTransactionsList { get; }
}