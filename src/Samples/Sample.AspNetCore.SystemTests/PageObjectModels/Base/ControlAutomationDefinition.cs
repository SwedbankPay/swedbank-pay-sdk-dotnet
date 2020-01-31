
using Atata;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Base
{
    /// <summary>
    ///     Specifies the definition of the control, like scope XPath, visibility, component type name, etc.
    /// </summary>
    public sealed class ControlAutomationDefinition : UiComponentDefinitionAutomationAttribute
    {
        public ControlAutomationDefinition(string type = DefaultScopeXPath, string automationAttribute = "")
            : base(type, automationAttribute)
        {
        }


        /// <summary>
        ///     Gets or sets the visibility.
        ///     The default value is <see cref="Visibility.Visible" />.
        /// </summary>
        public Visibility Visibility
        {
            get => Properties.Get(nameof(Visibility), Visibility.Visible);
            set => Properties[nameof(Visibility)] = value;
        }
    }
}