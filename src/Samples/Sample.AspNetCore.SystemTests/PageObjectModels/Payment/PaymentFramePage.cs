using Atata;

namespace Sample.AspNetCore.SystemTests.PageObjectModels
{
    using _ = PaymentFramePage;

    public class PaymentFramePage : Page<_>
    {
        [WaitSeconds(2, TriggerEvents.BeforeClick)]
        [FindById("paymentmenu-container")]
        public ControlList<PayexItem, _> PaymentMethods { get; set; }

        [ControlDefinition("div", ContainingClass = "custom-menu-card")]
        public class PayexItem : Control<_>
        {
            [FindByClass("menu-card-title")] public Text<_> Name { get; private set; }

            [WaitFor(Until.Visible, TriggerEvents.BeforeAccess)]
            public Frame<_> PaymentFrame { get; private set; }
        }
    }
}