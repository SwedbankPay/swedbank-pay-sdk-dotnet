namespace SwedbankPay.Sdk
{
    public sealed class Operation : TypeSafeEnum<Operation, string>
    {
        public static readonly Operation Purchase = new Operation(nameof(Purchase), "Purchase");
        public static readonly Operation UpdateOrder = new Operation(nameof(UpdateOrder), "UpdateOrder");
        public static readonly Operation Verify = new Operation(nameof(Verify), "Verify");
        public static readonly Operation Initiate = new Operation(nameof(Initiate), "initiate-consumer-session");
        public static readonly Operation Recur = new Operation(nameof(Initiate), "Recur");
        public static readonly Operation FinancingConsumer = new Operation(nameof(FinancingConsumer), "FinancingConsumer");
        public static readonly Operation Sale = new Operation(nameof(Sale), "Sale");

        public Operation(string operation): base(operation, operation)
        {
        }

        public Operation(string name, string value)
            : base(name, value)
        {
        }
    }
}