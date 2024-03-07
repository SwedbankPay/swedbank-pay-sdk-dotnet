namespace SwedbankPay.Sdk.PaymentOrder.FailedAttempts;

public sealed class FailedStatus : TypeSafeEnum<FailedStatus>
{
    /// <summary>
    /// State of payment is Aborted.
    /// </summary>
    public static readonly FailedStatus Aborted = new FailedStatus(nameof(Aborted), "Aborted");
    /// <summary>
    /// State of payment is Failed.
    /// </summary>
    public static readonly FailedStatus Failed = new FailedStatus(nameof(Failed), "Failed");
  
    /// <summary>
    /// Initializes a <see cref="SwedbankPay.Sdk.Status"/> with the provided parameters.
    /// </summary>
    /// <param name="name">The name of the state.</param>
    /// <param name="value">The API value of the state.</param>
    private FailedStatus(string name, string value) : base(name, value)
    {
    }
    
    /// <summary>
    /// Converts from a <c>string</c> to a <see cref="SwedbankPay.Sdk.Status"/>.
    /// </summary>
    /// <param name="originalState">he API value of the state.</param>
    public static implicit operator FailedStatus(string originalState)
    {
        return originalState switch
        {
            "Aborted" => Aborted,
            "Failed" => Failed,
            
            _ => new FailedStatus(originalState, originalState),
        };
    }
}