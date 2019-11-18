using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.AspNetCore.SystemTests.Test.Helpers
{
    public class PayexSwishInfo : PayexInfo
    {
        public string SwishNumber { get; private set; }

        public PayexSwishInfo(string swishNumber)
        {
            SwishNumber = swishNumber;
        }
    }
}
