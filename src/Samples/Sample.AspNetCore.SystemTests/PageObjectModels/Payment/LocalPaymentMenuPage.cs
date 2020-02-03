using Atata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Payment
{
    using _ = LocalPaymentMenuPage;

    public class LocalPaymentMenuPage : Page<_>
    {
        [FindById("creditCard")]
        public Button<_> CreditCard { get; private set; }

        [FindById("swish")]
        public Button<_> Swish { get; private set; }

        [WaitFor(Until.Visible, TriggerEvents.BeforeAccess)]
        public Frame<_> PaymentFrame { get; private set; }
    }
}
