using System;

namespace SwedbankPay.Sdk.Exceptions
{
    public class NoOperationsLeftException : Exception
    {
        public NoOperationsLeftException()
            : base("No available operations. Check state.")
        {
        }
    }
}