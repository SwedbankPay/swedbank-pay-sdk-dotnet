using Atata;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Payment
{
    using _ = PayexTrustlyFramePage;

    public class PayexTrustlyFramePage : Page<_>
    {
        [Wait(2, TriggerEvents.BeforeClick)]
        [FindById("px-submit")]
        public Button<TrustlyPaymentPage, _> Submit { get; set; }

    }
}