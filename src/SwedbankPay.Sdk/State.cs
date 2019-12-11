namespace SwedbankPay.Sdk
{
    /// <summary>
    ///     Initialized, Completed, Failed Ready, Pending or Aborted. Indicates the state.
    /// </summary>
    public class State : TypeSafeEnum<State, string>
    {
        public static readonly State Initialized = new State(nameof(Initialized), "Initialized");
        public static readonly State Completed = new State(nameof(Completed), "Completed");
        public static readonly State Failed = new State(nameof(Failed), "Failed");
        public static readonly State Ready = new State(nameof(Ready), "Ready");
        public static readonly State Pending = new State(nameof(Pending), "Pending");
        public static readonly State Aborted = new State(nameof(Aborted), "Aborted");


        public State(string name, string value)
            : base(name, value)
        {
        }
    }
}