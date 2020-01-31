using Atata;

using Sample.AspNetCore.SystemTests.PageObjectModels.Base;

namespace Sample.AspNetCore.SystemTests.PageObjectModels
{
    using _ = PaymentFramePage;

    [WaitForLoadingIndicator]
    public class PaymentFramePage : Page<_>
    {
        [Wait(1, TriggerEvents.BeforeClick)]
        [FindById("paymentmenu-container")]
        public ControlList<PayexItem, _> PaymentMethods { get; set; }
    }
}