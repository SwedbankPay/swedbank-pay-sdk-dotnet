using System.Collections.Generic;
using System.Linq;

namespace Sample.AspNetCore.Models;

public class Merchant
{
    public List<string> AvailableMerchants { get; set; }
    
    public string? PayeeId { get; set; }
    
    public string? _merchantId;
    public string? MerchantId
    {
        get
        {
            if (string.IsNullOrWhiteSpace(_merchantId))
            {
                _merchantId = AvailableMerchants != null && AvailableMerchants.Any() 
                    ? AvailableMerchants?.FirstOrDefault() 
                    : null;
            }
    
            return _merchantId;
        }
        set => _merchantId = value;
    } 
    
    public virtual void SetMerchant(string? merchantId)
    {
        PayeeId = merchantId;
        MerchantId = merchantId;
    }
}