namespace SwedbankPay.Sdk
{
    /// <summary>
    /// Indicates the payment method used in the price object.
    /// </summary>
    public enum PriceType
    {
        Unknown = default,
        CreditCard,
        Visa,
        MasterCard,
        Amex,
        Dankort,
        Diners,
        Finax,
        Jcb,
        IkanoFinansDK,
        Maestro,
        Directdebit,
        SwedbankLV,
        SwedbankEE,
        SwedbankLT,
        Invoice,
        Mobilepay,
        Swish,
        Vipps,
        Lindex,
        Ica,
        Trustly
    }
}