using Atata;

using Sample.AspNetCore.SystemTests.PageObjectModels.Base;
using Sample.AspNetCore.SystemTests.PageObjectModels.Payment;

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
    }
}