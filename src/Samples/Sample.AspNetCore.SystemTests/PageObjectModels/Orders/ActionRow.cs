using Atata;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Orders
{
    using _ = OrdersPage;

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
}