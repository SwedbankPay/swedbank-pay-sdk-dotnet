namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Payer;

internal record DeviceDto
{
    public int DetectionAccuracy { get; init; }
    public string? IpAddress { get; init; }
    public string? UserAgent { get; init; }
    public string? DeviceType { get; init; }
    public string? HardwareFamily { get; init; }
    public string? HardwareName { get; init; }
    public string? HardwareVendor { get; init; }
    public string? PlatformName { get; init; }
    public string? PlatformVendor { get; init; }
    public string? PlatformVersion { get; init; }
    public string? BrowserName { get; init; }
    public string? BrowserVendor { get; init; }
    public string? BrowserVersion { get; init; }
    public bool BrowserJavaEnabled { get; init; }

    public Device Map()
    {
        return new Device(this);
    }
}