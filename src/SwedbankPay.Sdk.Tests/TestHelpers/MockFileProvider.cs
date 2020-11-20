using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SwedbankPay.Sdk.Tests.TestHelpers
{
    public class MockFileProvider : IFileProvider
    {
        private readonly IEnumerable<IFileInfo> files;
        private readonly Dictionary<string, IChangeToken> changeTokens;

        public MockFileProvider()
        { }

        public MockFileProvider(params IFileInfo[] fileInfos)
        {
            this.files = fileInfos;
        }

        public MockFileProvider(params KeyValuePair<string, IChangeToken>[] mockChangeTokens)
        {
            this.changeTokens = mockChangeTokens.ToDictionary(
                changeToken => changeToken.Key,
                changeToken => changeToken.Value,
                StringComparer.Ordinal);
        }

        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            var contents = Substitute.For<IDirectoryContents>();
            contents.Exists.Returns(true);

            if (string.IsNullOrEmpty(subpath))
            {
                contents.GetEnumerator().Returns(this.files.GetEnumerator());
                return contents;
            }

            var filesInFolder = this.files.Where(f => f.Name.StartsWith(subpath, StringComparison.Ordinal));
            if (filesInFolder.Any())
            {
                contents.GetEnumerator().Returns(filesInFolder.GetEnumerator());
                return contents;
            }
            return NotFoundDirectoryContents.Singleton;
        }

        public IFileInfo GetFileInfo(string subpath)
        {
            var file = this.files.FirstOrDefault(f => f.Name == subpath);
            return file ?? new NotFoundFileInfo(subpath);
        }

        public IChangeToken Watch(string filter)
        {
            if (this.changeTokens != null && this.changeTokens.ContainsKey(filter))
            {
                return this.changeTokens[filter];
            }
            return NullChangeToken.Singleton;
        }
    }
}