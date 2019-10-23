namespace SwedbankPay.Sdk.Models
{
    using System;
    using System.Collections.Generic;

    public sealed class DeliveryTimeFrameIndicator
    {
        private readonly string name;
        private readonly int value;
        private static readonly Dictionary<string, DeliveryTimeFrameIndicator> instance = new Dictionary<string, DeliveryTimeFrameIndicator>();

        public static readonly DeliveryTimeFrameIndicator ELECTRONICDELIVERY = new DeliveryTimeFrameIndicator(1, "01");
        public static readonly DeliveryTimeFrameIndicator SAMEDAYSHIPPING = new DeliveryTimeFrameIndicator(2, "02");
        public static readonly DeliveryTimeFrameIndicator OVERNIGHTSHIPPING = new DeliveryTimeFrameIndicator(3, "03");
        public static readonly DeliveryTimeFrameIndicator TWODAYORMORESHIPPING = new DeliveryTimeFrameIndicator(4, "04");
        
        private DeliveryTimeFrameIndicator(int value, string name)
        {
            this.name = name;
            this.value = value;
            instance[name] = this;
        }

        public override string ToString()
        {
            return name;
        }
        public static explicit operator DeliveryTimeFrameIndicator(string str)
        {
            DeliveryTimeFrameIndicator result;
            if (instance.TryGetValue(str, out result))
                return result;
            else
                throw new InvalidCastException();
        }
    }
}