using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk;

/// <summary>
/// Enum-like object to programatically inspect API Operations.
/// </summary>
public sealed class LinkRelation : TypeSafeEnum<LinkRelation>
{
    /// <summary>
    /// <seealso cref="LinkRelation"/> for PaymentOrder UpdatePaymentorder.
    /// </summary>
    public static readonly LinkRelation UpdatePaymentOrderUpdateOrder =
        new LinkRelation(nameof(UpdatePaymentOrderUpdateOrder), PaymentOrderResourceOperations.UpdateOrder);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for PaymentOrder UpdatePaymentorder.
    /// </summary>
    public static readonly LinkRelation CreatePaymentOrderCapture =
        new LinkRelation(nameof(CreatePaymentOrderCapture), PaymentOrderResourceOperations.Capture);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for PaymentOrder UpdatePaymentorder.
    /// </summary>
    public static readonly LinkRelation CreatePaymentOrderCancel =
        new LinkRelation(nameof(CreatePaymentOrderCancel), PaymentOrderResourceOperations.Cancel);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for PaymentOrder UpdateAbort.
    /// </summary>
    public static readonly LinkRelation UpdateAbort =
        new LinkRelation(nameof(UpdateAbort), PaymentOrderResourceOperations.Abort);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for PaymentOrder UpdatePaymentorderReversal.
    /// </summary>
    public static readonly LinkRelation CreatePaymentOrderReversal =
        new LinkRelation(nameof(CreatePaymentOrderReversal), PaymentOrderResourceOperations.Reversal);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for PaymentOrder View.
    /// </summary>
    public static readonly LinkRelation View = new LinkRelation(nameof(View), PaymentOrderResourceOperations.ViewCheckout);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for PaymentOrder RedirectPaymentOrder.
    /// </summary>
    public static readonly LinkRelation RedirectPaymentOrder =
        new LinkRelation(nameof(RedirectPaymentOrder), PaymentOrderResourceOperations.RedirectCheckout);

    /// <summary>
    /// Instantiates a new <seealso cref="LinkRelation"/> where both name and value are <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The name/value combo.</param>
    public LinkRelation(string name) : base(name, name)
    {
    }

    /// <summary>
    /// Instantiates a new <seealso cref="LinkRelation"/> using the provided parameters.
    /// </summary>
    /// <param name="name">The name of the <seealso cref="LinkRelation"/>.</param>
    /// <param name="value">The value of the <seealso cref="LinkRelation"/>.</param>
    public LinkRelation(string name, string value)
        : base(name, value)
    {
    }
}