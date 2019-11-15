namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    /// Indicates the length of time since the cardholder's account with the merchant had a password change or account reset.
    /// </summary>
    public sealed class AccountPwdChangeIndicator : TypeSafeEnum<AccountPwdChangeIndicator, string>
    {
        public static AccountPwdChangeIndicator NoChange { get; } = new AccountPwdChangeIndicator(nameof(NoChange), "01");
        public static AccountPwdChangeIndicator ChangedDuringTransaction { get; } = new AccountPwdChangeIndicator(nameof(ChangedDuringTransaction), "02");
        public static AccountPwdChangeIndicator LessThanThirtyDays { get; } = new AccountPwdChangeIndicator(nameof(LessThanThirtyDays), "03");
        public static AccountPwdChangeIndicator ThirtyToSixtyDays { get; } = new AccountPwdChangeIndicator(nameof(ThirtyToSixtyDays), "04");
        public static AccountPwdChangeIndicator MoreThanSixtyDays { get; } = new AccountPwdChangeIndicator(nameof(MoreThanSixtyDays), "05");


        public AccountPwdChangeIndicator(string name, string value) : base(name, value)
        {
        }
    }
}