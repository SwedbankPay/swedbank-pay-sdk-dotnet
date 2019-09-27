namespace SwedbankPay.Client.Models.Callbacks
{
    public class CallbackContainer
    {
        public Callback Payment { get; set; }
        public Callback Transaction { get; set; }
    }
}
