namespace SwedbankPay.Sdk.Models.Callbacks
{
    public class CallbackContainer
    {
        public Callback Payment { get; set; }
        public Callback Transaction { get; set; }
    }
}
