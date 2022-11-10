namespace SwedbankPay.Sdk;

/// <summary>
///     Length of time since the cardholder's account information with the merchant was changed. Including billing etc.
/// </summary>
public sealed class AccountChangeIndicator : TypeSafeEnum<AccountChangeIndicator>
{
    /// <summary>
    /// Account details will change during transaction.
    /// </summary>
    public static readonly AccountChangeIndicator ChangedDuringTransaction =
        new AccountChangeIndicator(nameof(ChangedDuringTransaction), "01");

    /// <summary>
    /// Account details was last changed less than thirty days ago.
    /// </summary>
    public static readonly AccountChangeIndicator LessThanThirtyDays = new AccountChangeIndicator(nameof(LessThanThirtyDays), "02");
    
    /// <summary>
    /// Account details was last changed between thirty to sixty days ago.
    /// </summary>
    public static readonly AccountChangeIndicator ThirtyToSixtyDays = new AccountChangeIndicator(nameof(ThirtyToSixtyDays), "03");
    
    /// <summary>
    /// Account details last changed more than sixty days ago.
    /// </summary>
    public static readonly AccountChangeIndicator MoreThanSixtyDays = new AccountChangeIndicator(nameof(MoreThanSixtyDays), "04");

    /// <summary>
    /// Creates a new custom account change indicator.
    /// </summary>
    /// <param name="name">The name of the account change indicator.</param>
    /// <param name="value">The enum value for the account change.</param>
    public AccountChangeIndicator(string name, string value)
        : base(name, value)
    {
    }
}