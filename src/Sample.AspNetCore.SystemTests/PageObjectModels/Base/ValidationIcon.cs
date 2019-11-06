using Atata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Base
{
    [ControlDefinition("div[contains(concat(' ', normalize-space(@class), ' '), ' c-text__input-wrapper ')]//div[contains(concat(' ', normalize-space(@class), ' '), ' c-text__icon--error ')]")]
    public class ValidationIcon<TOwner> : Text<TOwner>
        where TOwner : PageObject<TOwner>
    {
    }
}
