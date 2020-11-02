﻿namespace SwedbankPay.Sdk.PaymentInstruments
{
    public sealed class PaymentType : TypeSafeEnum<PaymentType>
    {
        public static readonly PaymentType CreditCard = new PaymentType(nameof(CreditCard), "creditcard");
        public static readonly PaymentType Swish = new PaymentType(nameof(Swish), "swish");
        public static readonly PaymentType Vipps = new PaymentType(nameof(Vipps), "vipps");
        public static readonly PaymentType DirectDebit = new PaymentType(nameof(DirectDebit), "directdebit");


        private PaymentType(string name, string value)
            : base(name, value)
        {
        }

        public static implicit operator PaymentType(string type)
        {
            return type switch
            {
                "creditcard" => CreditCard,
                "swish" => Swish,
                "sipps" => Vipps,
                "directdebit" => DirectDebit,
                _ => new PaymentType(type, type),
            };
        }
    }
}