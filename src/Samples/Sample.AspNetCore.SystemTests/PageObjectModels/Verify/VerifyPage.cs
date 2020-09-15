using System;
using System.Collections.Generic;
using System.Text;
using Atata;
using Sample.AspNetCore.SystemTests.PageObjectModels.Base;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Verify
{
    using _ = VerifyPage;
    public class VerifyPage: BasePage<_>
    {
        [FindById("verifyButton")] public LinkDelegate<Payment.PayexCardFramePage, _> VerifyButton { get; set; }
    }
}
