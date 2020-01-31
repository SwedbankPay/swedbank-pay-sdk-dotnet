using Atata;

namespace Sample.AspNetCore.SystemTests.PageObjectModels
{
    using _ = ProductsPage;

    public class ProductBasketItem : TableRow<_>
    {
        [FindByXPath("td[2]")] public Text<_> Name { get; set; }

        [FindByXPath("td[3]")] public Text<_> Price { get; set; }

        [FindByName("Quantity")] public NumberInput<_> Quantity { get; set; }

        [Wait(0.5, TriggerEvents.AfterClick)]
        [FindByXPath("button[1]")]
        public Button<_> Update { get; set; }
    }
}