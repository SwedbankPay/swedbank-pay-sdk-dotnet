using Atata;

using Sample.AspNetCore.SystemTests.PageObjectModels.Base;
using Sample.AspNetCore.SystemTests.PageObjectModels.Payment;
using Sample.AspNetCore.SystemTests.PageObjectModels.Verify;

namespace Sample.AspNetCore.SystemTests.PageObjectModels
{
    using _ = ProductsPage;

    public class ProductsPage : BasePage<_>
    {
        [FindByXPath("table[2]")] public Table<ProductBasketItem, _> CartProducts { get; set; }

        [FindByClass("alert alert-success")] public Text<_> Message { get; set; }

        [FindByXPath("table[1]")] public Table<ProductItem, _> Products { get; set; }

        [FindByAutomation("a", "button-checkout", Index = 0)]
        public LinkDelegate<PaymentPage, _> StandardCheckout { get; set; }

        [FindByAutomation("a", "button-checkout", Index = 1)]
        public LinkDelegate<PaymentPage, _> AnonymousCheckout { get; set; }

        [FindByAutomation("a", "button-checkout", Index = 2)]
        public LinkDelegate<LocalPaymentMenuPage, _> LocalPaymentMenu { get; set; }

        [FindByXPath("table[2]//tfoot[1]//td[2]")]
        public Text<_> TotalAmount { get; set; }

        [FindById("goToVerify")] public LinkDelegate<VerifyPage, _> Verify {get; set;}

        public class ProductBasketItem : TableRow<_>
        {
            [FindByXPath("td[2]")] public Text<_> Name { get; set; }

            [FindByXPath("td[3]")] public Text<_> Price { get; set; }

            [FindByName("Quantity")] public NumberInput<_> Quantity { get; set; }

            [Wait(0.5, TriggerEvents.AfterClick)]
            [FindByXPath("button[1]")]
            public Button<_> Update { get; set; }
        }

        public class ProductItem : TableRow<_>
        {
            [FindByAutomation("a", "button-addtocart")]
            public Link<_> AddToCart { get; set; }

            [FindByXPath("td[1]")] public Text<_> Name { get; set; }

            [FindByXPath("a[1]")] public Link<_> Open { get; set; }

            [FindByXPath("td[5]")] public Text<_> Price { get; set; }
        }
    }
}