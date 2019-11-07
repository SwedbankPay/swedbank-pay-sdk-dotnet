using Atata;
using Sample.AspNetCore.SystemTests.PageObjectModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Payment
{
    using _ = PayexInvoiceFramePage;

    [WaitForLoadingIndicator]
    public class PayexInvoiceFramePage : Page<_>
    {
        [FindById("ssnInput")]
        public TelInput<_> PersonalNumber { get; set; }

        [FindById("emailInput")]
        public TextInput<_> Email { get; set; }

        [FindById("msisdnInput")]
        public TelInput<_> PhoneNumber { get; set; }

        [FindById("zipCodeInput")]
        public TelInput<_> ZipCode { get; set; }

        [FindById("px-submit")]
        public ButtonDelegate<ValidationPage, _> Next { get; set; }
    }
}
