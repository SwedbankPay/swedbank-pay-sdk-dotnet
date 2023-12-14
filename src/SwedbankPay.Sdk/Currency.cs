using System.Globalization;

namespace SwedbankPay.Sdk;

/// <summary>
/// The currency code used for the payment
/// </summary>
public class Currency
{
    /// <summary>
    /// Constructs a new <seealso cref="Currency"/> using a ISO 4217 currency symbol.
    /// </summary>
    /// <param name="currencyCode">A ISO 4217 currency symbol.</param>
    public Currency(string currencyCode)
    {
        if (string.IsNullOrEmpty(currencyCode))
        {
            throw new ArgumentNullException(nameof(currencyCode), "Currency code can't be null or empty");
        }

        if (!IsValidCurrencyCode(currencyCode))
        {
            throw new ArgumentException($"Invalid currency code: {currencyCode}");
        }

        Value = currencyCode;
    }


    private string Value { get; }

    /// <summary>
    /// Checks if the <paramref name="currencyCode"/> is valid.
    /// This checks that it's of neutral culture, and use ISO currency symbols.
    /// </summary>
    /// <param name="currencyCode"></param>
    /// <returns></returns>
    public static bool IsValidCurrencyCode(string currencyCode)
    {
        if (string.IsNullOrWhiteSpace(currencyCode))
        {
            return false;
        }

        var regions = GetCultures()
            .Where(c => !c.IsNeutralCulture)
            .Select(culture =>
            {
                try
                {
                    return new RegionInfo(culture.Name);
                }
                catch
                {
                    return null;
                }
            });

        return regions.Any(ri => ri != null && ri.ISOCurrencySymbol.Equals(currencyCode));
    }

    private static CultureInfo[] GetCultures()
    {
        return CultureInfo.GetCultures(CultureTypes.AllCultures);
    }
    
    /// <summary>
    /// Converts a <seealso cref="string"/> to a <seealso cref="Currency"/>
    /// </summary>
    /// <param name="currency">The <seealso cref="string"/> you want converted.</param>
    public static implicit operator Currency(string currency)
    {
        return new Currency(currency);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns><inheritdoc/></returns>
    public override string ToString()
    {
        return Value;
    }
}