using System.Linq;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Base
{
    /// <summary>
    ///     Represents the base attribute class for UI component (page object, control) definition.
    /// </summary>
    public abstract class UiComponentDefinitionAutomationAttribute : ScopeDefinitionAutomationAttribute
    {
        protected UiComponentDefinitionAutomationAttribute(string type = DefaultScopeXPath, string automationAttribute = "")
            : base(type, automationAttribute)
        {
        }


        /// <summary>
        ///     Gets or sets the name of the component type.
        ///     It is used in report log messages to describe the component type.
        /// </summary>
        public string ComponentTypeName { get; set; }

        /// <summary>
        ///     Gets or sets the property name endings to ignore/truncate.
        ///     Accepts a string containing a set of values separated by comma, for example <c>"Button,Link"</c>.
        /// </summary>
        public string IgnoreNameEndings { get; set; }


        /// <summary>
        ///     Gets the values of property name endings to ignore.
        /// </summary>
        /// <returns>An array of name endings to ignore.</returns>
        public string[] GetIgnoreNameEndingValues()
        {
            return IgnoreNameEndings != null
                ? IgnoreNameEndings.Split(',').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray()
                : System.Array.Empty<string>();
        }


        /// <summary>
        ///     Normalizes the name considering value of <see cref="IgnoreNameEndings" />.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Normalized name.</returns>
        public string NormalizeNameIgnoringEnding(string name)
        {
            var endingToIgnore = GetIgnoreNameEndingValues().FirstOrDefault(x => name.EndsWith(x) && name.Length > x.Length);

            return endingToIgnore != null
                ? name.Substring(0, name.Length - endingToIgnore.Length).TrimEnd()
                : name;
        }
    }
}