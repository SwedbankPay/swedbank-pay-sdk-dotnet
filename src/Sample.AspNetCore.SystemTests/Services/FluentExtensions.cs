using System;
using System.Globalization;
using Atata;

namespace Sample.AspNetCore.SystemTests.Services
{
    public static class FluentExtensions
    {
        public static TOwner RepeatFor<TOwner>(this TOwner page, Action<TOwner, string> action, string[] values)
            where TOwner : PageObject<TOwner>
        {
            foreach (var value in values)
                action.Invoke(page, value);

            return page;
        }

        public static TOwner WaitUntilExists<TOwner>(this Control<TOwner> component)
            where TOwner : PageObject<TOwner>
        {
            if(component.Exists(new SearchOptions { Timeout = new TimeSpan(0, 0, 5), IsSafely = true })) 
            {

            }

            return component.Owner;
        }


        public static TOwner StorePrice<TOwner>(this UIComponent<TOwner> component, out double value)
            where TOwner : PageObject<TOwner>
        {
            value = double.Parse(component.Content.Value.ToString(), CultureInfo.InvariantCulture) * 100;
            return component.Owner;
        }


        public static TOwner StoreValue<TOwner>(this UIComponent<TOwner> component, out Uri value)
            where TOwner : PageObject<TOwner>
        {
            var val = component.Content.Value;
            value = new Uri(val, UriKind.RelativeOrAbsolute);
            return component.Owner;
        }
    }
}