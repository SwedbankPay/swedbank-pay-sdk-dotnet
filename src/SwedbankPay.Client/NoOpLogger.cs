namespace SwedbankPay.Client
{
    internal class NoOpLogger : ILogPayExHttpResponse
    {
        public void LogPayExResponse(string responseBody)
        {
        }
    }
}