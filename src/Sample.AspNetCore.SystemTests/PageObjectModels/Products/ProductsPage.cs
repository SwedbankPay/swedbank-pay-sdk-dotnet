using Atata;
using Sample.AspNetCore.SystemTests.PageObjectModels.Base;

namespace Sample.AspNetCore.SystemTests.PageObjectModels
{
    using _ = ProductsPage;

    public class ProductsPage : Page<_>
    {
        public class ProductItem : TableRow<_>
        {
            //[FindByAutomation("span", "")]
            [FindByXPath("td[1]")]
            public Text<_> Name { get; set; }

            //[FindByAutomation("span", "")]
            [FindByXPath("td[4]")]
            public Text<_> Price { get; set; }

            //[FindByAutomation("button", "")]
            [FindByAutomation("a", "button-addtocart")]
            public Link<_> AddToCart { get; set; }

            //[FindByAutomation("button", "")]
            [FindByXPath("a[1]")]
            public Link<_> Open { get; set; }
        }

        public class ProductBasketItem : TableRow<_>
        {
            //[FindByAutomation("span", "")]
            [FindByXPath("td[2]")]
            public Text<_> Name { get; set; }

            //[FindByAutomation("span", "")]
            [FindByXPath("td[3]")]
            public Text<_> Price { get; set; }

            //[FindByAutomation("input", "")]
            [FindByName("Quantity")]
            public Input<string, _> Quantity { get; set; }

            //[FindByAutomation("button", "")]
            [FindByXPath("button[1]")]
            public Button<_> Update { get; set; }
        }

        [FindByXPath("table[1]")]
        public Table<ProductItem, _> Products { get; set; }

        [FindByXPath("table[2]")]
        public Table<ProductBasketItem, _> CartProducts { get; set; }

        [FindByAutomation("a", "button-checkout", Index = 1)]
        //[FindByContent("Checkout")]
        public LinkDelegate<PaymentPage, _> Checkout { get; set; }

    }
}
