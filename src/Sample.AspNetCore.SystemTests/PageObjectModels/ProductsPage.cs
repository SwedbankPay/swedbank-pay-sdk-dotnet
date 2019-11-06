using Atata;
using Sample.AspNetCore.SystemTests.PageObjectModels.Base;

namespace Sample.AspNetCore.SystemTests.PageObjectModels
{
    using _ = ProductsPage;

    public class ProductsPage : Page<_>
    {
        [ControlDefinition("div[@automation='']", ComponentTypeName = "Products")]
        public class ProductsSection<TOwner> : Control<TOwner> where TOwner : PageObject<TOwner>
        {
            [ControlDefinition("div[@automation='']", ComponentTypeName = "Product")]
            public class ProductItem : Control<_> 
            {
                [FindByAutomation("span", "")]
                public Text<_> Name { get; set; }

                [FindByAutomation("span", "")]
                public Text<_> Price { get; set; }

                [FindByAutomation("button", "")]
                public Button<_> AddToCart { get; set; }

                [FindByAutomation("button", "")]
                public Button<_> Open { get; set; }
            }

            [FindByAutomation("ul", "")]
            public UnorderedList<ProductItem, _> List { get; set; }
        }

        [ControlDefinition("div[@automation='']", ComponentTypeName = "Cart")]
        public class CartSection<TOwner> : Control<TOwner> where TOwner : PageObject<TOwner>
        {
            [ControlDefinition("div[@automation='']", ComponentTypeName = "Selected Product")]
            public class ProductItem : Control<_>
            {
                [FindByAutomation("span", "")]
                public Text<_> Name { get; set; }

                [FindByAutomation("span", "")]
                public Text<_> Price { get; set; }

                [FindByAutomation("input", "")]
                public TextInput<_> Quantity { get; set; }

                [FindByAutomation("button", "")]
                public Button<_> Update { get; set; }
            }

            [FindByAutomation("ul", "")]
            public UnorderedList<ProductItem, _> Products { get; set; }
        }

        public ProductsSection<_> Products { get; set; }

        public CartSection<_> Cart { get; set; }

        [FindByAutomation("button", "")]
        public ButtonDelegate<PaymentFramePage, _> Checkout { get; set; }

    }
}
