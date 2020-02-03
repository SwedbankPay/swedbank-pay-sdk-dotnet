using System.Collections.Generic;

namespace Sample.AspNetCore.SystemTests.Test.Base
{
    public class Drivers
    {
        public enum Driver
        {
            Chrome,
            Firefox,
            InternetExplorer,
            Edge,
            Opera,
            Safari
        }

        public static Dictionary<Driver, string> DriverAliasNames =>
            new Dictionary<Driver, string>
            {
                { Driver.Chrome, "chrome" },
                { Driver.Firefox, "firefox" },
                { Driver.Edge, "edge" },
                { Driver.InternetExplorer, "internetexplorer" },
                { Driver.Opera, "opera" },
                { Driver.Safari, "safari" }
            };
    }
}