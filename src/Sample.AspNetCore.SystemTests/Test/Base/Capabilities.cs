using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.AspNetCore.SystemTests.Test.Base
{
    public class Capabilities : ICapabilities
    {
        public Dictionary<string, object> CapabilitiesDictionary { get; }

        public Capabilities(string execution = Executions.Single, string environment = Environments.WindowsChrome1)
        {
            CapabilitiesDictionary = new Dictionary<string, object>();

            CapabilitiesDictionary.Add(CapabilityType.BrowserName, "");
            CapabilitiesDictionary.Add(CapabilityType.Version, "");
            CapabilitiesDictionary.Add(CapabilityType.Platform, "");

            NameValueCollection executionCollection = ConfigurationManager.GetSection("executions/" + execution) as NameValueCollection;
            NameValueCollection environmentCollection = ConfigurationManager.GetSection("environments/" + environment) as NameValueCollection;

            //foreach (string key in executionCollection.AllKeys)
            //{
            //    CapabilitiesDictionary.Add(key, executionCollection[key]);
            //}

            foreach (string key in environmentCollection.AllKeys)
            {
                CapabilitiesDictionary.Add(key, environmentCollection[key]);
            }
        }

        public object this[string capabilityName] => CapabilitiesDictionary[capabilityName];

        public object GetCapability(string capability)
        {
            return CapabilitiesDictionary[capability];
        }

        public void AddCapability(string capabilityName, object capabilityValue)
        {
            CapabilitiesDictionary.Add(capabilityName, capabilityValue);
        }

        public bool HasCapability(string capability)
        {
            return CapabilitiesDictionary.ContainsKey(capability);
        }
    }
}
