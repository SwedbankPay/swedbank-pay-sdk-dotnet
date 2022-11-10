#region License

// --------------------------------------------------
// Copyright © Swedbank Pay. All Rights Reserved.
// 
// This software is proprietary information of Swedbank Pay.
// USE IS SUBJECT TO LICENSE TERMS.
// --------------------------------------------------

#endregion

using SwedbankPay.Sdk.Consumers;
using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.PaymentOrders;

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
        new LinkRelation(nameof(UpdatePaymentOrderUpdateOrder), PaymentOrderResourceOperations.UpdatePaymentOrderUpdateOrder);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for PaymentOrder UpdatePaymentorder.
    /// </summary>
    public static readonly LinkRelation CreatePaymentOrderCapture =
        new LinkRelation(nameof(CreatePaymentOrderCapture), PaymentOrderResourceOperations.CreatePaymentOrderCapture);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for PaymentOrder UpdatePaymentorder.
    /// </summary>
    public static readonly LinkRelation CreatePaymentOrderCancel =
        new LinkRelation(nameof(CreatePaymentOrderCancel), PaymentOrderResourceOperations.CreatePaymentOrderCancel);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for PaymentOrder UpdateAbort.
    /// </summary>
    public static readonly LinkRelation UpdateAbort =
        new LinkRelation(nameof(UpdateAbort), PaymentOrderResourceOperations.UpdatePaymentOrderAbort);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for PaymentOrder UpdatePaymentorderReversal.
    /// </summary>
    public static readonly LinkRelation CreatePaymentOrderReversal =
        new LinkRelation(nameof(CreatePaymentOrderReversal), PaymentOrderResourceOperations.CreatePaymentOrderReversal);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for PaymentOrder View.
    /// </summary>
    public static readonly LinkRelation View = new LinkRelation(nameof(View), PaymentOrderResourceOperations.ViewPaymentOrder);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for PaymentOrder RedirectPaymentOrder.
    /// </summary>
    public static readonly LinkRelation RedirectPaymentOrder =
        new LinkRelation(nameof(RedirectPaymentOrder), PaymentOrderResourceOperations.RedirectPaymentOrder);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for PaymentOrder RedirectVerification.
    /// </summary>
    public static readonly LinkRelation RedirectVerification =
        new LinkRelation(nameof(RedirectVerification), PaymentOrderResourceOperations.RedirectVerification);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for Consumer ViewConsumerIdentification.
    /// </summary>
    public static readonly LinkRelation ViewConsumerIdentification =
        new LinkRelation(nameof(ViewConsumerIdentification), ConsumerResourceOperations.ViewConsumerIdentification);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for Consumer RedirectConsumerIdentification.
    /// </summary>
    public static readonly LinkRelation RedirectConsumerIdentification =
        new LinkRelation(nameof(RedirectConsumerIdentification), ConsumerResourceOperations.RedirectConsumerIdentification);
    /// <summary>
    /// <seealso cref="LinkRelation"/> for Payment CreateCancellation.
    /// </summary>
    public static readonly LinkRelation CreateCancellation =
        new LinkRelation(nameof(CreateCancellation), PaymentResourceOperations.CreateCancellation);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for Payment CreateCapture.
    /// </summary>
    public static readonly LinkRelation
        CreateCapture = new LinkRelation(nameof(CreateCapture), PaymentResourceOperations.CreateCapture);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for Payment CreateReversal.
    /// </summary>
    public static readonly LinkRelation CreateReversal =
        new LinkRelation(nameof(CreateReversal), PaymentResourceOperations.CreateReversal);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for Payment PaidPaymentOrder.
    /// </summary>
    public static readonly LinkRelation PaidPaymentOrder =
        new LinkRelation(nameof(PaidPaymentOrder), PaymentOrderResourceOperations.PaidPaymentOrder);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for Payment PaidPayment.
    /// </summary>
    public static readonly LinkRelation PaidPayment = new LinkRelation(nameof(PaidPayment), PaymentResourceOperations.PaidPayment);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for Payment UpdatePaymentAbort.
    /// </summary>
    public static readonly LinkRelation UpdatePaymentAbort =
        new LinkRelation(nameof(UpdatePaymentAbort), PaymentResourceOperations.UpdatePaymentAbort);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for Payment ViewAuthorization.
    /// </summary>
    public static readonly LinkRelation ViewAuthorization =
        new LinkRelation(nameof(ViewAuthorization), PaymentResourceOperations.ViewAuthorization);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for Payment RedirectAuthorization.
    /// </summary>
    public static readonly LinkRelation RedirectAuthorization =
        new LinkRelation(nameof(RedirectAuthorization), PaymentResourceOperations.RedirectAuthorization);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for Payment CreateSale.
    /// </summary>
    public static readonly LinkRelation CreateSale = new LinkRelation(nameof(CreateSale), PaymentResourceOperations.CreateSale);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for Paymen RedirectSale.
    /// </summary>
    public static readonly LinkRelation RedirectSale = new LinkRelation(nameof(RedirectSale), PaymentResourceOperations.RedirectSale);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for Paymen ViewSale.
    /// </summary>
    public static readonly LinkRelation ViewSales = new LinkRelation(nameof(ViewSales), PaymentResourceOperations.ViewSale);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for Payment AbortedPayment.
    /// </summary>
    public static readonly LinkRelation AbortedPayment =
        new LinkRelation(nameof(AbortedPayment), PaymentResourceOperations.AbortedPayment);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for PaymentOrder AbortedPaymentOrder.
    /// </summary>
    public static readonly LinkRelation AbortedPaymentOrder =
        new LinkRelation(nameof(AbortedPaymentOrder), PaymentOrderResourceOperations.AbortedPaymentOrder);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for Payment RedirectAppSwish.
    /// </summary>
    public static readonly LinkRelation RedirectAppSwish =
        new LinkRelation(nameof(RedirectAppSwish), PaymentResourceOperations.RedirectAppSwish);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for Payment ViewPayment.
    /// </summary>
    public static readonly LinkRelation ViewPayment = new LinkRelation(nameof(ViewPayment), PaymentResourceOperations.ViewPayment);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for Payment ViewVerification.
    /// </summary>
    public static readonly LinkRelation ViewVerification =
        new LinkRelation(nameof(ViewVerification), PaymentResourceOperations.ViewVerification);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for Payment UpdateAuthorizationOverchargedAmount.
    /// </summary>
    public static readonly LinkRelation UpdateAuthorizationOverchargedamount =
        new LinkRelation(nameof(UpdateAuthorizationOverchargedamount), PaymentResourceOperations.UpdateAuthorizationOverchargedAmount);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for Payment CreateApprovedLegalAddress.
    /// </summary>
    public static readonly LinkRelation CreateApprovedLegalAddress =
        new LinkRelation(nameof(CreateApprovedLegalAddress), PaymentResourceOperations.CreateApprovedLegalAddress);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for Payment CreateAuthorization.
    /// </summary>
    public static readonly LinkRelation CreateAuthorization =
        new LinkRelation(nameof(CreateAuthorization), PaymentResourceOperations.CreateAuthorization);

    /// <summary>
    /// <seealso cref="LinkRelation"/> for Payment DirectAuthorization.
    /// </summary>
    public static readonly LinkRelation DirectAuthorization = new LinkRelation(nameof(DirectAuthorization), PaymentResourceOperations.DirectAuthorization);

    /// <summary>
    /// Instantiates a new <seealso cref="LinkRelation"/> where both name and value are <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The name/value combo.</param>
    public LinkRelation(string name) : base(name, name) { }

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