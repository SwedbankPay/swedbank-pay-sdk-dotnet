using Atata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.AspNetCore.SystemTests.PageObjectModels
{
    using _ = PaymentPage;

    public class PaymentPage : Page<_>
    {
        public Frame<PaymentFramePage, _> PaymentMethodsFrame { get; set; }
    }
}
