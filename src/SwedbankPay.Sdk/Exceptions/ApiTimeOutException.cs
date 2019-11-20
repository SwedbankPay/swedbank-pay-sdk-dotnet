namespace SwedbankPay.Sdk.Exceptions
{
    using System;
    using System.Threading.Tasks;

    public class ApiTimeOutException : Exception
    {
        public ApiTimeOutException(TaskCanceledException te) : base("Timed out when calling SwedbankPay", te)
        {

        }
    }
}