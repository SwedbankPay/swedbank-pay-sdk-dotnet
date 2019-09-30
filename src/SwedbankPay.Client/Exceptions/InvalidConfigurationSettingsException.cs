using System;

namespace SwedbankPay.Client.Exceptions
{
    public class InvalidConfigurationSettingsException : Exception
    {
        public InvalidConfigurationSettingsException(string message) : base(message)
        {

        }
    }
}
