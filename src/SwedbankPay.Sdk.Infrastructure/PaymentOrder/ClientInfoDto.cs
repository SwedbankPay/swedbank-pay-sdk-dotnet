using System.Reflection;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder;

public record ClientInfoDto
{
    public string IntegrationSdkName { get; } = "DOTNET";
    public string? IntegrationSdkVersion { get; } = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version;
}