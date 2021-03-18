using Atata;

using Sample.AspNetCore.SystemTests.PageObjectModels.Base;
using Sample.AspNetCore.SystemTests.PageObjectModels.ThankYou;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Payment
{
    using _ = PayexInvoiceFramePage;

    public class PayexInvoiceFramePage : Page<_>
    {
        [FindById("emailInput")] public EmailInput<_> Email { get; set; }

        [FindById("px-submit")] public Button<_> Next { get; set; }

        [WaitForElement(WaitBy.Id, "consumer-input", Until.Visible, TriggerEvents.BeforeClick)]
        [Wait(2, TriggerEvents.BeforeClick)]
        [FindById("px-submit")]
        public Button<ThankYouPage, _> Pay { get; set; }

        [Wait(2, TriggerEvents.BeforeFocus)]
        [FindById("ssnInput")] public TelInput<_> PersonalNumber { get; set; }

        [FindById("msisdnInput")] public TelInput<_> PhoneNumber { get; set; }

        public ValidationIconList<_> ValidationIcons { get; set; }

        [FindById("zipCodeInput")] public TelInput<_> ZipCode { get; set; }
    }
}