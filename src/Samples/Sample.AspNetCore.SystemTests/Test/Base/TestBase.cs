using System;
using Atata;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

using Sample.AspNetCore.SystemTests.Services;

namespace Sample.AspNetCore.SystemTests.Test.Base
{
    using static Drivers;

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
                WithMinLevel(LogLevel.Trace).
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
                    .UseBaseUrl("https://localhost:44344/")
            .Build();
            AtataContext.Current.Driver.Maximize();
#elif DEV
            AtataContext.Configure()
                .UseDriver(_driverAlias)
                    .UseBaseUrl("https://YourBaseUrl.com/")
            .Build();
            AtataContext.Current.Driver.Maximize();
#elif RELEASE
            var chromeOptions = DriverOptionsFactory.GetDriverOptions(Driver.Chrome) as ChromeOptions;
            // https://stackoverflow.com/a/50791503/10192288
            chromeOptions.AddArgument("--disable-dev-shm-usage");
            AtataContext.Configure()
                .UseChrome()
                .WithOptions(chromeOptions)
                .UseBaseUrl("https://localhost:44344/")
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
                WebDriverCleanerService.KillWebDriverProcess(WebDriverCleanerService.DriverNames[driverType]);
        }
    }
}