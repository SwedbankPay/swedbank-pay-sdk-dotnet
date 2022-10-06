/**
 * Adopted from https://www.hanselman.com/blog/RealBrowserIntegrationTestingWithSeleniumStandaloneChromeAndASPNETCore21.aspx
 * and https://blog-bertrand-thomas.devpro.fr/2020/01/27/fix-breaking-change-asp-net-core-3-integration-tests-selenium/
 */
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.AspNetCore.Models;
using System;
using System.IO;
using System.Linq;

namespace Sample.AspNetCore.SystemTests.Test.Base
{
    public class TestWebApplicationFactory: WebApplicationFactory<Startup>
    {
        public string RootUri { get; set; } //Save this use by tests

        private string _sampleProjectLocation;
        IWebHost _host;

        public TestWebApplicationFactory()
        {
            IConfigurationRoot configRoot = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json", true)
                .AddUserSecrets<TestBase>(true)
                .AddEnvironmentVariables()
                .Build();
                
            _sampleProjectLocation = configRoot.GetSection("SampleWebsitePath").Value;

            Console.WriteLine(_sampleProjectLocation);

            ClientOptions.BaseAddress = new Uri("https://localhost:5001"); //will follow redirects by default

            CreateServer(CreateWebHostBuilder());
            
            Console.WriteLine("Webhost created");
        }

        protected override TestServer CreateServer(IWebHostBuilder builder)
        {
            //Real TCP port
            _host = builder.Build();
            _host.Start();
            
            Console.WriteLine("Webhost started");

            RootUri = _host.ServerFeatures.Get<IServerAddressesFeature>().Addresses.LastOrDefault();
            using (var scope = _host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                ProductGenerator.Initialize(services);
            }

            //Fake Server we won't use...this is lame. Should be cleaner, or a utility class
            return new TestServer(new WebHostBuilder().UseStartup<Startup>());
        }

        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            var builder = WebHost.CreateDefaultBuilder(Array.Empty<string>());
            builder.UseStartup<Startup>();
            var contentRoot = _sampleProjectLocation;
            if (Directory.Exists(contentRoot))
            {
                Console.WriteLine("Directory exist");
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
