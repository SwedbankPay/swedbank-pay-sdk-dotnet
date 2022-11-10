namespace SwedbankPay.Sdk;

/// <summary>
///     Initialized, Completed, Failed Ready, Pending or Aborted, or Paid.
///     Indicates the current state.
/// </summary>
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
    /// State of payment is Ready.
    /// </summary>
    public static readonly State Ready = new State(nameof(Ready), "Ready");
    /// <summary>
    /// State of payment is Pending.
    /// </summary>
    public static readonly State Pending = new State(nameof(Pending), "Pending");
    /// <summary>
    /// State of payment is Aborted.
    /// </summary>
    public static readonly State Aborted = new State(nameof(Aborted), "Aborted");

    /// <summary>
    /// State of payment is Awaiting Activity.
    /// </summary>
    public static readonly State AwaitingActivity = new State(nameof(AwaitingActivity), "AwaitingActivity");

    /// <summary>
    /// State of payment is Paid.
    /// </summary>
    public static readonly State Paid = new State(nameof(Paid), "Paid");

    /// <summary>
    /// Initializes a <see cref="State"/> with the provided parameters.
    /// </summary>
    /// <param name="name">The name of the state.</param>
    /// <param name="value">The API value of the state.</param>
    public State(string name, string value)
        : base(name, value)
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
            "Ready" => Ready,
            "Pending" => Pending,
            "Aborted" => Aborted,
            "AwaitingActivity" => AwaitingActivity,
            _ => new State(originalState, originalState),
        };
    }
}