namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    /// Length of time since the cardholder's account information with the merchant was changed. Including billing etc.
    /// </summary>
    public sealed class AccountChangeIndicator : TypeSafeEnum<AccountChangeIndicator, string>
    {
        public static AccountChangeIndicator ChangedDuringTransaction { get; } = new AccountChangeIndicator(nameof(ChangedDuringTransaction), "01");
        public static AccountChangeIndicator LessThanThirtyDays { get; } = new AccountChangeIndicator(nameof(LessThanThirtyDays), "02");
        public static AccountChangeIndicator ThirtyToSixtyDays { get; } = new AccountChangeIndicator(nameof(ThirtyToSixtyDays), "03");
        public static AccountChangeIndicator MoreThanSixtyDays { get; } = new AccountChangeIndicator(nameof(MoreThanSixtyDays), "04");

        public AccountChangeIndicator(string name, string value) : base(name, value)
        {
        }
    }
}