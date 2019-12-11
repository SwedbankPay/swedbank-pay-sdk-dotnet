using Atata;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Base
{
    [ControlDefinition(
        "div[contains(concat(' ', normalize-space(@class), ' '), ' px-input-group ')]//div[contains(concat(' ', normalize-space(@class), ' '), ' icon ')]")]
    public class ValidationIcon<TOwner> : Text<TOwner>
        where TOwner : PageObject<TOwner>
    {
    }
}