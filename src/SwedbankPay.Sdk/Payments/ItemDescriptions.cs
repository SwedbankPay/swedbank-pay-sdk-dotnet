using System;
using System.Collections.Generic;
using System.Text;

namespace SwedbankPay.Sdk.Payments
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
