using System;
using System.Globalization;

namespace SwedbankPay.Sdk
{
    public class Language
    {
        /// <summary>
        /// Creates a new <seealso cref="Language"/>.
        /// </summary>
        /// <param name="language">A string in the format of xx-YY</param>
        public Language(string language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(nameof(language));
            }

            Culture = new CultureInfo(language);
            if (Culture.IsNeutralCulture)
            {
                throw new ArgumentException($"Must be given in a xx-YY format.", nameof(language));
            }
        }

        private CultureInfo Culture { get; }

        public override string ToString()
        {
            return Culture.Name;
        }
    }
}
