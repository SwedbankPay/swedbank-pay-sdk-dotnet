namespace SwedbankPay.Sdk.PaymentInstruments
{
    /// <summary>
    /// Enum-like mapper from payment type in the API
    /// to a staticly typed object.
    /// </summary>
    public sealed class PaymentType : TypeSafeEnum<PaymentType>
    {
        /// <summary>
        /// Represents a credit card payment type in the API
        /// </summary>
        public static readonly PaymentType CreditCard = new PaymentType(nameof(CreditCard), "creditcard");

        /// <summary>
        /// Represents a Swish payment type in the API
        /// </summary>
        public static readonly PaymentType Swish = new PaymentType(nameof(Swish), "swish");

        /// <summary>
        /// Represents a Vipps payment type in the API
        /// </summary>
        public static readonly PaymentType Vipps = new PaymentType(nameof(Vipps), "vipps");

        /// <summary>
        /// Represents a direct debit payment type in the API
        /// </summary>
        public static readonly PaymentType DirectDebit = new PaymentType(nameof(DirectDebit), "directdebit");


        private PaymentType(string name, string value)
            : base(name, value)
        {
        }

        /// <summary>
        /// Converts <paramref name="type"/> to either a staticly made <see cref="PaymentType"/>
        /// or creates a new instance of one is not mapped already.
        /// </summary>
        /// <param name="type"></param>
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