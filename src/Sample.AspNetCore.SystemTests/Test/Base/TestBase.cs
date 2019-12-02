namespace Sample.AspNetCore.SystemTests.Test.Base
{
    using Atata;
    using BrowserStack;
    using Sample.AspNetCore.SystemTests.Services;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Remote;
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium.Edge;
    using static Sample.AspNetCore.SystemTests.Test.Base.Drivers;

    #if DEBUG
    [TestFixture(DriverAliases.Chrome)]
    #elif DEV
    [TestFixture(DriverAliases.Chrome)]
    //[TestFixtureSource(typeof(Profiles.ProfileDEV))]
    #elif RELEASE
    [TestFixture(DriverAliases.Chrome)]
    //[TestFixtureSource(typeof(Profiles.ProfileRelease))]
    #endif
    public abstract class TestBase
    {
        private readonly string _driverAlias;

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            #if DEBUG
            AtataContext.GlobalConfiguration.
                UseChrome().
                    WithOptions(DriverOptionsFactory.GetDriverOptions(Driver.Chrome) as ChromeOptions).
                UseFirefox().
                    WithOptions(DriverOptionsFactory.GetDriverOptions(Driver.Firefox) as FirefoxOptions).
                UseInternetExplorer().
                    WithOptions(DriverOptionsFactory.GetDriverOptions(Driver.InternetExplorer) as InternetExplorerOptions).
                AddNUnitTestContextLogging().
                WithMinLevel(Atata.LogLevel.Trace).
                TakeScreenshotOnNUnitError().
                    AddScreenshotFileSaving().
                        WithFolderPath(() => $@"Logs\{AtataContext.BuildStart:yyyy-MM-dd HH_mm_ss}").
                        WithFileName(screenshotInfo => $"{AtataContext.Current.TestName} - {screenshotInfo.PageObjectFullName}").
                UseTestName(() => $"[{_driverAlias}]{TestContext.CurrentContext.Test.Name}");
            #endif
        }

        [SetUp]
        public void SetUp()
        {
            #if DEBUG
            AtataContext.Configure()
                .UseDriver(_driverAlias)
                    .UseBaseUrl("https://localhost:44389/")
            .Build();
            AtataContext.Current.Driver.Maximize();
            #elif DEV
            AtataContext.Configure()
                .UseDriver(_driverAlias)
                    .UseBaseUrl("https://YourBaseUrl.com/")
            .Build();
            AtataContext.Current.Driver.Maximize();
            #elif RELEASE
            AtataContext.Configure()
                .UseDriver(this._driverAlias)
                    .UseBaseUrl("https://swedbankpay-sdk-001-dev.azurewebsites.net/")
            .Build();
            AtataContext.Current.Driver.Maximize();
            #endif
        }

        protected TestBase(string driverAlias) => this._driverAlias = driverAlias;

        [TearDown]
        public void TearDown()
        {
            AtataContext.Current?.CleanUp();
        }

        [OneTimeTearDown]
        public void GlobalDown()
        {
            foreach (Driver driverType in Enum.GetValues(typeof(Driver)))
            {
                WebDriverCleanerService.KillWebDriverProcess(WebDriverCleanerService.DriverNames[driverType]);
            }
        }
    }
}
