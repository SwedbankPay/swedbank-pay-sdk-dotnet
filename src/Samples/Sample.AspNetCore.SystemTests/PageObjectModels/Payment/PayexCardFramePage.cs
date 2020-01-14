using Atata;

using Sample.AspNetCore.SystemTests.PageObjectModels.Base;
using Sample.AspNetCore.SystemTests.PageObjectModels.ThankYou;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Payment
{
    using _ = PayexCardFramePage;

    [WaitForLoadingIndicator]
    public class PayexCardFramePage : Page<_>
    {
        public class PreFilledCreditCard : ListItem<_>
        {
            [FindByClass("prefill-info-data")]
            public Text<_> CreditCardNumber { get; set; }
        }

        [FindByClass("cards")] 
        public UnorderedList<PreFilledCreditCard, _> PreFilledCards { get; set; }

        [FindById("panInput")] public TelInput<_> CreditCardNumber { get; set; }

        [FindById(TermMatch.Contains, "cvcInput")]
        public TelInput<_> Cvc { get; set; }

        [FindById("expiryInput")] public TelInput<_> ExpiryDate { get; set; }

        [WaitForPaymentProcessing(TriggerEvents.AfterClick)]
        [FindById("px-submit")] public ButtonDelegate<ThankYouPage, _> Pay { get; set; }

        public ValidationIconList<_> ValidationIcons { get; set; }
    }
}