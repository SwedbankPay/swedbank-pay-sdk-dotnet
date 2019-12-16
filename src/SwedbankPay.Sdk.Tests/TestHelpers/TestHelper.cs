using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using Moq;

namespace SwedbankPay.Sdk.Tests.TestHelpers
{
    public class TestHelper
    {

        public static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {
            #if DEBUG
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", true)
                .AddUserSecrets("55739ea0-5447-45e4-b35e-e0412f172f5f")
                .Build();

            #elif RELEASE

            var json = $@"{{ ""SwedbankPayConnectionSettings"": {{ ""ApiBaseUrl"": ""{Environment.GetEnvironmentVariable("SwedbankPayConnectionSettings.ApiBaseUrl", EnvironmentVariableTarget.User)}"",""Token"": ""{Environment.GetEnvironmentVariable("SwedbankPayConnectionSettings.Token", EnvironmentVariableTarget.User)}""}},""Urls"": {{""TermsOfServiceUrl"": ""{Environment.GetEnvironmentVariable("Urls.TermsOfServiceUrl", EnvironmentVariableTarget.User)}"",""CallBackUrl"": """",""CancelUrl"": ""{Environment.GetEnvironmentVariable("Urls.CancelUrl", EnvironmentVariableTarget.User)}"",""CompleteUrl"": ""{Environment.GetEnvironmentVariable("Urls.CompleteUrl", EnvironmentVariableTarget.User)}"",""LogoUrl"": """",""HostUrls"": [ ""{Environment.GetEnvironmentVariable("Urls.HostUrls", EnvironmentVariableTarget.User)}"" ]}}}}";
            var memoryJsonFile = new MemoryFileInfo("config.json", Encoding.UTF8.GetBytes(json), DateTimeOffset.Now);
            var memoryFileProvider = new MockFileProvider(memoryJsonFile);

            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile(memoryFileProvider, "config.json", false, false)
                .Build();

            #endif
        }



        public static SwedbankPayConnectionSettings GetSwedbankPayConnectionSettings(string outputPath)
        {
            var configuration = new SwedbankPayConnectionSettings();
           
            var iConfig = GetIConfigurationRoot(outputPath);

            iConfig
                .GetSection("SwedbankPayConnectionSettings")
                .Bind(configuration);

            return configuration;
        }


        public static Urls GetUrls(string outputPath)
        {
            var configuration = new UrlsOptions();
            
            var iConfig = GetIConfigurationRoot(outputPath);

            iConfig
                .GetSection("Urls")
                .Bind(configuration);

            return new Urls(configuration.HostUrls, configuration.CompleteUrl, configuration.TermsOfServiceUrl, configuration.CancelUrl,
                            configuration.PaymentUrl, configuration.CallbackUrl, configuration.LogoUrl);
        }
    }

    public class MockFileProvider : IFileProvider
    {
        private IEnumerable<IFileInfo> _files;
        private Dictionary<string, IChangeToken> _changeTokens;

        public MockFileProvider()
        { }

        public MockFileProvider(params IFileInfo[] files)
        {
            _files = files;
        }

        public MockFileProvider(params KeyValuePair<string, IChangeToken>[] changeTokens)
        {
            _changeTokens = changeTokens.ToDictionary(
                changeToken => changeToken.Key,
                changeToken => changeToken.Value,
                StringComparer.Ordinal);
        }

        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            var contents = new Mock<IDirectoryContents>();
            contents.Setup(m => m.Exists).Returns(true);

            if (string.IsNullOrEmpty(subpath))
            {
                contents.Setup(m => m.GetEnumerator()).Returns(_files.GetEnumerator());
                return contents.Object;
            }

            var filesInFolder = _files.Where(f => f.Name.StartsWith(subpath, StringComparison.Ordinal));
            if (filesInFolder.Any())
            {
                contents.Setup(m => m.GetEnumerator()).Returns(filesInFolder.GetEnumerator());
                return contents.Object;
            }
            return NotFoundDirectoryContents.Singleton;
        }

        public IFileInfo GetFileInfo(string subpath)
        {
            var file = _files.FirstOrDefault(f => f.Name == subpath);
            return file ?? new NotFoundFileInfo(subpath);
        }

        public IChangeToken Watch(string filter)
        {
            if (_changeTokens != null && _changeTokens.ContainsKey(filter))
            {
                return _changeTokens[filter];
            }
            return NullChangeToken.Singleton;
        }
    }

    public class MemoryFileInfo : IFileInfo
    {
        private readonly byte[] _content;

        public MemoryFileInfo(string name, byte[] content, DateTimeOffset timestamp)
        {
            Name = name;
            _content = content;
            LastModified = timestamp;
        }

        public bool Exists => true;

        long IFileInfo.Length => _content.LongLength;

        public string PhysicalPath => null;

        public string Name { get; }

        public DateTimeOffset LastModified { get; }

        public bool IsDirectory => false;

        public Stream CreateReadStream()
        {
            return new MemoryStream(_content);
        }
    }
}