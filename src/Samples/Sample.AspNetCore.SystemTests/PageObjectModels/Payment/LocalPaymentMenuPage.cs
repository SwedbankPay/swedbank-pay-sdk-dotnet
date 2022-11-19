using Atata;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Payment
{
    using _ = LocalPaymentMenuPage;

    public class LocalPaymentMenuPage : Page<_>
    {
        [FindById("creditCard")]
        public Button<_> CreditCard { get; private set; }

        [FindById("swish")]
        public Button<_> Swish { get; private set; }

        [FindById("invoice")]
        public Button<_> Invoice { get; private set; }

        [FindById("trustly")]
        public Button<_> Trustly { get; private set; }

        [FindById("recurring")]
        public Button<_> Recurring { get; private set; }

        [WaitFor(Until.Visible, TriggerEvents.BeforeAccess)]
        public Frame<_> PaymentFrame { get; private set; }
    }
}
