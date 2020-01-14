using Atata;

using Sample.AspNetCore.SystemTests.PageObjectModels.Orders;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Base
{
    public class Header<TOwner> : Control<TOwner>
        where TOwner : BasePage<TOwner>
    {
        [Wait(0.5, TriggerEvents.AfterClick)]
        [FindByAutomation("button", "button-clearorders")]
        public Button<TOwner> ClearOrders { get; private set; }

        [FindByContent("Orders")] public LinkDelegate<OrdersPage, TOwner> Orders { get; private set; }

        [FindByContent("Products")] public LinkDelegate<ProductsPage, TOwner> Products { get; private set; }
    }
}