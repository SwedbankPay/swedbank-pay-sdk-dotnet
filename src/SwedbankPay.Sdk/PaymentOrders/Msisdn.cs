using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class MsIsdn
    {
        public string Value { get; private set; }


        [JsonConstructor]
        public MsIsdn(string msisdn)
        {
            if (!IsValidMsIsdn(msisdn))
            {
                throw new ArgumentException($"Invalid msisdn: {msisdn}", nameof(msisdn));
            }
            Value = msisdn;
        }

        public static bool IsValidMsIsdn(string msisdn)
        {
            if (string.IsNullOrWhiteSpace(msisdn))
                return false;
            return true;
            //try
            //{
            //    // Normalize the domain
            //    emailAddress = Regex.Replace(emailAddress, @"(@)(.+)$", DomainMapper,
            //        RegexOptions.None, TimeSpan.FromMilliseconds(200));

            //    // Examines the domain part of the email and normalizes it.
            //    string DomainMapper(Match match)
            //    {
            //        // Use IdnMapping class to convert Unicode domain names.
            //        var idn = new IdnMapping();

            //        // Pull out and process domain name (throws ArgumentException on invalid)
            //        var domainName = idn.GetAscii(match.Groups[2].Value);

            //        return match.Groups[1].Value + domainName;
            //    }
            //}
            //catch (RegexMatchTimeoutException e)
            //{
            //    return false;
            //}
            //catch (ArgumentException e)
            //{
            //    return false;
            //}

            //try
            //{
            //    return Regex.IsMatch(msisdn, @"/^46[1-9][0-9]{8,12}$/",
            //        RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            //}
            //catch (RegexMatchTimeoutException)
            //{
            //    return false;
            //}
        }
    }
}