using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using Sample.AspNetCore.Models;
using Sample.AspNetCore.Models.ViewModels;

namespace Sample.AspNetCore.Components;

public class MerchantSelectorViewComponent(
    Merchant merchantService,
    IOptionsSnapshot<SwedbankPayConnectionSettings> options)
    : ViewComponent
{
    private readonly SwedbankPayConnectionSettings _options = options.Value;


    public IViewComponentResult Invoke()
    {
        var model = new MerchantSelectorViewModel
        {
            SelectedMerchant = merchantService.MerchantId,
            Merchants = _options.Merchants ?? []
        };
        
        return View(model);
    }
}
