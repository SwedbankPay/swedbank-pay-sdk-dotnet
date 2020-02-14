#region License

// --------------------------------------------------
// Copyright © Swedbank Pay. All Rights Reserved.
// 
// This software is proprietary information of Swedbank Pay.
// USE IS SUBJECT TO LICENSE TERMS.
// --------------------------------------------------

#endregion

namespace SwedbankPay.Sdk
{
    public static class PaymentResourceOperations
    {
        public const string Abort = "update-payment-abort";
        public const string CreateCapture = "create-capture";
        public const string CreateCancellation = "create-cancellation";
        public const string RedirectAuthorization = "redirect-authorization";
        public const string CreateReversal = "create-reversal";
        public const string PaidPayment = "paid-payment";
        public const string ViewAuthorization = "view-authorization";
        public const string DirectAuthorization = "direct-authorization";
        public const string RedirectVerification = "redirect-verification";
        public const string ViewVerification = "view-verification";
        public const string DirectVerification = "direct-verification";
        public const string CreateSale = "create-sale";
        public const string RedirectSale = "redirect-sale";
        public const string ViewSales = "view-sales";
        public const string ViewPayment = "view-payment";
        public const string AbortedPayment = "aborted-payment";
        public const string RedirectAppSwish = "redirect-app-swish";
    }
}