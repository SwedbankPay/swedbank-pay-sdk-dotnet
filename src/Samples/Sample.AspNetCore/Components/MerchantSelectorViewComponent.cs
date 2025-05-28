using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using Sample.AspNetCore.Models;
using Sample.AspNetCore.Models.ViewModels;

namespace Sample.AspNetCore.Components;

public class MerchantSelectorViewComponent : ViewComponent
{
    private readonly Merchant _merchantService;
    private readonly SwedbankPayConnectionSettings _options;

    public MerchantSelectorViewComponent(
        Merchant merchantService,
        IOptionsSnapshot<SwedbankPayConnectionSettings> options)
    {
        _merchantService = merchantService;
        _options = options.Value;
    }
    
    
    public IViewComponentResult Invoke()
    {
        var model = new MerchantSelectorViewModel
        {
            SelectedMerchant = _merchantService.MerchantId,
            Merchants = _options.Merchants
        };
        
        return View(model);
    }
}
