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
    
    [JsonIgnore] public ISession Session { get; set; } = null!;

    public override void SetMerchant(string merchantId)
    {
        base.SetMerchant(merchantId);
        Session.SetJson(MerchantSessionKey, this);
    }


    public static Merchant GetMerchant(IServiceProvider services)
    {
        var session = services.GetRequiredService<IHttpContextAccessor>().HttpContext!.Session;
        var swedbankPayConfig = services.GetRequiredService<IOptionsSnapshot<SwedbankPayConnectionSettings>>();

        var sessionMerchant = session.GetJson<SessionMerchant>(MerchantSessionKey) ?? new SessionMerchant();

        sessionMerchant.AvailableMerchants = swedbankPayConfig.Value.Merchants?.ToList();
        sessionMerchant.Session = session;
        sessionMerchant.PayeeId ??= swedbankPayConfig.Value.PayeeId;
        sessionMerchant.Token ??= swedbankPayConfig.Value.Token;
        return sessionMerchant;
    }
}