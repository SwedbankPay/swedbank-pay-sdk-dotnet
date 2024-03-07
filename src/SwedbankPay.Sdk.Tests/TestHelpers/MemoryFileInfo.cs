using Microsoft.Extensions.FileProviders;

namespace SwedbankPay.Sdk.Tests.TestHelpers;

public class MemoryFileInfo : IFileInfo
{
    private readonly byte[] content;

    public MemoryFileInfo(string name, byte[] byteContent, DateTimeOffset timestamp)
    {
        Name = name;
        this.content = byteContent;
        LastModified = timestamp;
    }

    public bool Exists => true;

    long IFileInfo.Length => this.content.LongLength;

    public string? PhysicalPath => null;

    public string Name { get; }

    public DateTimeOffset LastModified { get; }

    public bool IsDirectory => false;

    public Stream CreateReadStream()
    {
        return new MemoryStream(this.content);
    }
}