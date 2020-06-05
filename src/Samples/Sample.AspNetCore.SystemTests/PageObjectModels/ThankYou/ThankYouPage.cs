using Atata;

using Sample.AspNetCore.SystemTests.PageObjectModels.Base;
using Sample.AspNetCore.SystemTests.Services;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.ThankYou
{
    using _ = ThankYouPage;

    public class ThankYouPage : BasePage<_>
    {
        [FindByContent(ResourceContentService.ThankYouH2)] public Text<_> ThankYou { get; private set; }
    }
}