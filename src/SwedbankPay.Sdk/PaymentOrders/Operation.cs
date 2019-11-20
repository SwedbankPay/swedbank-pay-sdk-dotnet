namespace SwedbankPay.Sdk.PaymentOrders
{
    public sealed class Operation : TypeSafeEnum<Operation, string>
    {
        public static readonly Operation Purchase = new Operation(nameof(Purchase), "Purchase");
        public static readonly Operation UpdateOrder = new Operation(nameof(UpdateOrder), "UpdateOrder");

        public Operation(string name, string value)
            : base(name, value)
        {
        }
    }
}
