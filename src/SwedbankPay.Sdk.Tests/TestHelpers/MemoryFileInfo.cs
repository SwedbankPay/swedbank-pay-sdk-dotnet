using System;
using System.IO;
using Microsoft.Extensions.FileProviders;

namespace SwedbankPay.Sdk.Tests.TestHelpers
{
    public class MemoryFileInfo : IFileInfo
    {
        private readonly byte[] _content;

        public MemoryFileInfo(string name, byte[] content, DateTimeOffset timestamp)
        {
            Name = name;
            this._content = content;
            LastModified = timestamp;
        }

        public bool Exists => true;

        long IFileInfo.Length => this._content.LongLength;

        public string PhysicalPath => null;

        public string Name { get; }

        public DateTimeOffset LastModified { get; }

        public bool IsDirectory => false;

        public Stream CreateReadStream()
        {
            return new MemoryStream(this._content);
        }
    }
}