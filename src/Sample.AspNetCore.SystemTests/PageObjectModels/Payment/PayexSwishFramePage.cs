using Atata;
using Sample.AspNetCore.SystemTests.PageObjectModels.Base;
using Sample.AspNetCore.SystemTests.PageObjectModels.ThankYou;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Payment
{
    using _ = PayexSwishFramePage;

    [WaitForLoadingIndicator]
    public class PayexSwishFramePage : Page<_>
    {
        [FindById("msisdnInput")]
        public TelInput<_> SwishNumber { get; set; }

        [FindById("px-submit")]
        public ButtonDelegate<ThankYouPage, _> Pay { get; set; }
    }
}
