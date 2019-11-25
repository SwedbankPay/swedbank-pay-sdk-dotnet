namespace SwedbankPay.Sdk
{
    /// <summary>
    /// Initialized, Completed or Failed. Indicates the state of the transaction.
    /// </summary>
    public class State : TypeSafeEnum<State, string>
    {
        public static readonly State Initialized = new State(nameof(Initialized), "Initialized");
        public static readonly State Completed = new State(nameof(Completed), "Completed");
        public static readonly State Failed = new State(nameof(Failed), "Failed");
        
        public State(string name, string value)
            : base(name, value)
        {
        }
    }
}