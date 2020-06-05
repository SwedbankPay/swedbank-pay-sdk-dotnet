using Atata;

using Sample.AspNetCore.SystemTests.PageObjectModels.Base;
using Sample.AspNetCore.SystemTests.PageObjectModels.ThankYou;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Payment
{
    using _ = PayexSwishFramePage;

    public class PayexSwishFramePage : Page<_>
    {
        [Wait(2, TriggerEvents.BeforeClick)]
        [FindById("px-submit")]
        public Button<ThankYouPage, _> Pay { get; set; }

        [FindById("msisdnInput")] public TelInput<_> SwishNumber { get; set; }
    }
}