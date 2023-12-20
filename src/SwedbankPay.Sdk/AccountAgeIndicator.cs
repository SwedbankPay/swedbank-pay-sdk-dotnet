namespace SwedbankPay.Sdk;

/// <summary>
///     Indicates the length of time that the payments account was enrolled in the cardholder's account with merchant.
/// </summary>
public sealed class AccountAgeIndicator : TypeSafeEnum<AccountAgeIndicator>
{
    /// <summary>
    /// User does not have an account or only a guest account.
    /// </summary>
    public static readonly AccountAgeIndicator NoAccountGuest = new AccountAgeIndicator(nameof(NoAccountGuest), "01");

    /// <summary>
    /// Account is created during transaction.
    /// </summary>
    public static readonly AccountAgeIndicator CreatedDuringTransaction =
        new AccountAgeIndicator(nameof(CreatedDuringTransaction), "02");

    /// <summary>
    /// Account has existed for less than thirty days.
    /// </summary>
    public static readonly AccountAgeIndicator LessThanThirtyDays = new AccountAgeIndicator(nameof(LessThanThirtyDays), "03");
        
    /// <summary>
    /// Account is between thirty to sixty days old.
    /// </summary>
    public static readonly AccountAgeIndicator ThirtyToSixtyDays = new AccountAgeIndicator(nameof(ThirtyToSixtyDays), "04");
        
    /// <summary>
    /// Account is older than sixty days.
    /// </summary>
    public static readonly AccountAgeIndicator MoreThanSixtyDays = new AccountAgeIndicator(nameof(MoreThanSixtyDays), "05");

    /// <summary>
    /// Creates a new custom account age indicator.
    /// </summary>
    /// <param name="name">The name of the enum value.</param>
    /// <param name="value">The value of the enum.</param>
    public AccountAgeIndicator(string name, string value)
        : base(name, value)
    {
    }
}