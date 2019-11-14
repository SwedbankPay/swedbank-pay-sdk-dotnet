using System.Runtime.CompilerServices;


namespace SwedbankPay.Sdk.PaymentOrders
{
    public sealed class AccountAgeIndicator : TypeSafeEnum<AccountAgeIndicator, string>
    {
        public static AccountAgeIndicator NoAccountGuest { get; } = new AccountAgeIndicator("No account, guest", "01");
        public static AccountAgeIndicator CreatedDuringTransaction { get; } = new AccountAgeIndicator("Created during transaction", "02");
        public static AccountAgeIndicator LessThanThirtyDays { get; } = new AccountAgeIndicator("Less than 30 days", "03");
        public static AccountAgeIndicator ThirtyToSixtyDays { get; } = new AccountAgeIndicator("30-60 days", "04");
        public static AccountAgeIndicator MoreThanSixtyDays { get; } = new AccountAgeIndicator("More than 60 days", "05");

        #region MyRegion
        //public static readonly AccountAgeIndicator NoAccountGuest = new AccountAgeIndicator("No account, guest", "01");
        //public static AccountAgeIndicator CreatedDuringTransaction { get; } = new AccountAgeIndicator("Created during transaction", "02");
        //public static AccountAgeIndicator LessThanThirtyDays { get; } = new AccountAgeIndicator("Less than 30 days", "03");
        //public static AccountAgeIndicator ThirtyToSixtyDays { get; } = new AccountAgeIndicator("30-60 days", "04");
        //public static AccountAgeIndicator MoreThanSixtyDays { get; } = new AccountAgeIndicator("More than 60 days", "05");


        #endregion


        public AccountAgeIndicator(string name, string value) : base(name, value)
        {
        }
    }
}