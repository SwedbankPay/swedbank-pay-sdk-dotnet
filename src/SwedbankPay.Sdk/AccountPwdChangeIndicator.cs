namespace SwedbankPay.Sdk
{
    /// <summary>
    ///     Indicates the length of time since the cardholder's account with the merchant had a password change or account
    ///     reset.
    /// </summary>
    public sealed class AccountPwdChangeIndicator : TypeSafeEnum<AccountPwdChangeIndicator, string>
    {
        public static readonly AccountPwdChangeIndicator NoChange = new AccountPwdChangeIndicator(nameof(NoChange), "01");

        public static readonly AccountPwdChangeIndicator ChangedDuringTransaction =
            new AccountPwdChangeIndicator(nameof(ChangedDuringTransaction), "02");

        public static readonly AccountPwdChangeIndicator LessThanThirtyDays =
            new AccountPwdChangeIndicator(nameof(LessThanThirtyDays), "03");

        public static readonly AccountPwdChangeIndicator ThirtyToSixtyDays = new AccountPwdChangeIndicator(nameof(ThirtyToSixtyDays), "04");
        public static readonly AccountPwdChangeIndicator MoreThanSixtyDays = new AccountPwdChangeIndicator(nameof(MoreThanSixtyDays), "05");


        public AccountPwdChangeIndicator(string name, string value)
            : base(name, value)
        {
        }
    }
}