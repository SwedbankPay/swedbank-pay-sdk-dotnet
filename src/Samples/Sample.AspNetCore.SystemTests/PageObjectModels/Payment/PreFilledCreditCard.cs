using Atata;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Payment
{
    using _ = PayexCardFramePage;
    public class PreFilledCreditCard : ListItem<_>
    {
        [FindByClass("prefill-info-data")]
        public Text<_> CreditCardNumber { get; set; }
    }
}