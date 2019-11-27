namespace Sample.AspNetCore.Constants
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
        public const string CreatePaymentOrderReversal = "create-paymentorder-reversal";
    }

}