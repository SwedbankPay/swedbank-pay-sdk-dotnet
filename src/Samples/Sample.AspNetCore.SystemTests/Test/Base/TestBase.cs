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

    [TestFixture(DriverAliases.Chrome)]
    [Parallelizable(ParallelScope.All)]
    public abstract class TestBase
    {
        private readonly string _driverAlias;


        [OneTimeSetUp]
        public void OneTimeSetUp()
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
                UseElementFindTimeout(TimeSpan.FromSeconds(15)).
                UseWaitingTimeout(TimeSpan.FromSeconds(15));
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
        }

        protected TestBase(string driverAlias) => this._driverAlias = driverAlias;

        [TearDown]
        public void TearDown()
        {
            //if (TestContext.CurrentContext?.Result?.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            //{
            //    TestContext.Out?.WriteLine(PageSource());
            //}

            AtataContext.Current?.CleanUp();
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