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
    public static class PaymentOrderResourceOperations
    {
        public const string UpdatePaymentOrderAbort = "update-paymentorder-abort";
        public const string UpdatePaymentOrderUpdateOrder = "update-paymentorder-updateorder";
        public const string RedirectPaymentOrder = "redirect-paymentorder";
        public const string ViewPaymentOrder = "view-paymentorder";
        public const string CreatePaymentOrderCapture = "create-paymentorder-capture";
        public const string CreatePaymentOrderCancel = "create-paymentorder-cancel";
        public const string RedirectVerification = "redirect-verification";
        public const string CreatePaymentOrderReversal = "create-paymentorder-reversal";
        public const string PaidPaymentOrder = "paid-paymentorder";
    }
}