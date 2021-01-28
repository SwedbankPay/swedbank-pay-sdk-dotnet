using System;

namespace SwedbankPay.Sdk.Tests.TestHelpers
{
    public class SwedbankPayConnectionSettings
    {
        public Uri ApiBaseUrl { get; set; }
        public string Token { get; set; }
        public string TokenMobilePay { get; set; }
        public string PayeeId { get; set; }
    }
}
