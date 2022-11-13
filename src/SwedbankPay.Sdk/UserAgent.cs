using System.Reflection;

namespace SwedbankPay.Sdk;

/// <summary>
/// Gets a static UserAgent string representing this software.
/// </summary>
public static class UserAgent
{
    /// <summary>
    /// A static default option.
    /// </summary>
    public static string Default { get; }
    static UserAgent()
    {
        Default = $"swedbankpay-sdk-dotnet/{Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version}";
    }
}
