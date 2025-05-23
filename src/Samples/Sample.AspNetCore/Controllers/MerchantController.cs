using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Sample.AspNetCore.Models;

namespace Sample.AspNetCore.Controllers;

public class MerchantController : Controller
{
    private readonly Merchant _merchant;

    public MerchantController(Merchant merchant)
    {
        _merchant = merchant;
    }

    [HttpPost]
    public async Task<IActionResult> SetMerchant(string merchantId)
    {
        _merchant.SetMerchant(merchantId);

        return await Task.FromResult(Redirect(Request.Headers["Referer"].ToString()));
    }
}