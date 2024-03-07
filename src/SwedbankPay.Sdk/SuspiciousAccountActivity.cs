namespace SwedbankPay.Sdk;

/// <summary>
///     Indicates whether merchant has experienced suspicious activity (including previous fraud) on the cardholder
///     account.
/// </summary>
public sealed class SuspiciousAccountActivity : TypeSafeEnum<SuspiciousAccountActivity>
{
    /// <summary>
    /// Instantiates a <see cref="SuspiciousAccountActivity"/> with the provided parameters.
    /// </summary>
    /// <param name="name">Human readable name of the suspicious activity.</param>
    /// <param name="value">API value of the activity.</param>
    public SuspiciousAccountActivity(string name, string value)
        : base(name, value)
    {
    }

    /// <summary>
    /// Risk indicator to use when suspicious activity has not been observed.
    /// </summary>

    public static SuspiciousAccountActivity NoSuspiciousActivityObserved { get; } =
        new SuspiciousAccountActivity("No suspicious activity has been observed", "01");

    /// <summary>
    /// Risk indicator to use when suspicious activity has been observed.
    /// </summary>
    public static SuspiciousAccountActivity SuspiciousActivityObserved { get; } =
        new SuspiciousAccountActivity("Suspicious activity has been observed", "02");
}