using Atata;

using Sample.AspNetCore.SystemTests.PageObjectModels.Orders;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Base
{
    public class Header<TOwner> : Control<TOwner>
        where TOwner : BasePage<TOwner>
    {
        [WaitSeconds(0.5, TriggerEvents.AfterClick)]
        [FindByAutomation("button", "button-clearorders")]
        public Button<TOwner> ClearOrders { get; private set; }

        [WaitSeconds(1, TriggerEvents.BeforeClick)]
        [FindByContent("Orders")] public LinkDelegate<OrdersPage, TOwner> Orders { get; private set; }

        [FindByContent("Products")] public LinkDelegate<ProductsPage, TOwner> Products { get; private set; }
    }
}