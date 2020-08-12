using Atata;
using NUnit.Framework;
using Sample.AspNetCore.SystemTests.PageObjectModels.Base;
using Sample.AspNetCore.SystemTests.PageObjectModels.ThankYou;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Payment
{
    using _ = PayexCardFramePage;

    public class PayexCardFramePage : Page<_>
    {
        public class PreFilledCreditCard : ListItem<_>
        {
            [FindByClass("prefill-info-data")]
            public Text<_> CreditCardNumber { get; set; }
        }

        [FindByClass("cards")] 
        public UnorderedList<PreFilledCreditCard, _> PreFilledCards { get; set; }

        [FindByClass("custom-link", Index = 0)]
        public Link<_> AddNewCard { get; set; }

        [FindById("panInput")]
        public TelInput<_> CreditCardNumber { get; set; }

        [FindById(TermMatch.Contains, "cvcInput")]
        public TelInput<_> Cvc { get; set; }

        [FindById("expiryInput")]
        public TelInput<_> ExpiryDate { get; set; }

        [Wait(2, TriggerEvents.BeforeClick)]
        [FindById("px-submit")]
        public Button<ThankYouPage, _> Pay { get; set; }

        [FindByCss("label.radiogroup-select:nth-child(3)")]
        public Clickable<_> CardTypeSelector { get; set; }
        

        public ValidationIconList<_> ValidationIcons { get; set; }
    }
}