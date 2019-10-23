namespace SwedbankPay.Sdk
{
    internal class NoOpLogger : ILogPayExHttpResponse
    {
        public void LogPayExResponse(string responseBody)
        {
        }
    }
}