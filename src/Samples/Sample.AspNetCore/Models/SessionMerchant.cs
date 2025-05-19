using System;
using System.Linq;
using System.Text.Json.Serialization;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using Sample.AspNetCore.Extensions;

namespace Sample.AspNetCore.Models;

public class SessionMerchant : Merchant
{
    private const string MerchantSessionKey = "_Merchant";
    
    [JsonIgnore] public ISession Session { get; set; }
    
    public override void SetMerchant(string merchantId)
    {
        base.SetMerchant(merchantId);
        Session.SetJson(MerchantSessionKey, this);
    }

    
    public static Merchant GetMerchant(IServiceProvider services)
    {
        var session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        var merchants = services.GetRequiredService<IOptionsSnapshot<PayeeInfoConfig>>();

        var merchant = session?.GetJson<SessionMerchant>(MerchantSessionKey) ?? new SessionMerchant();

        merchant.AvailableMerchants = merchants.Value.Merchants.Select(x => x.PayeeId).ToList();
        merchant.Session = session;
        return merchant;
    }

}