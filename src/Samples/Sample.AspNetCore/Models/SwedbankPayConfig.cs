using System.Collections.Generic;

namespace Sample.AspNetCore.Models;

public class SwedbankPayConfig
{
    public string? PayeeId { get; set; }
    public IEnumerable<MerchantConfig>? Merchants { get; set; }
}