using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

using Sample.AspNetCore.SystemTests.Test.Base;

namespace Sample.AspNetCore.SystemTests.Services
{
    using static Drivers;

    public static class DriverOptionsFactory
    {
        public static DriverOptions GetDriverOptions(Driver driver)
        {
            switch (driver)
            {
                case Driver.Chrome:

                    var chromeOptions = new ChromeOptions { AcceptInsecureCertificates = true };
                    chromeOptions.AddArguments("--incognito", "--disable-infobars", "--disable-notifications", "disable-extensions");

                    /* Not working yet */
                    //ChromePerformanceLoggingPreferences perfLogPrefs = new ChromePerformanceLoggingPreferences();
                    //perfLogPrefs.AddTracingCategories(new string[] { "devtools.network", "devtools.timeline" });
                    //chromeOptions.PerformanceLoggingPreferences = perfLogPrefs;
                    //chromeOptions.AddAdditionalCapability("goog:loggingPrefs", true, true);
                    //chromeOptions.SetLoggingPreference("performance", LogLevel.All);

                    return chromeOptions;

                case Driver.Firefox:

                    var firefoxOptions = new FirefoxOptions { AcceptInsecureCertificates = true };
                    firefoxOptions.AddArgument("-private");
                    firefoxOptions.SetPreference("dom.webnotifications.enabled", false);
                    firefoxOptions.SetPreference("dom.webnotifications.enabled", false);
                    //firefoxOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);
                    //firefoxOptions.LogLevel = FirefoxDriverLogLevel.Trace;

                    return firefoxOptions;

                case Driver.InternetExplorer:

                    return new InternetExplorerOptions
                    {
                        AcceptInsecureCertificates = true,
                        BrowserCommandLineArguments = "",
                        EnsureCleanSession = true,
                        RequireWindowFocus = false
                    };

                default:

                    throw new NotFoundException("This driver is not in the list of handled web drivers");
            }
        }
    }
}