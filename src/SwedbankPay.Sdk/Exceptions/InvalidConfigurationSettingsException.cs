using System;

namespace SwedbankPay.Sdk.Exceptions
{
    public class InvalidConfigurationSettingsException : Exception
    {
        public InvalidConfigurationSettingsException(string message)
            : base(message)
        {
        }
    }
}