namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentCancelRequest
    {
        public CardPaymentCancelRequest(string payeeReference, string description)
        {
            Transaction = new CardPaymentCancelTransaction(payeeReference, description);
        }


        public CardPaymentCancelTransaction Transaction { get; }
    }
}