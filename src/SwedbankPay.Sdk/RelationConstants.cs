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
    public static class ConsumerResourceOperations
    {
        public const string ViewConsumerIdentification = "view-consumer-identification";
        public const string RedirectConsumerIdentification = "redirect-consumer-identification";
    }

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

    public static class PaymentResourceOperations
    {
        public const string UpdatePaymentAbort = "update-payment-abort";
        public const string CreateCapture = "create-capture";
        public const string CreateCancellation = "create-cancellation";
        public const string RedirectAuthorization = "redirect-authorization";
        public const string CreateReversal = "create-reversal";
        public const string PaidPayment = "paid-payment";
    }

}