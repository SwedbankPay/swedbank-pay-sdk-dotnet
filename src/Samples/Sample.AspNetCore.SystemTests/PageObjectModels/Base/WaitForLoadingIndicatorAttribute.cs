using Atata;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Base
{
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

    public class WaitForPaymentProcessingAttribute : WaitForElementAttribute
    {
        public WaitForPaymentProcessingAttribute(TriggerEvents on = TriggerEvents.Init)
            : base(WaitBy.Class, "loader", Until.VisibleThenMissingOrHidden, on)
        {
            PresenceTimeout = 5;
            ThrowOnPresenceFailure = false;
            AbsenceTimeout = 30;
        }
    }
}