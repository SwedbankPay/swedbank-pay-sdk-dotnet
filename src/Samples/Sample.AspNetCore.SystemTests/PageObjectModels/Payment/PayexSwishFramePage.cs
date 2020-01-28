using Atata;

using Sample.AspNetCore.SystemTests.PageObjectModels.Base;
using Sample.AspNetCore.SystemTests.PageObjectModels.ThankYou;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Payment
{
    using _ = PayexSwishFramePage;

    [WaitForLoadingIndicator]
    public class PayexSwishFramePage : Page<_>
    {
        [WaitFor(Until.VisibleThenMissingOrHidden, TriggerEvents.AfterClick, AbsenceTimeout = 30)]
        [Wait(0.5, TriggerEvents.BeforeClick)]
        [FindById("px-submit")]
        public Button<ThankYouPage, _> Pay { get; set; }

        [FindById("msisdnInput")] public TelInput<_> SwishNumber { get; set; }
    }
}