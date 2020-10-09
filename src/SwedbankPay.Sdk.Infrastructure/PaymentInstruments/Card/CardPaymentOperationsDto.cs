namespace SwedbankPay.Sdk.Payments
{
    public class CardPaymentOperationsDto
    {
        public OperationList Operations { get; set; }

        public IOperationList Map()
        {
            return new OperationList(Operations);
        }
    }
}