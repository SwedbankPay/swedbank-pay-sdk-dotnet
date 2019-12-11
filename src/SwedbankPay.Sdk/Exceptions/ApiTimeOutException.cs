using System;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Exceptions
{
    public class ApiTimeOutException : Exception
    {
        public ApiTimeOutException(TaskCanceledException te)
            : base("Timed out when calling SwedbankPay", te)
        {
        }
    }
}