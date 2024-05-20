namespace SwedbankPay.Sdk;

/// <summary>
/// Identifies the merchant that initiated the payment.
/// </summary>
public record PayeeInfo(string PayeeReference)
{
    /// <summary>
    ///     The name of the payee, usually the name of the merchant.
    /// </summary>
    public string? PayeeName { get; init; }

    /// <summary>
    ///     The order reference should reflect the order reference found in the merchant's systems.
    /// </summary>
    public string? OrderReference { get; init; }

    /// <summary>
    ///     This is the unique id that identifies this payee (like merchant) set by PayEx.
    /// </summary>
    public string? PayeeId { get; init; }

    /// <summary>
    ///     A unique reference, max 30 characters, set by the merchant system - this must be unique for each operation!
    ///     NOTE://PayEx may send either the transaction number OR the payeeReference as a reference to the acquirer.
    ///     This will be used in reconciliation and reporting back to PayEx and you.
    ///     If PayEx sends the transaction number to the acquirer, then the payeeReference parameter may have the format of
    ///     String(30).
    ///     If PayEx sends the payeeRef to the acquirer, the parameter is limited to the format of String(12) AND all
    ///     characters must be digits/numbers.
    /// </summary>
    public string PayeeReference { get; } = PayeeReference;

    /// <summary>
    ///    The subsite field can be used to perform split settlement on the payment.
    ///    The different subsite values must be resolved with Swedbank Pay reconciliation before being used.
    ///    If you send in an unknown subsite value, it will be ignored and the payment will be settled using the merchant’s default settlement account.
    ///    Must be in the format of A-Za-z0-9.
    /// </summary>
    public string? Subsite { get; init; }

    /// <summary>
    /// siteId is used for split settlement transactions when you, as a merchant, need to specify towards AMEX which sub-merchant the transaction belongs to.
    /// Must be in the format of A-Za-z0-9.
    /// </summary>
    public string? SiteId { get; init; }
}