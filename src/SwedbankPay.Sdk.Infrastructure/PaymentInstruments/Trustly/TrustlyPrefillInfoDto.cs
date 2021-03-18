namespace SwedbankPay.Sdk.PaymentInstruments.Trustly
{
    public class TrustlyPrefillInfoDto
    {
        public TrustlyPrefillInfoDto(TrustlyPrefillInfo prefillInfo)
        {
            if(prefillInfo == null)
            {
                return;
            }

            FirstName = prefillInfo.FirstName;
            LastName = prefillInfo.LastName;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}