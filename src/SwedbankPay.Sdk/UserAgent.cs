using System.Reflection;

namespace SwedbankPay.Sdk
{
    public static class UserAgent
    {
        public static string Default;
        static UserAgent()
        {
            Default = $"swedbankpay-sdk-dotnet/{Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion}";
        }
    }
}
