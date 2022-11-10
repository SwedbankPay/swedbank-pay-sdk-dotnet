using System;

namespace SwedbankPay.Sdk.PaymentOrders;

/// <summary>
/// Use to have sub-resources of a payment order be automatically expanded/filled
/// when using a GET request for a payment order.
/// </summary>
[Flags]
public enum PaymentOrderExpand
{
    /// <summary>
    /// Don't expand any fields.
    /// </summary>
    None = 0,

    /// <summary>
    /// Expand the Urls sub-reasource.
    /// </summary>
    Urls = 1,

    /// <summary>
    /// Expand the PayeeInfo sub-reasource.
    /// </summary>
    PayeeInfo = 2,

    /// <summary>
    /// Expand the Settings sub-reasource.
    /// </summary>
    Settings = 4,

    /// <summary>
    /// Expand the Payers sub-reasource.
    /// </summary>
    Payers = 8,

    /// <summary>
    /// Expand the OrderItems sub-reasource.
    /// </summary>
    OrderItems = 16,

    /// <summary>
    /// Expand the Metadata sub-reasource.
    /// </summary>
    Metadata = 32,

    /// <summary>
    /// Expand the Payments sub-reasource.
    /// </summary>
    Payments = 64,

    /// <summary>
    /// Expand the CurrentPayment sub-reasource.
    /// </summary>
    CurrentPayment = 128,

    /// <summary>
    /// Expand All sub-reasources.
    /// </summary>
    All = 255
}