using Atata;

using Sample.AspNetCore.SystemTests.PageObjectModels.Base;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Orders
{
    using _ = OrdersPage;

    public class OrdersPage : BasePage<_>
    {
        [FindFirst] public Table<ActionRow, _> Actions { get; set; }

        [FindByXPath("dd[2]")] public Text<_> PaymentLink { get; set; }

        [FindByXPath("dd[1]")] public Text<_> PaymentOrderLink { get; set; }

        public class ActionRow : TableRow<_>
        {
            [FindByIndex(0)] public Link<_, _> ExecuteAction { get; set; }

            [FindByIndex(2)] public Text<_> Href { get; set; }

            [FindByIndex(0)] public Text<_> HttpOperation { get; set; }

            [FindByIndex(1)] public Text<_> Name { get; set; }
        }
    }
}