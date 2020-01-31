using Atata;

using Sample.AspNetCore.SystemTests.PageObjectModels.Base;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Orders
{
    using _ = OrdersPage;

    public partial class OrdersPage : BasePage<_>
    {

        [FindFirst] 
        public Table<ActionRow, _> Actions { get; set; }

        [FindByXPath("dd[2]")] public Text<_> PaymentLink { get; set; }

        [FindByXPath("dd[1]")] public Text<_> PaymentOrderLink { get; set; }
    }
}