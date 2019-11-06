using Atata;

namespace Sample.AspNetCore.SystemTests.PageObjectModels
{
    using _ = PayexFramePage;

    public class PayexFramePage : Page<_>
    {
        [WaitFor(Until.VisibleThenMissingOrHidden, PresenceTimeout = 2, ThrowOnPresenceFailure = false)]
        [FindByClass("px-loader-circle")]
        public Control<_> Loader { get; set; }

        [FindById("panInput")]
        public TelInput<_> CreditCardNumber { get; set; }

        [FindById("expiryInput")]
        public TelInput<_> ExpiryDate { get; set; }

        [FindById("cvcInput")]
        public TelInput<_> Cvc { get; set; }

        [FindById("px-submit")]
        public Button<_> Pay { get; set; }
    }
}
