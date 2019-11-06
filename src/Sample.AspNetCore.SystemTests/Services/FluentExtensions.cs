using Atata;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.AspNetCore.SystemTests.Services
{
    public static class FluentExtensions
    {
        public static TOwner StoreValue<TComponent, TOwner>(this TComponent component, out string value)
            where TComponent : UIComponent<TOwner>
            where TOwner : PageObject<TOwner>
        {
            value = component.Content.Value;
            return component.Owner;
        }
    }
}
