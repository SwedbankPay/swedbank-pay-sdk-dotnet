namespace SwedbankPay.Sdk;

public class State : TypeSafeEnum<State>
{
    /// <summary>
    /// State of payment is Initialized.
    /// </summary>
    public static readonly State Initialized = new State(nameof(Initialized), "Initialized");

    /// <summary>
    /// State of payment is Completed.
    /// </summary>
    public static readonly State Completed = new State(nameof(Completed), "Completed");
    /// <summary>
    /// State of payment is Failed.
    /// </summary>
    public static readonly State Failed = new State(nameof(Failed), "Failed");
    
    /// <summary>
    /// State of payment is AwaitingActivity.
    /// </summary>
    public static readonly State AwaitingActivity = new State(nameof(AwaitingActivity), "AwaitingActivity");
    
    public State(string name, string value) : base(name, value)
    {
    }
    
    /// <summary>
    /// Converts from a <c>string</c> to a <see cref="State"/>.
    /// </summary>
    /// <param name="originalState">he API value of the state.</param>
    public static implicit operator State(string originalState)
    {
        return originalState switch
        {
            "Initialized" => Initialized,
            "Completed" => Completed,
            "Failed" => Failed,
            "AwaitingActivity" => AwaitingActivity,
            _ => new State(originalState, originalState),
        };
    }
}