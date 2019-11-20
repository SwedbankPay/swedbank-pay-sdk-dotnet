namespace SwedbankPay.Sdk.Exceptions
{
    using System;

    public class NoOperationsLeftException : Exception
    {
        public NoOperationsLeftException() : base("No available operations. Check state.")
        {

        }
    }
}
