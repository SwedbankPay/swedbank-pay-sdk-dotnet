namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    ///     Length of time since the cardholder's account information with the merchant was changed. Including billing etc.
    /// </summary>
    public sealed class AccountChangeIndicator : TypeSafeEnum<AccountChangeIndicator, string>
    {
        public static readonly AccountChangeIndicator ChangedDuringTransaction =
            new AccountChangeIndicator(nameof(ChangedDuringTransaction), "01");

        public static readonly AccountChangeIndicator LessThanThirtyDays = new AccountChangeIndicator(nameof(LessThanThirtyDays), "02");
        public static readonly AccountChangeIndicator ThirtyToSixtyDays = new AccountChangeIndicator(nameof(ThirtyToSixtyDays), "03");
        public static readonly AccountChangeIndicator MoreThanSixtyDays = new AccountChangeIndicator(nameof(MoreThanSixtyDays), "04");


        public AccountChangeIndicator(string name, string value)
            : base(name, value)
        {
        }
    }
}