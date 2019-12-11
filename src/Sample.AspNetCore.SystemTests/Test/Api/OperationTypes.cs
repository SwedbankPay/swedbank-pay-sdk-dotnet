namespace Sample.AspNetCore.SystemTests.Test.Api
{
    public class OperationTypes
    {
        public const string Cancel = "create-paymentorder-cancel";
        public const string Capture = "create-paymentorder-capture";
        public const string Reversal = "create-paymentorder-reversal";
        public const string Get = "paid-paymentorder";
    }
}