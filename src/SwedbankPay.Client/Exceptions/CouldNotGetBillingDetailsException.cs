using SwedbankPay.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwedbankPay.Client.Exceptions
{
    public class CouldNotGetBillingDetailsException : Exception
    {
        public ProblemsContainer Problems { get; }
        public string Uri { get; }

        public CouldNotGetBillingDetailsException(string uri, ProblemsContainer problems) : base(problems.ToString())
        {
            Problems = problems;
            Uri = uri;
        }

        public CouldNotGetBillingDetailsException(string uri) : base("Could not find billing details for the given uri")
        {
            Problems = new ProblemsContainer(nameof(uri), "Could not find billing details for the given uri");
            Uri = uri;
        }
    }
}
