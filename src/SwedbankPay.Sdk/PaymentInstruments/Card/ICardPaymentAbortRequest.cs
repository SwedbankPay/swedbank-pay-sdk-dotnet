namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public interface ICardPaymentAbortRequest
    {
        /// <summary>
        /// Details about the abort.
        /// </summary>
        CardPaymentAbortPayment Payment { get; }
    }
}