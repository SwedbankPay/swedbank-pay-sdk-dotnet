using Atata;

using Sample.AspNetCore.SystemTests.PageObjectModels.Base;
using Sample.AspNetCore.SystemTests.Services;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.ThankYou
{
    using _ = ThankYouPage;

    [VerifyH2(ResourceContentService.ThankYouH2)]
    [VerifyContent(ResourceContentService.ThankYouContent)]
    public class ThankYouPage : BasePage<_>
    {
    }
}