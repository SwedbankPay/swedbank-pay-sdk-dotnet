using Atata;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Base
{
    public sealed class WaitForPaymentProcessingAttribute : WaitForElementAttribute
    {
        public WaitForPaymentProcessingAttribute(TriggerEvents on = TriggerEvents.Init)
            : base(WaitBy.Class, "loader", Until.VisibleThenMissing, on)
        {
            PresenceTimeout = 3;
            ThrowOnPresenceFailure = false;
            AbsenceTimeout = 20;
        }
    }
}