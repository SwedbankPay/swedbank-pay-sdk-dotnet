namespace SwedbankPay.Client.Exceptions
{
    using System;

    public class InvalidPaymentException : BadRequestException
    {
        public InvalidPaymentException(Exception e) : base(e)
        {
        }

        public InvalidPaymentException(string message) : base(message)
        {
        }
    }
}