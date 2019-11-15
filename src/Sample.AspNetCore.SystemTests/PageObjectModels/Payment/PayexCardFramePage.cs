using Atata;
using Sample.AspNetCore.SystemTests.PageObjectModels.Base;
using Sample.AspNetCore.SystemTests.PageObjectModels.ThankYou;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Payment
{
    using _ = PayexCardFramePage;

    [WaitForLoadingIndicator]
    public class PayexCardFramePage : Page<_>
    {
        [FindById("panInput")]
        public TelInput<_> CreditCardNumber { get; set; }

        [FindById("expiryInput")]
        public TelInput<_> ExpiryDate { get; set; }

        [FindById(TermMatch.Contains, "cvcInput")]
        public TelInput<_> Cvc { get; set; }

        [FindById("px-submit")]
        public ButtonDelegate<ThankYouPage, _> Pay { get; set; }

        public ValidationIconList<_> ValidationIcons { get; set; }
    }
}
