using Atata;
using Sample.AspNetCore.SystemTests.PageObjectModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Orders
{
    using _ = OrdersPage;

    public class OrdersPage : BasePage<_>
    {
        public class ActionRow : TableRow<_>
        {
            [FindByIndex(0)]
            public Text<_> HttpOperation { get; set; }

            [FindByIndex(1)]
            public Text<_> Name { get; set; }

            [FindByIndex(2)]
            public Text<_> Href { get; set; }

            [FindByIndex(0)]
            public Link<_, _> ExecuteAction { get; set; }
        }

        [FindByXPath("dd[1]")]
        public Text<_> PaymentOrderLink { get; set; }

        [FindByXPath("dd[2]")]
        public Text<_> PaymentLink { get; set; }

        [FindFirst]
        public Table<ActionRow, _> Actions { get; set; }
    }
}
