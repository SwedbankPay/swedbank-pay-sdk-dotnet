using System;
using Atata;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

using Sample.AspNetCore.SystemTests.Services;

namespace Sample.AspNetCore.SystemTests.Test.Base;

using static Drivers;

[TestFixture(DriverAliases.Chrome)]
public abstract class TestBase
{
    private readonly string _driverAlias;
    private TestWebApplicationFactory _testWebApplicationFactory;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        AtataContext.GlobalConfiguration.
            UseChrome().
                WithOptions(DriverOptionsFactory.GetDriverOptions(Driver.Chrome) as ChromeOptions).
            LogConsumers.AddNUnitTestContext().
            WithMinLevel(LogLevel.Error).
            UseBaseRetryTimeout(TimeSpan.FromSeconds(20));
    }

    [SetUp]
    public void SetUp()
    {
        TestContext.Out?.WriteLine("Running: " + TestContext.CurrentContext.Test.Name);

        _testWebApplicationFactory = new TestWebApplicationFactory();
        var chromeOptions = DriverOptionsFactory.GetDriverOptions(Driver.Chrome) as ChromeOptions;
        AtataContext.Configure()
                    .UseChrome()
                    .WithOptions(chromeOptions)
                    .UseBaseUrl(_testWebApplicationFactory.RootUri)
                    .Build();
    }

    protected TestBase(string passedDriverAlias)
    {
        _driverAlias = passedDriverAlias;
    }

    [TearDown]
    public void TearDown()
    {
        if (TestContext.CurrentContext?.Result?.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            TestContext.Out?.WriteLine(PageSource());
        }

        AtataContext.Current?.CleanUp();
        _testWebApplicationFactory.Dispose();
    }

    public string PageSource()
    {
        return $"------ Start Page ${this._driverAlias} ------"
            + Environment.NewLine
            + Environment.NewLine
            + AtataContext.Current.Driver.PageSource
            + Environment.NewLine
            + Environment.NewLine
            + "------ End Page content ------";
    }
}