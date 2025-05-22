using System.Collections.Generic;

using SwedbankPay.Sdk;

namespace Sample.AspNetCore.Models;

public class SwedbankPayConfig
{
    public string PayeeId { get; set; }

    public string PayeeReference { get; set; }
    public IEnumerable<MerchantConfig>? Merchants { get; set; }
}