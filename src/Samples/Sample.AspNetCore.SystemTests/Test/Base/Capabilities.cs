using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

namespace Sample.AspNetCore.SystemTests.Test.Base
{
    public class Capabilities : ICapabilities
    {
        public Capabilities(string execution = Executions.Single, string environment = Environments.WindowsChrome1)
        {
            CapabilitiesDictionary = new Dictionary<string, object>
            {
                { CapabilityType.BrowserName, "" },
                { CapabilityType.Version, "" },
                { CapabilityType.Platform, "" }
            };

            var environmentCollection = ConfigurationManager.GetSection("environments/" + environment) as NameValueCollection;

            foreach (var key in environmentCollection.AllKeys)
            {
                CapabilitiesDictionary.Add(key, environmentCollection[key]);
            }
        }


        public Dictionary<string, object> CapabilitiesDictionary { get; }

        public object this[string capabilityName] => CapabilitiesDictionary[capabilityName];


        public object GetCapability(string capability)
        {
            return CapabilitiesDictionary[capability];
        }


        public bool HasCapability(string capability)
        {
            return CapabilitiesDictionary.ContainsKey(capability);
        }


        public void AddCapability(string capabilityName, object capabilityValue)
        {
            CapabilitiesDictionary.Add(capabilityName, capabilityValue);
        }
    }
}