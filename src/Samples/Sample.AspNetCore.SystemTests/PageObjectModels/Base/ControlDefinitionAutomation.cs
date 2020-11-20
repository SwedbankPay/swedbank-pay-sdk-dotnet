using System.Linq;

using Atata;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Base
{
    /// <summary>
    ///     Specifies the definition of the control, like scope XPath, visibility, component type name, etc.
    /// </summary>
    public class ControlAutomationDefinition : UiComponentDefinitionAutomationAttribute
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
                : new string[0];
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

    /// <summary>
    ///     Represents the base attribute class for component scope definition.
    ///     The basic definition is represented with XPath.
    /// </summary>
    public abstract class ScopeDefinitionAutomationAttribute : MulticastAttribute
    {
        /// <summary>
        ///     The default scope XPath, which is <c>"*"</c>.
        /// </summary>
        public const string DefaultScopeXPath = "*";

        private readonly string baseScopeXPath;


        protected ScopeDefinitionAutomationAttribute(string type = DefaultScopeXPath, string automationAttribute = "")
        {
            this.baseScopeXPath = string.Format("{0}[@automation='{1}']", type, automationAttribute);
        }


        /// <summary>
        ///     Gets or sets the containing CSS class name.
        /// </summary>
        public string ContainingClass
        {
            get => ContainingClasses?.FirstOrDefault();
            set => ContainingClasses = value == null ? null : new[] { value };
        }

        /// <summary>
        ///     Gets or sets the containing CSS class names.
        ///     Multiple class names are used in XPath as conditions joined with <c>and</c> operator.
        /// </summary>
        public string[] ContainingClasses { get; set; }

        /// <summary>
        ///     Gets the XPath of the scope element which is a combination of XPath passed through the constructor and
        ///     <see cref="ContainingClasses" /> property values.
        /// </summary>
        public string ScopeXPath => BuildScopeXPath();


        /// <summary>
        ///     Builds the complete XPath of the scope element which is a combination of XPath passed through the constructor and
        ///     <see cref="ContainingClasses" /> property values.
        /// </summary>
        /// <returns>The built XPath.</returns>
        protected virtual string BuildScopeXPath()
        {
            var scopeXPath = this.baseScopeXPath ?? DefaultScopeXPath;

            if (ContainingClasses?.Any() ?? false)
            {
                var classConditions = ContainingClasses.Select(x => $"contains(concat(' ', normalize-space(@class), ' '), ' {x.Trim()} ')");
                return $"{scopeXPath}[{string.Join(" and ", classConditions)}]";
            }

            return scopeXPath;
        }
    }
}