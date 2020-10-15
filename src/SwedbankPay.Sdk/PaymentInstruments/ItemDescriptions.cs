using SwedbankPay.Sdk.Common;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class ItemDescriptions
    {
        public ItemDescriptions(Amount amount,
                                string description)
        {
            Amount = amount;
            Description = description;
        }

        public Amount Amount { get; }
        public string Description { get; }

    }
}
