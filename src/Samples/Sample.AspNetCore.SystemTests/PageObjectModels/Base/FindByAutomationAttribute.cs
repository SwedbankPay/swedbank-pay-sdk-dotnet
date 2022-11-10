using System;

using Atata;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Base;

/// <summary>
///     Specifies that a control should be found by CSS selector with the automation attribute.
///     Finds the descendant or self control in the scope of the element found by the specified CSS selector.
/// </summary>
public class FindByAutomationAttribute : FindAttribute, ITermFindAttribute
{
    public FindByAutomationAttribute(string type, string automationAttribute)
    {
        Values = new[] { string.Format("{0}[automation='{1}']", type, automationAttribute) };
    }


    protected override Type DefaultStrategy => typeof(FindByCssStrategy);

    /// <summary>
    ///     Gets the CSS selector values.
    /// </summary>
    public string[] Values { get; }


    public string[] GetTerms(UIComponentMetadata metadata)
    {
        return Values;
    }
}