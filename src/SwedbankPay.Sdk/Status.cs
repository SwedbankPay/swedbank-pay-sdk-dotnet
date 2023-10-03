namespace SwedbankPay.Sdk;

public class Status : TypeSafeEnum<Status>
{
    /// <summary>
    /// State of payment is Initialized.
    /// </summary>
    public static readonly Status Initialized = new Status(nameof(Initialized), "Initialized");

    /// <summary>
    /// State of payment is Completed.
    /// </summary>
    public static readonly Status Completed = new Status(nameof(Completed), "Completed");
    /// <summary>
    /// State of payment is Failed.
    /// </summary>
    public static readonly Status Failed = new Status(nameof(Failed), "Failed");
    /// <summary>
    /// State of payment is Ready.
    /// </summary>
    public static readonly Status Ready = new Status(nameof(Ready), "Ready");
    /// <summary>
    /// State of payment is Pending.
    /// </summary>
    public static readonly Status Pending = new Status(nameof(Pending), "Pending");
    /// <summary>
    /// State of payment is Aborted.
    /// </summary>
    public static readonly Status Aborted = new Status(nameof(Aborted), "Aborted");
    
    /// <summary>
    /// Initializes a <see cref="Status"/> with the provided parameters.
    /// </summary>
    /// <param name="name">The name of the state.</param>
    /// <param name="value">The API value of the state.</param>
    public Status(string name, string value) : base(name, value)
    {
    }
    
    /// <summary>
    /// Converts from a <c>string</c> to a <see cref="State"/>.
    /// </summary>
    /// <param name="originalState">he API value of the state.</param>
    public static implicit operator Status(string originalState)
    {
        return originalState switch
        {
            "Initialized" => Initialized,
            "Completed" => Completed,
            "Failed" => Failed,
            "Ready" => Ready,
            "Pending" => Pending,
            "Aborted" => Aborted,
            _ => new Status(originalState, originalState),
        };
    }
}