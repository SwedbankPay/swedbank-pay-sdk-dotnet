using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Atata;
using NUnit.Framework;

namespace Sample.AspNetCore.SystemTests.Services;

public static class FluentExtensions
{
    private static Regex regex = new Regex(@"[0-9\.]+");

    public static TOwner RepeatFor<TOwner>(this TOwner page, Action<TOwner, string> action, string[] values)
        where TOwner : PageObject<TOwner>
    {
        foreach (var value in values)
        {
            action.Invoke(page, value);
        }

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
        var extractedDecimalNumber = regex.Match(component.Content.Value).Value;

        value = double.Parse(extractedDecimalNumber, CultureInfo.InvariantCulture) * 100;
        return component.Owner;
    }

    public static string GetPaymentOrderFromBody<TOwner>(this ValueProvider<string, TOwner> data)
        where TOwner : PageObject<TOwner>
    {
        var tmp = data.Value;
        var orderId = Regex.Match(tmp, "\\/psp\\/(.*?)(?=[\"&])").Value;

        TestContext.Out?.WriteLine(orderId);

        return orderId;
    }

    public static TOwner StoreValueAsUri<TOwner>(this UIComponent<TOwner> component, out Uri value)
        where TOwner : PageObject<TOwner>
    {
        var val = component.Content.Value;
        value = new Uri(val, UriKind.RelativeOrAbsolute);
        return component.Owner;
    }

    public static TOwner StoreValue<TOwner>(this UIComponent<TOwner> component, out string value)
        where TOwner : PageObject<TOwner>
    {
        var val = component.Content.Value;
        value = val;
        return component.Owner;
    }

    public static TOwner SetWithSpeed<T, TOwner>(this EditableField<T, TOwner> editableField, T value, double interval) 
        where TOwner : PageObject<TOwner>
    {
        editableField.Focus();
        
        foreach (var character in value.ToString())
        {
            editableField.Owner
                .Press(character.ToString())
                .WaitSeconds(interval);
        }

        return editableField.Owner;
    }
}