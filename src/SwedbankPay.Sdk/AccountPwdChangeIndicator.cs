namespace SwedbankPay.Sdk;

/// <summary>
///     Indicates the length of time since the cardholder's account with the merchant had a password change or account
///     reset.
/// </summary>
public sealed class AccountPwdChangeIndicator : TypeSafeEnum<AccountPwdChangeIndicator>
{
    /// <summary>
    /// The account password has never changed.
    /// </summary>
    public static readonly AccountPwdChangeIndicator NoChange = new AccountPwdChangeIndicator(nameof(NoChange), "01");

    /// <summary>
    /// The account password will be changed during transaction.
    /// </summary>
    public static readonly AccountPwdChangeIndicator ChangedDuringTransaction =
        new AccountPwdChangeIndicator(nameof(ChangedDuringTransaction), "02");

    /// <summary>
    /// Account password was last changed less than thirty days ago.
    /// </summary>
    public static readonly AccountPwdChangeIndicator LessThanThirtyDays =
        new AccountPwdChangeIndicator(nameof(LessThanThirtyDays), "03");

    /// <summary>
    /// Account password was last changed between thirty to sixty days ago.
    /// </summary>
    public static readonly AccountPwdChangeIndicator ThirtyToSixtyDays = new AccountPwdChangeIndicator(nameof(ThirtyToSixtyDays), "04");
    
    /// <summary>
    /// Account password was last changed more than sixty days ago.
    /// </summary>
    public static readonly AccountPwdChangeIndicator MoreThanSixtyDays = new AccountPwdChangeIndicator(nameof(MoreThanSixtyDays), "05");

    /// <summary>
    /// Creates a new custom account password changed indicator.
    /// </summary>
    /// <param name="name">The name of the enum value.</param>
    /// <param name="value">The value for the enum.</param>
    public AccountPwdChangeIndicator(string name, string value)
        : base(name, value)
    {
    }
}