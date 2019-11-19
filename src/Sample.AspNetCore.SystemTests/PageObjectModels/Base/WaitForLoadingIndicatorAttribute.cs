namespace Sample.AspNetCore.SystemTests.PageObjectModels.Base
{
    using Atata;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class WaitForLoadingIndicatorAttribute : WaitForElementAttribute
    {
        public WaitForLoadingIndicatorAttribute(TriggerEvents on = TriggerEvents.Init)
            : base(WaitBy.Class, "px-loader-circle", Until.VisibleThenMissingOrHidden, on)
        {
            PresenceTimeout = 3;
            ThrowOnPresenceFailure = false;
            AbsenceTimeout = 20;
        }
    }
}
