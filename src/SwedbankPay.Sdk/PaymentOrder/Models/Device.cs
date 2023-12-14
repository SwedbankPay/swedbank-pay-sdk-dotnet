namespace SwedbankPay.Sdk.PaymentOrder.Models;

public class Device
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
    
    internal Device(DeviceDto dto)
    {
        DetectionAccuracy = dto.DetectionAccuracy;
        IpAddress = dto.IpAddress;
        UserAgent = dto.UserAgent;
        DeviceType = dto.DeviceType;
        HardwareFamily = dto.HardwareFamily;
        HardwareName = dto.HardwareName;
        HardwareVendor = dto.HardwareVendor;
        PlatformName = dto.PlatformName;
        PlatformVendor = dto.PlatformVendor;
        PlatformVersion = dto.PlatformVersion;
        BrowserName = dto.BrowserName;
        BrowserVendor = dto.BrowserVendor;
        BrowserVersion = dto.BrowserVersion;
        BrowserJavaEnabled = dto.BrowserJavaEnabled;
    }
}