namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class PaymentAbortRequest
    {
        public PaymentAbortRequest(PaymentAbortRequestDetails payment)
        {
            Payment = payment;
        }

        /// <summary>
        /// Data detailing why the current payment is being aborted.
        /// </summary>
        public PaymentAbortRequestDetails Payment { get; } = new PaymentAbortRequestDetails();
    }
}