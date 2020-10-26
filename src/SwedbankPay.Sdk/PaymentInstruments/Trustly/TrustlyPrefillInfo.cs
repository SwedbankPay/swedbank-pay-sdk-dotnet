namespace SwedbankPay.Sdk.PaymentInstruments.Trustly
{
    public class TrustlyPrefillInfo
    {
        public TrustlyPrefillInfo(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; }
    }
}