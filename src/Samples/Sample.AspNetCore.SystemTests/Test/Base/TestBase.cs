﻿using System;
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
    public abstract class TestBase
    {
        private readonly string driverAlias;
        private TestWebApplicationFactory testWebApplicationFactory;


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
                UseBaseRetryTimeout(TimeSpan.FromSeconds(20));
        }


        [SetUp]
        public void SetUp()
        {
            TestContext.Out?.WriteLine("Running: " + TestContext.CurrentContext.Test.Name);

            this.testWebApplicationFactory = new TestWebApplicationFactory();
            var chromeOptions = DriverOptionsFactory.GetDriverOptions(Driver.Chrome) as ChromeOptions;
            AtataContext.Configure()
                        .UseChrome()
                        .WithOptions(chromeOptions)
                        .UseBaseUrl(this.testWebApplicationFactory.RootUri)
                        .Build();
        }

        protected TestBase(string passedDriverAlias)
        {
            this.driverAlias = passedDriverAlias;
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext?.Result?.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                TestContext.Out?.WriteLine(PageSource());
            }

            AtataContext.Current?.CleanUp();
            this.testWebApplicationFactory.Dispose();
        }

        public string PageSource()
        {
            return $"------ Start Page ${this.driverAlias} ------"
                + Environment.NewLine
                + Environment.NewLine
                + AtataContext.Current.Driver.PageSource
                + Environment.NewLine
                + Environment.NewLine
                + "------ End Page content ------";
        }
    }
}