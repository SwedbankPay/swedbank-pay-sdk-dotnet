namespace SwedbankPay.Sdk
{
    /// <summary>
    ///     Indicates the length of time that the payments account was enrolled in the cardholder's account with merchant.
    /// </summary>
    public sealed class AccountAgeIndicator : TypeSafeEnum<AccountAgeIndicator>
    {
        public static readonly AccountAgeIndicator NoAccountGuest = new AccountAgeIndicator(nameof(NoAccountGuest), "01");

        public static readonly AccountAgeIndicator CreatedDuringTransaction =
            new AccountAgeIndicator(nameof(CreatedDuringTransaction), "02");

        public static readonly AccountAgeIndicator LessThanThirtyDays = new AccountAgeIndicator(nameof(LessThanThirtyDays), "03");
        public static readonly AccountAgeIndicator ThirtyToSixtyDays = new AccountAgeIndicator(nameof(ThirtyToSixtyDays), "04");
        public static readonly AccountAgeIndicator MoreThanSixtyDays = new AccountAgeIndicator(nameof(MoreThanSixtyDays), "05");


        public AccountAgeIndicator(string name, string value)
            : base(name, value)
        {
        }
    }
}