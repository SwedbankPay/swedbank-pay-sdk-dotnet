using System;
using System.Collections;
using Atata;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

using Sample.AspNetCore.SystemTests.Services;

namespace Sample.AspNetCore.SystemTests.Test.Base
{
    using static Drivers;

    [TestFixture(DriverAliases.Chrome)]
    [Parallelizable(ParallelScope.Children)]
    public abstract class TestBase
    {
#pragma warning disable IDE0052 // Remove unread private members
        private readonly string _driverAlias;
#pragma warning restore IDE0052 // Remove unread private members


        [OneTimeSetUp]
        public void GlobalSetup()
        {
            AtataContext.GlobalConfiguration.
                UseChrome().
                    WithOptions(DriverOptionsFactory.GetDriverOptions(Driver.Chrome) as ChromeOptions).
                UseFirefox().
                    WithOptions(DriverOptionsFactory.GetDriverOptions(Driver.Firefox) as FirefoxOptions).
                UseInternetExplorer().
                    WithOptions(DriverOptionsFactory.GetDriverOptions(Driver.InternetExplorer) as InternetExplorerOptions).
                AddNUnitTestContextLogging().
                    WithMinLevel(LogLevel.Error).
                UseVerificationTimeout(TimeSpan.FromSeconds(10)).
                UseElementFindTimeout(TimeSpan.FromSeconds(20)).
                UseWaitingTimeout(TimeSpan.FromSeconds(60));
        }


        [SetUp]
        public void SetUp()
        {
            var chromeOptions = DriverOptionsFactory.GetDriverOptions(Driver.Chrome) as ChromeOptions;
            AtataContext.Configure()
                        .UseChrome()
                        .WithOptions(chromeOptions)
                        .UseBaseUrl("https://127.0.0.1:5001")
                        .Build();

            #if DEBUG
            AtataContext.Current.Driver.Maximize();
            #endif
        }

        protected TestBase(string driverAlias) => this._driverAlias = driverAlias;

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext?.Result?.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                TestContext.Out?.WriteLine(PageSource());
            }
            AtataContext.Current?.CleanUp();
        }


        [OneTimeTearDown]
        public void GlobalDown()
        {
            foreach (Driver driverType in Enum.GetValues(typeof(Driver)))
                WebDriverCleanerService.KillWebDriverProcess(WebDriverCleanerService.DriverNames[driverType]);
        }

        public static string PageSource()
        {
            return $"------ Start Page content ------"
                + Environment.NewLine
                + Environment.NewLine
                + AtataContext.Current.Driver.PageSource
                + Environment.NewLine
                + Environment.NewLine
                + "------ End Page content ------";
        }
    }
}