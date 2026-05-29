using System.Collections.Generic;
using System.Linq;

namespace Sample.AspNetCore.Models;

public class Merchant
{
    public List<MerchantConfig>? AvailableMerchants { get; set; }
    
    public string? PayeeId { get; set; }
    public string? Token { get; set; }
    
    public string? _merchantId;
    public string? MerchantId
    {
        get
        {
            if (string.IsNullOrWhiteSpace(_merchantId))
            {
                _merchantId = AvailableMerchants != null && AvailableMerchants.Any() 
                    ? AvailableMerchants?.FirstOrDefault()?.PayeeId 
                    : null;
            }
    
            return _merchantId;
        }
        set => _merchantId = value;
    } 
    
    public virtual void SetMerchant(string merchantId)
    {
        var merchantConfig = AvailableMerchants?.FirstOrDefault(x => x.PayeeId == merchantId);

        PayeeId = merchantConfig?.PayeeId;
        MerchantId = merchantConfig?.PayeeId;
        Token = merchantConfig?.Token;
    }
}