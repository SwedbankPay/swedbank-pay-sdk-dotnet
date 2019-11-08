using Atata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Base
{
    [ControlDefinition("div[contains(concat(' ', normalize-space(@class), ' '), ' px-input-group ')]//div[contains(concat(' ', normalize-space(@class), ' '), ' icon ')]")]
    public class ValidationIcon<TOwner> : Text<TOwner>
        where TOwner : PageObject<TOwner>
    {
    }
}
