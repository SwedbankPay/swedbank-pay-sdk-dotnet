namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class PrefillInfoDto
    {
        public PrefillInfoDto(PrefillInfo prefillInfo)
        {
            if(prefillInfo == null)
            {
                return;
            }
            Msisdn = prefillInfo.Msisdn.ToString();
        }

        public string Msisdn { get; }
    }
}