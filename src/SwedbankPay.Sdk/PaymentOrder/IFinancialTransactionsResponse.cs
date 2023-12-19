namespace SwedbankPay.Sdk.PaymentOrder;

public interface IFinancialTransactionsResponse
{
    IList<IFinancialTransactionListItem>? FinancialTransactionsList { get; }
}