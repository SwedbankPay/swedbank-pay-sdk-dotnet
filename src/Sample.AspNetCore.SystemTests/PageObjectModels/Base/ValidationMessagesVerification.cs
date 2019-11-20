namespace Sample.AspNetCore.SystemTests.PageObjectModels.Base
{
    using Atata;
    using OpenQA.Selenium;
    using System;

    public class ValidationMessageList<TOwner> : ControlList<ValidationMessage<TOwner>, TOwner>
        where TOwner : PageObject<TOwner>
    {
        public ValidationMessage<TOwner> this[Func<TOwner, IControl<TOwner>> controlSelector]
        {
            get { return For(controlSelector); }
        }

        public ValidationMessage<TOwner> For(Func<TOwner, IControl<TOwner>> controlSelector)
        {
            var validationMessageDefinition = UIComponentResolver.GetControlDefinition(typeof(ValidationMessage<TOwner>));

            var boundControl = controlSelector(Component.Owner);

            var scopeLocator = new PlainScopeLocator(By.XPath("ancestor::" + validationMessageDefinition.ScopeXPath))
            {
                SearchContext = boundControl.Scope
            };

            return Component.Controls.Create<ValidationMessage<TOwner>>(boundControl.ComponentName, scopeLocator);
        }
    }
}
