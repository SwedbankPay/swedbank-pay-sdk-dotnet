using System;
using System.Globalization;

namespace SwedbankPay.Sdk
{
    public class Language
    {
        public Language(string language)
        {
            if (language == null)
                throw new ArgumentNullException(nameof(language));
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
