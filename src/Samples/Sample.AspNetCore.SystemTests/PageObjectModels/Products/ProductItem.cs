using Atata;

using Sample.AspNetCore.SystemTests.PageObjectModels.Base;

namespace Sample.AspNetCore.SystemTests.PageObjectModels
{
    using _ = ProductsPage;

    public class ProductItem : TableRow<_>
    {
        [FindByAutomation("a", "button-addtocart")]
        public Link<_> AddToCart { get; set; }

        [FindByXPath("td[1]")] public Text<_> Name { get; set; }

        [FindByXPath("a[1]")] public Link<_> Open { get; set; }

        [FindByXPath("td[5]")] public Text<_> Price { get; set; }
    }
}