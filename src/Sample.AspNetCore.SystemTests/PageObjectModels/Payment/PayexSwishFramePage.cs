using Atata;
using Sample.AspNetCore.SystemTests.PageObjectModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Payment
{
     using _ = PayexSwishFramePage;

    [WaitForLoadingIndicator]
    public class PayexSwishFramePage : Page<_>
    {
        [FindById("msisdnInput")]
        public TelInput<_> SwishNumber { get; set; }

        [FindById("px-submit")]
        public ButtonDelegate<ValidationPage, _> Pay { get; set; }
    }
}
