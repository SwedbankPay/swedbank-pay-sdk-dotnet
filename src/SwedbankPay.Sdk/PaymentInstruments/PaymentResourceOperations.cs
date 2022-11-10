#region License

// --------------------------------------------------
// Copyright © Swedbank Pay. All Rights Reserved.
// 
// This software is proprietary information of Swedbank Pay.
// USE IS SUBJECT TO LICENSE TERMS.
// --------------------------------------------------

#endregion


namespace SwedbankPay.Sdk.PaymentInstruments;

/// <summary>
/// List of all currently known mapped operations in the payment instrument resources.
/// </summary>
public static class PaymentResourceOperations
{
    /// <summary>
    /// Updates the payment to a aborted state.
    /// </summary>
    public const string UpdatePaymentAbort = "update-payment-abort";
    
    /// <summary>
    /// Operation to capture the authorized funds for a payment.
    /// </summary>
    public const string CreateCapture = "create-capture";

    /// <summary>
    /// Cancels the currently authorized payment and amount.
    /// </summary>
    public const string CreateCancellation = "create-cancellation";

    /// <summary>
    /// Operation to redirect the payer to a authorization site.
    /// </summary>
    public const string RedirectAuthorization = "redirect-authorization";

    /// <summary>
    /// Creates a reversal on a already captured payment.
    /// </summary>
    public const string CreateReversal = "create-reversal";

    /// <summary>
    /// Operation returns information about a payment that has the <seealso cref="State.Paid"/>.
    /// </summary>
    public const string PaidPayment = "paid-payment";

    /// <summary>
    /// Operation to create a authorization.
    /// </summary>
    public const string CreateAuthorization = "create-authorization";

    /// <summary>
    /// Operation to view a authorization frame.
    /// </summary>
    public const string ViewAuthorization = "view-authorization";

    /// <summary>
    /// Operation to create a authorization using the Direct flow.
    /// </summary>
    public const string DirectAuthorization = "direct-authorization";

    /// <summary>
    /// Operation to redirect a payer to a authorization page.
    /// </summary>
    public const string RedirectVerification = "redirect-verification";

    /// <summary>
    /// Operation to view a verification frame.
    /// </summary>
    public const string ViewVerification = "view-verification";

    /// <summary>
    /// Operation to authorize a payment without the direct involvemnt of a payer.
    /// </summary>
    public const string DirectVerification = "direct-verification";

    /// <summary>
    /// Operation to create a sales transaction on a authorized sales transaction.
    /// </summary>
    public const string CreateSale = "create-sale";

    /// <summary>
    /// Operation to get a HREF that will redirect a payer to complete a sales transaction.
    /// </summary>
    public const string RedirectSale = "redirect-sale";

    /// <summary>
    /// Operation to embed a iframe for a sales transaction.
    /// </summary>
    public const string ViewSale = "view-sale";

    /// <summary>
    /// Operation to embed a iframe for a sales transaction.
    /// </summary>
    public const string ViewSales = "view-sales";

    /// <summary>
    /// Operation to embed a ifreme for viewing a payment.
    /// </summary>
    public const string ViewPayment = "view-payment";

    /// <summary>
    /// Operation to view the aborted reason on a payment.
    /// </summary>
    public const string AbortedPayment = "aborted-payment";

    /// <summary>
    /// Operation to redirect a payer to the swish app.
    /// Used for M-Commerce.
    /// </summary>
    public const string RedirectAppSwish = "redirect-app-swish";

    /// <summary>
    /// When using a direct authorization allows to overcharge the amount a payment has been authorized for.
    /// </summary>
    public const string UpdateAuthorizationOverchargedAmount = "update-authorization-overchargedamount";

    /// <summary>
    /// Creates a new <seealso cref="LegalAddress"/> for a payer.
    /// </summary>
    public const string CreateApprovedLegalAddress = "create-approved-legal-address";
}