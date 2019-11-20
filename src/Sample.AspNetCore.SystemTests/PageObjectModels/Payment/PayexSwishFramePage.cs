namespace Sample.AspNetCore.SystemTests.PageObjectModels.Payment
{
    using Atata;
    using Sample.AspNetCore.SystemTests.PageObjectModels.Base;
    using Sample.AspNetCore.SystemTests.PageObjectModels.ThankYou;
    using _ = PayexSwishFramePage;

    [WaitForLoadingIndicator]
    public class PayexSwishFramePage : Page<_>
    {
        [FindById("msisdnInput")]
        public TelInput<_> SwishNumber { get; set; }

        [WaitFor(Until.VisibleThenMissingOrHidden, TriggerEvents.AfterClick, AbsenceTimeout = 30)]
        [Wait(0.5, TriggerEvents.BeforeClick)]
        [FindById("px-submit")]
        public ButtonDelegate<ThankYouPage, _> Pay { get; set; }
    }
}
