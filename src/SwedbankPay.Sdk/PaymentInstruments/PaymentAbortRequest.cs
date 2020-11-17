namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class PaymentAbortRequest
    {
        /// <summary>
        /// Data detailing why the current payment is being aborted.
        /// </summary>
        public PaymentAbortRequestData Payment { get; set; } = new PaymentAbortRequestData();
    }
}