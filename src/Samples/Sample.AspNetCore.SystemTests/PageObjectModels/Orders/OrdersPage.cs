using Atata;

using Sample.AspNetCore.SystemTests.PageObjectModels.Base;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Orders
{
    using _ = OrdersPage;

    public class OrdersPage : BasePage<_>
    {
        public class ActionRow : TableRow<_>
        {
            [FindByColumnIndex(3)]
            public Link<_, _> ExecuteAction { get; set; }

            [FindByColumnIndex(2)]
            public Text<_> Href { get; set; }

            [FindByColumnIndex(0)]
            public Text<_> HttpOperation { get; set; }

            [FindByColumnIndex(1)]
            public Text<_> Name { get; set; }
        }

        [FindFirst] 
        public Table<ActionRow, _> Actions { get; set; }

        [FindByXPath("dd[2]")] public Text<_> PaymentLink { get; set; }

        [FindByXPath("dd[1]")] public Text<_> PaymentOrderLink { get; set; }
    }
}