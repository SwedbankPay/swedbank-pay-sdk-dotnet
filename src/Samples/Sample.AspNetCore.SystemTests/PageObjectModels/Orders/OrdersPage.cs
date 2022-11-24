using Atata;

using Sample.AspNetCore.SystemTests.PageObjectModels.Base;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Orders;

using _ = OrdersPage;

public class OrdersPage : BasePage<_>
{
    [ControlAutomationDefinition("div", automationAttribute: "div-order")]
    public class OrderItem : Control<_>
    {
        [FindFirst]
        public Table<ActionRow, _> Actions { get; set; }

        [FindByAutomation("dd", "div-paymentlink")] public Text<_> PaymentLink { get; set; }

        [FindByAutomation("dd", "div-paymentorderlink")] public Text<_> PaymentOrderLink { get; set; }

            [FindByAutomation("button", "button-clearorder")] public Button<HomePage, _> Clear { get; set; }
        }

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

        [FindByAutomation("div", "div-orders")]
        public ItemsControl<OrderItem, _> Orders { get; set; }

        [FindByClass("alert-success")]
        public Text<_> SuccessMessage { get; set; }
    }

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

    [FindByAutomation("div", "div-orders")]
    public ItemsControl<OrderItem, _> Orders { get; set; }
}