namespace SwedbankPay.Sdk.PaymentOrder.FinancialTransactions;

public class FinancialTransactionType : TypeSafeEnum<FinancialTransactionType>
{
    
    /// <summary>
    /// Type of transaction is Sale.
    /// </summary>
    public static readonly FinancialTransactionType Sale = new FinancialTransactionType(nameof(Sale), "Sale");
    
    /// <summary>
    /// Type of transaction is Capture.
    /// </summary>
    public static readonly FinancialTransactionType Capture = new FinancialTransactionType(nameof(Capture), "Capture");
    
    /// <summary>
    /// Type of transaction is Reversal.
    /// </summary>
    public static readonly FinancialTransactionType Reversal = new FinancialTransactionType(nameof(Reversal), "Reversal");
    
    /// <summary>
    /// Type of transaction is Failed.
    /// </summary>
    public static readonly FinancialTransactionType Failed = new FinancialTransactionType(nameof(Failed), "Failed");
    
    /// <summary>
    /// Initializes a <see cref="FinancialTransactionType"/> with the provided parameters.
    /// </summary>
    /// <param name="name">The name of the type.</param>
    /// <param name="value">The API value of the type.</param>
    public FinancialTransactionType(string name, string value) : base(name, value)
    {
    }
    
    /// <summary>
    /// Converts from a <c>string</c> to a <see cref="FinancialTransactionType"/>.
    /// </summary>
    /// <param name="originalState">he API value of the state.</param>
    public static implicit operator FinancialTransactionType?(string? originalState)
    {
        if (string.IsNullOrWhiteSpace(originalState))
        {
            return null;
        }
        
        return originalState switch
        {
            "Sale" => Sale,
            "Capture" => Capture,
            "Reversal" => Reversal,
            "Failed" => Failed,
            
            _ => new FinancialTransactionType(originalState!, originalState!),
        };
    }
}