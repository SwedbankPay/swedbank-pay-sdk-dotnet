namespace Sample.AspNetCore.SystemTests.PageObjectModels.Base
{
    using Atata;
    using OpenQA.Selenium;
    using System;

    public class ValidationIconList<TOwner> : ControlList<ValidationIcon<TOwner>, TOwner>
        where TOwner : PageObject<TOwner>
    {
        public ValidationIcon<TOwner> this[Func<TOwner, IControl<TOwner>> controlSelector]
        {
            get { return For(controlSelector); }
        }

        public ValidationIcon<TOwner> For(Func<TOwner, IControl<TOwner>> controlSelector)
        {
            var validationMessageDefinition = UIComponentResolver.GetControlDefinition(typeof(ValidationIcon<TOwner>));

            var boundControl = controlSelector(Component.Owner);

            var scopeLocator = new PlainScopeLocator(By.XPath("ancestor::" + validationMessageDefinition.ScopeXPath))
            {
                SearchContext = boundControl.Scope
            };

            return Component.Controls.Create<ValidationIcon<TOwner>>(boundControl.ComponentName, scopeLocator);
        }
    }
}
