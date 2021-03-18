using SwedbankPay.Sdk.PaymentInstruments.Card;
using SwedbankPay.Sdk.PaymentInstruments.Swish;

namespace Sample.AspNetCore.Models.ViewModels
{
    public class PaymentMenuViewModel
    {
        public ICardPaymentOperations CardOperations { get; set; }
        public ISwishPaymentOperations SwishOperations { get; set; }
        public string PaymentLink { get; set; }
        public string JsSource { get; set; }
    }
}
