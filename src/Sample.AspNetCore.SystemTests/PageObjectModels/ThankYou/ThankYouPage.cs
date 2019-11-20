namespace Sample.AspNetCore.SystemTests.PageObjectModels.ThankYou
{
    using Atata;
    using Sample.AspNetCore.SystemTests.PageObjectModels.Base;
    using Sample.AspNetCore.SystemTests.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using _ = ThankYouPage;

    [VerifyH2(ResourceContentService.ThankYouH2), WaitFor(Until.Visible, AbsenceTimeout = 15)]
    [VerifyContent(ResourceContentService.ThankYouContent), WaitFor(Until.Visible, AbsenceTimeout = 15)]
    public class ThankYouPage : BasePage<_>
    {
    }
}
