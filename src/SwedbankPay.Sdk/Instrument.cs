using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk
{
    /// <summary>
    ///     Payment Instrument
    /// </summary>
    
    public enum Instrument
    {
        Invoice,
        MobilePay,
        CreditCard,
        Swish,
        Vipps,
        DirectDebit
    }
}
