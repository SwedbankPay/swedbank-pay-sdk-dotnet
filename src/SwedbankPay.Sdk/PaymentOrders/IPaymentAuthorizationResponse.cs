namespace SwedbankPay.Sdk.PaymentOrders
{
    public interface IPaymentAuthorizationResponse
    {
        public string Id { get; }
        public string Created { get; }
        public string Updated { get; }
        public string Type { get; }
        public string State { get; }
        public string Number { get; }
        public int Amount { get; }
        public int VatAmount { get; }
        public string Description { get; }
        public string PayeeReference { get; }
    }
}