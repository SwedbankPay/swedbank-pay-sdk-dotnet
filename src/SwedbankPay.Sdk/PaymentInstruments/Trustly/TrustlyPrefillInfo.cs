namespace SwedbankPay.Sdk.PaymentInstruments.Trustly
{
    public class TrustlyPrefillInfo
    {
        public TrustlyPrefillInfo(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        /// <summary>
        /// First name of the payer.
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Last name of the payer.
        /// </summary>
        public string LastName { get; }
    }
}