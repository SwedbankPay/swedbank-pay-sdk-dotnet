using Atata;

using Sample.AspNetCore.SystemTests.PageObjectModels.Base;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Payment
{
    using _ = PaymentPage;

    public class PaymentPage : BasePage<_>
    {
        [FindByAutomation("button", "button-abort")]
        public ButtonDelegate<ProductsPage, _> Abort { get; set; }

        [FindByName("paymentOrderId", Visibility = Visibility.Any)]
        public HiddenInput<_> PaymentOrder { get; private set; }



        public Frame<IdentificationFramePage, _> IdentificationFrame { get; set; }

        [FindById("paymentMenuFrame")] public Frame<PaymentFramePage, _> PaymentMethodsFrame { get; set; }
    }
}