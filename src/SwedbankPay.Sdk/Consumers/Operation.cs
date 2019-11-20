namespace SwedbankPay.Sdk.Consumers
{
    public sealed class Operation : TypeSafeEnum<Operation, string>
    {
        public static readonly Operation Initiate = new Operation(nameof(Initiate), "initiate-consumer-session");

        public Operation(string name, string value)
            : base(name, value)
        {
        }
    }
}
