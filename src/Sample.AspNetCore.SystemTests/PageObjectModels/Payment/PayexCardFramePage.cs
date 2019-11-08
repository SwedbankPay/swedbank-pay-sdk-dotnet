using Atata;
using Sample.AspNetCore.SystemTests.PageObjectModels.Base;

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

        [FindById("cvcInput")]
        public TelInput<_> Cvc { get; set; }

        [FindById("px-submit")]
        public ButtonDelegate<ValidationPage, _> Pay { get; set; }

        public ValidationIconList<_> ValidationIcons { get; set; }
    }
}
