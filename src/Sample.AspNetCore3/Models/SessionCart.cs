using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Sample.AspNetCore3.Extensions;

namespace Sample.AspNetCore3.Models
{
    public class SessionCart : Cart
    {
        
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionCart cart = session?.GetJson<SessionCart>(CartSessionKey) ?? new SessionCart();

            cart.Session = session;
            return cart;
        }

        public const string CartSessionKey = "_Cart";

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session.SetJson(CartSessionKey, this);
        }

        public override void RemoveItem(Product product, int quantity)
        {
            base.RemoveItem(product, quantity);
            Session.SetJson(CartSessionKey, this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove(CartSessionKey);
        }
        public override void Update()
        {
            Session.SetJson(CartSessionKey, this);
        }
    }
}