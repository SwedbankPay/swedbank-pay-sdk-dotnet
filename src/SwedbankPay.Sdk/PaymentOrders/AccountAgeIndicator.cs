using System.Runtime.CompilerServices;


namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    /// Indicates the length of time that the payments account was enrolled in the cardholder's account with merchant.
    /// </summary>
    public sealed class AccountAgeIndicator : TypeSafeEnum<AccountAgeIndicator, string>
    {
        public static AccountAgeIndicator NoAccountGuest { get; } = new AccountAgeIndicator(nameof(NoAccountGuest), "01"); //TODO if C#8.0 use private static readonly fields instead
        public static AccountAgeIndicator CreatedDuringTransaction { get; } = new AccountAgeIndicator(nameof(CreatedDuringTransaction), "02");
        public static AccountAgeIndicator LessThanThirtyDays { get; } = new AccountAgeIndicator(nameof(LessThanThirtyDays), "03");
        public static AccountAgeIndicator ThirtyToSixtyDays { get; } = new AccountAgeIndicator(nameof(ThirtyToSixtyDays), "04");
        public static AccountAgeIndicator MoreThanSixtyDays { get; } = new AccountAgeIndicator(nameof(MoreThanSixtyDays), "05");
        
        public AccountAgeIndicator(string name, string value) : base(name, value)
        {
        }
    }
}