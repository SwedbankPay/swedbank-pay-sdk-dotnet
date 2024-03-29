namespace SwedbankPay.Sdk.PaymentOrder.Paid;

public sealed class TransactionType : TypeSafeEnum<TransactionType>
{
    
    /// <summary>
    /// Type of transaction is Sale.
    /// </summary>
    public static readonly TransactionType Sale = new TransactionType(nameof(Sale), "Sale");
    
    /// <summary>
    /// Type of transaction is Authorization.
    /// </summary>
    public static readonly TransactionType Authorization = new TransactionType(nameof(Authorization), "Authorization");
    
    /// <summary>
    /// Initializes a <see cref="name"/> with the provided parameters.
    /// </summary>
    /// <param name="value">The name of the type.</param>
    /// <param name="value">The API value of the type.</param>
    public TransactionType(string name, string value) : base(name, value)
    {
    }
    
    /// <summary>
    /// Converts from a <c>string</c> to a <see cref="FinancialTransactionType"/>.
    /// </summary>
    /// <param name="originalState">The API value of the state.</param>
    public static implicit operator TransactionType?(string? originalState)
    {
        if (string.IsNullOrWhiteSpace(originalState))
        {
            return null;
        }
        
        return originalState switch
        {
            "Sale" => Sale,
            "Authorization" => Authorization,
            
            _ => new TransactionType(originalState!, originalState!),
        };
    }
}