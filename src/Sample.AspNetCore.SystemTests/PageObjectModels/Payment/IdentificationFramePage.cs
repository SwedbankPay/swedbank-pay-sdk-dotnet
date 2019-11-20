namespace Sample.AspNetCore.SystemTests.PageObjectModels.Payment
{
    using Atata;
    using Sample.AspNetCore.SystemTests.PageObjectModels.Base;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using _ = IdentificationFramePage;

    [WaitForLoadingIndicator]
    public class IdentificationFramePage : Page<_>
    {
        [FindById("email")]
        public EmailInput<_> Email { get; private set; }

        [FindById("msisdn")]
        public TelInput<_> PhoneNumber { get; private set; }

        [FindById("px-submit")]
        public Button<_> Next { get; private set; }
    }
}
