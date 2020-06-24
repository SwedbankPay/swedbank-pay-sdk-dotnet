/**
 * Adopted from https://www.hanselman.com/blog/RealBrowserIntegrationTestingWithSeleniumStandaloneChromeAndASPNETCore21.aspx
 * and https://blog-bertrand-thomas.devpro.fr/2020/01/27/fix-breaking-change-asp-net-core-3-integration-tests-selenium/
 */
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.IO;
using System.Linq;

namespace Sample.AspNetCore.SystemTests.Test.Base
{
    public class TestWebApplicationFactory: WebApplicationFactory<Startup>
    {
        public string RootUri { get; set; } //Save this use by tests

        private const string SampleProjectLocation = "./../../../../Sample.AspNetCore";
        IWebHost _host;

        public TestWebApplicationFactory()
        {
            ClientOptions.BaseAddress = new Uri("https://localhost:5001"); //will follow redirects by default

            CreateServer(CreateWebHostBuilder());
        }

        protected override TestServer CreateServer(IWebHostBuilder builder)
        {
            //Real TCP port
            _host = builder.Build();
            _host.Start();
            RootUri = _host.ServerFeatures.Get<IServerAddressesFeature>().Addresses.LastOrDefault();

            //Fake Server we won't use...this is lame. Should be cleaner, or a utility class
            return new TestServer(new WebHostBuilder().UseStartup<Startup>());
        }

        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            var builder = WebHost.CreateDefaultBuilder(Array.Empty<string>());
            builder.UseStartup<Startup>();
            var contentRoot = SampleProjectLocation;
            if (Directory.Exists(contentRoot))
            {
                builder.UseContentRoot(contentRoot);
            }
            
            return builder;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                _host.Dispose();
            }
        }
    }
}
