using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atata;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Base
{
    /// <summary>
    /// Specifies that a control should be found by CSS selector with the automation attribute.
    /// Finds the descendant or self control in the scope of the element found by the specified CSS selector.
    /// </summary>
    public class FindByAutomationAttribute : FindAttribute, ITermFindAttribute
    {
        public FindByAutomationAttribute(string type, string automationAttribute)
        {
            Values = new string[] { string.Format("{0}[automation='{1}']", type, automationAttribute) };
        }

        /// <summary>
        /// Gets the CSS selector values.
        /// </summary>
        public string[] Values { get; private set; }

        protected override Type DefaultStrategy
        {
            get { return typeof(FindByCssStrategy); }
        }

        public string[] GetTerms(UIComponentMetadata metadata)
        {
            return Values;
        }
    }
}
