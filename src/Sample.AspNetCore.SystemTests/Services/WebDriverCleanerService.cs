using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static Sample.AspNetCore.SystemTests.Test.Base.Drivers;

namespace Sample.AspNetCore.SystemTests.Services
{
    public static class WebDriverCleanerService
    {
        public static Dictionary<Driver, string> DriverNames =>
            new Dictionary<Driver, string>
            {
                {Driver.Chrome, "chromedriver"},
                {Driver.Firefox, "geckodriver"},
                {Driver.Edge, null},
                {Driver.InternetExplorer, "IEDriverServer"},
                {Driver.Opera, null},
                {Driver.Safari, null},
            };

        public static void KillWebDriverProcess(string driverName)
        {
            try
            {
                if (driverName != null)
                {
                    Process.GetProcesses()
                        .Where(p => p.ProcessName == driverName)
                        .ToList()
                        .ForEach(p => p.Kill());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
