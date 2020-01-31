namespace SwedbankPay.Sdk.Payments.Card
{
    public class ReversalRequest
    {
        public ReversalRequest(Amount amount, Amount vatAmount, string description, string payeeReference)
        {
            Transaction = new ReversalTransaction(amount, vatAmount, description, payeeReference);
        }


        public ReversalTransaction Transaction { get; }
    }
}