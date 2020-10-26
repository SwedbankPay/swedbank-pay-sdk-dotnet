﻿namespace SwedbankPay.Sdk.Common
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
        public static readonly State AwaitingActivity = new State(nameof(AwaitingActivity), "AwaitingActivity");


        public State(string name, string value)
            : base(name, value)
        {
        }

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
}