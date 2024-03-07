namespace SwedbankPay.Sdk.PaymentOrder.Payer;

public interface IDevice
{
    public int DetectionAccuracy { get; }
    public string? IpAddress { get; }
    public string? UserAgent { get; }
    public string? DeviceType { get; }
    public string? HardwareFamily { get; }
    public string? HardwareName { get; }
    public string? HardwareVendor { get; }
    public string? PlatformName { get; }
    public string? PlatformVendor { get; }
    public string? PlatformVersion { get; }
    public string? BrowserName { get; }
    public string? BrowserVendor { get; }
    public string? BrowserVersion { get; }
    public bool BrowserJavaEnabled { get; }
}