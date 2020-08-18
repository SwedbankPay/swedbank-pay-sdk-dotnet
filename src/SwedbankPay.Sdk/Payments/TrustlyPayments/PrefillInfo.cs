namespace SwedbankPay.Sdk.Payments.TrustlyPayments
{
    public class PrefillInfo
    {
        public PrefillInfo(string firstName) : this(firstName, null)
        {
        }

        public PrefillInfo(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; }
    }
}