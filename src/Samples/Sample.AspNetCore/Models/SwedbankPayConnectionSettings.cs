using System;
using System.Collections.Generic;

using SwedbankPay.Sdk;

namespace Sample.AspNetCore.Models;

public class SwedbankPayConnectionSettings
{
    public Uri ApiBaseUrl { get; set; }
    public string Token { get; set; }
    public string PayeeId { get; set; }
    
    public IEnumerable<MerchantConfig> Merchants { get; set; }
}