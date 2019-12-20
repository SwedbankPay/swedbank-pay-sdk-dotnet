using System;
using System.Runtime.Serialization;

namespace SwedbankPay.Sdk.Exceptions
{
    [Serializable]
    public class BadRequestException : Exception
    {
        public BadRequestException(Exception e)
            : base(e.Message, e)
        {
        }


        public BadRequestException(string message)
            : base(message)
        {
        }
    }
}