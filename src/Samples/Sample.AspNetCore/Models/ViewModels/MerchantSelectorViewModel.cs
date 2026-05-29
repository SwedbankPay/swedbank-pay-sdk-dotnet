using System.Collections.Generic;

namespace Sample.AspNetCore.Models.ViewModels;

public class MerchantSelectorViewModel
{
    public string? SelectedMerchant { get; set; }
    public IEnumerable<MerchantConfig> Merchants { get; set; } = [];
}