using Atata;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Base
{
    [ControlDefinition("div[contains(concat(' ', normalize-space(@class), ' '), ' c-text__input-wrapper ')]//div[contains(concat(' ', normalize-space(@class), ' '), ' c-text__message ')]")]
    public class ValidationMessage<TOwner> : Text<TOwner>
        where TOwner : PageObject<TOwner>
    {
    }
}
