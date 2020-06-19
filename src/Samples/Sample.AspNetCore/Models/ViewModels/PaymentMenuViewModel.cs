namespace Sample.AspNetCore.Models.ViewModels
{
    public class PaymentMenuViewModel
    {
        public SwedbankPay.Sdk.Payments.CardPayments.CardPaymentOperations CardOperations { get; set; }
        public SwedbankPay.Sdk.Payments.SwishPayments.SwishPaymentOperations SwishOperations { get; set; }
        public string PaymentLink { get; set; }
        public string JsSource { get; set; }
    }
}
