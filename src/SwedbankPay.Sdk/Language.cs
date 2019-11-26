namespace SwedbankPay.Sdk
{
    using System;
    using System.Globalization;
    using System.Linq;

    using Newtonsoft.Json;
    
    public class Language
    {
            private string Value { get; }

            [JsonConstructor]
            public Language(string languageCode)
            {
                if (string.IsNullOrEmpty(languageCode))
                {
                    throw new ArgumentNullException(nameof(languageCode), $"Language code can't be null or empty");
                }
                if (!IsValidLanguage(languageCode))
                {
                    throw new ArgumentException($"Invalid language: {languageCode}", nameof(languageCode));
                }
                this.Value = languageCode;
            }

            public static bool IsValidLanguage(string languageCode)
            {
                if (string.IsNullOrWhiteSpace(languageCode))
                {
                    return false;
                }
                
                return CultureInfo.GetCultures(CultureTypes.AllCultures).Any(c => c.Name.Equals(languageCode));
            }

            public override string ToString()
            {
                return this.Value;
            }
        }
    
}