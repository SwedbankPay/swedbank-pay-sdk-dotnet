namespace SwedbankPay.Sdk
{
    internal class NoOpLogger : ILogSwedbankPayHttpResponse
    {
        public void LogSwedbankPayResponse(string responseBody)
        {
        }
    }
}