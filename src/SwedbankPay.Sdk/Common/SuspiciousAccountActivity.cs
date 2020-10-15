namespace SwedbankPay.Sdk.Common
{
    /// <summary>
    ///     Indicates whether merchant has experienced suspicious activity (including previous fraud) on the cardholder
    ///     account.
    /// </summary>
    public sealed class SuspiciousAccountActivity : TypeSafeEnum<SuspiciousAccountActivity, string>
    {
        public SuspiciousAccountActivity(string name, string value)
            : base(name, value)
        {
        }


        public static SuspiciousAccountActivity NoSuspiciousActivityObserved { get; } =
            new SuspiciousAccountActivity("No suspicious activity has been observed", "01");

        public static SuspiciousAccountActivity SuspiciousActivityObserved { get; } =
            new SuspiciousAccountActivity("Suspicious activity has been observed", "02");
    }
}