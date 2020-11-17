namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class PrefillInfo
    {
        public PrefillInfo(Msisdn msisdn)
        {
            Msisdn = msisdn;
        }


        /// <summary>
        /// MSISDN of the payer, with landcode.
        /// </summary>
        public Msisdn Msisdn { get; }
    }
}