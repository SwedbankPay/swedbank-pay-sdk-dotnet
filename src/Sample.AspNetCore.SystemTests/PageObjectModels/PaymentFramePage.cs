using Atata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.AspNetCore.SystemTests.PageObjectModels
{
    using _ = PaymentFramePage;

    public class PaymentFramePage : Page<_>
    {
        [WaitFor(Until.VisibleThenMissingOrHidden, PresenceTimeout = 2, ThrowOnAbsenceFailure = false, ThrowOnPresenceFailure = false)]
        [FindByClass("px-loader-circle")]
        public Control<_> Loader { get; set; }

        [ControlDefinition("div")]
        public class PayexItem : Control<_>
        {
            [FindByClass("span"), FindByIndex(0)]
            public Text<_> Title { get; private set; }

            [WaitFor(Until.Visible, TriggerEvents.BeforeAccess)]
            public Frame<PayexFramePage, _> PaymentFrame { get; private set; }
        }

        [FindById("payex-container")]
        public PayexItem CardPayment { get; set; }
    }
}
