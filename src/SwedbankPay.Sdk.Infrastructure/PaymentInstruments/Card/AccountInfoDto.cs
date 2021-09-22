namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class AccountInfoDto
    {
        public AccountInfoDto(AccountInfo accountInfo)
        {
            if (accountInfo == null)
            {
                return;
            }

            AccountAgeIndicator = accountInfo.AccountAgeIndicator?.Value;
            AccountChangeIndicator = accountInfo.AccountChangeIndicator?.Value;
            AccountPwdChangeIndicator = accountInfo.AccountPwdChangeIndicator?.Value;
            AddressMatchIndicator = accountInfo.AddressMatchIndicator;
            ShippingAddressUsageIndicator = accountInfo.ShippingAddressUsageIndicator?.Value;
            ShippingNameIndicator = accountInfo.ShippingNameIndicator?.Value;
            SuspiciousAccountActivity = accountInfo.SuspiciousAccountActivity?.Value;
        }

        public string AccountAgeIndicator { get; set; }

        public string AccountChangeIndicator { get; set; }

        public string AccountPwdChangeIndicator { get; set; }

        public bool AddressMatchIndicator { get; set; }

        public string ShippingAddressUsageIndicator { get; set; }

        public string ShippingNameIndicator { get; set; }

        public string SuspiciousAccountActivity { get; set; }
    }
}