namespace Sample.AspNetCore.SystemTests.PageObjectModels
{
    using Atata;
    using Sample.AspNetCore.SystemTests.PageObjectModels.Base;
    using Sample.AspNetCore.SystemTests.PageObjectModels.Payment;
    using _ = PaymentPage;

    public class PaymentPage : Page<_>
    {
        [FindById("paymentMenuFrame")]
        public Frame<PaymentFramePage, _> PaymentMethodsFrame { get; set; }

        public Frame<IdentificationFramePage, _> IdentificationFrame { get; set; }

        [FindByAutomation("button", "button-abort")]
        public ButtonDelegate<ProductsPage, _> Abort { get; set; }
    }
}
