using Microsoft.Extensions.FileProviders;
using System;
using System.IO;

namespace SwedbankPay.Sdk.Tests.TestHelpers
{
    public class MemoryFileInfo : IFileInfo
    {
        private readonly byte[] content;

        public MemoryFileInfo(string name, byte[] content, DateTimeOffset timestamp)
        {
            Name = name;
            this.content = content;
            LastModified = timestamp;
        }

        public bool Exists => true;

        long IFileInfo.Length => this.content.LongLength;

        public string PhysicalPath => null;

        public string Name { get; }

        public DateTimeOffset LastModified { get; }

        public bool IsDirectory => false;

        public Stream CreateReadStream()
        {
            return new MemoryStream(this.content);
        }
    }
}