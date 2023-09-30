using System.Globalization;

namespace SwedbankPay.Sdk;

/// <summary>
/// Wraps the amount passed to and from API requests to make
/// dealing with the amount in code more frictionless.
/// </summary>
public class Amount : IEquatable<Amount>, IComparable<Amount>, IComparable
{
    private readonly decimal _amount;
    private readonly long _inLowestMonetaryUnit;

    /// <summary>
    /// Creates a new <seealso cref="Amount"/> using the passed in value.
    /// </summary>
    /// <param name="decimalAmount">A <seealso cref="decimal"/> representing the value.</param>
    public Amount(decimal decimalAmount)
    {
        _amount = decimalAmount;
        _inLowestMonetaryUnit = RoundAndGetMonetaryUnit();
    }

    /// <summary>
    /// Creates a new <seealso cref="Amount"/> using the passed in value.
    /// </summary>
    /// <param name="intAmount">A <seealso cref="long"/> representing the value.</param>
    public Amount(int intAmount)
    {
        var convertedAmount = Convert.ToDecimal(intAmount);
        _amount = convertedAmount;
        _inLowestMonetaryUnit = RoundAndGetMonetaryUnit();
    }

    /// <summary>
    /// Creates a new <seealso cref="Amount"/> using the passed in value.
    /// This does not do any rounding.
    /// </summary>
    /// <param name="longAmount">A <seealso cref="long"/> representing the value.</param>
    public Amount(long longAmount)
    {
        var am = Convert.ToDecimal(longAmount);
        _amount = am / 100;
        _inLowestMonetaryUnit = longAmount;
    }

    /// <summary>
    /// Gets the amount in a format suitable for api requests.
    /// </summary>
    public long InLowestMonetaryUnit => _inLowestMonetaryUnit;

    /// <summary>
    /// Returns the original amount passed in the constructor.
    /// </summary>
    /// <param name="amount">The <seealso cref="Amount"/> you want converted.</param>
    public static implicit operator decimal(Amount amount)
    {
        return amount._amount;
    }

    /// <summary>
    /// Converts a <seealso cref="decimal"/> to a <seealso cref="Amount"/>
    /// </summary>
    /// <param name="amount">The <seealso cref="decimal"/> you want converted.</param>
    public static implicit operator Amount(decimal amount)
    {
        return new Amount(amount);
    }

    /// <summary>
    /// Converts a <seealso cref="long"/> to a <seealso cref="Amount"/>
    /// </summary>
    /// <param name="amount">The <seealso cref="long"/> you want converted.</param>
    public static implicit operator Amount(long amount)
    {
        return new Amount(amount);
    }

    /// <summary>
    /// Converts a <seealso cref="int"/> to a <seealso cref="Amount"/>.
    /// </summary>
    /// <param name="amount">The <seealso cref="int"/> you want to convert.</param>
    public static implicit operator Amount(int amount)
    {
        return FromLowestMonetaryUnit(amount);
    }

    /// <summary>
    /// Adds the amounts in two <seealso cref="Amount"/> instances together.
    /// </summary>
    /// <returns>A new <seealso cref="Amount"/> with the amounts added together.</returns>
    public static Amount operator +(Amount a, Amount b)
    {
        return new Amount(a._amount + b._amount);
    }

    /// <summary>
    /// Subtracts two amounts in <seealso cref="Amount"/> from eachother.
    /// </summary>
    /// <param name="a">The left side parameter of the - operator.</param>
    /// <param name="b">The right side parameter of the - operator.</param>
    /// <returns>A new <seealso cref="Amount"/> with the new sum.</returns>
    public static Amount operator -(Amount a, Amount b)
    {
        return new Amount(a._amount - b._amount);
    }

    /// <summary>
    /// Converts a <seealso cref="int"/> to a <seealso cref="Amount"/>.
    /// </summary>
    /// <param name="amountInLowestMonetaryUnit">The amount.</param>
    /// <returns>A new <seealso cref="Amount"/> based on the <paramref name="amountInLowestMonetaryUnit"/>.</returns>
    public static Amount FromLowestMonetaryUnit(int amountInLowestMonetaryUnit)
    {
        var convertedAmount = (decimal)amountInLowestMonetaryUnit / 100;
        return new Amount(convertedAmount);
    }

    /// <summary>
    /// Converts a <seealso cref="long"/> to a <seealso cref="Amount"/>.
    /// </summary>
    /// <param name="amountInLowestMonetaryUnit">The amount.</param>
    /// <returns>A new <seealso cref="Amount"/> based on the <paramref name="amountInLowestMonetaryUnit"/>.</returns>
    public static Amount FromLowestMonetaryUnit(long amountInLowestMonetaryUnit)
    {
        var convertedAmount = (decimal)amountInLowestMonetaryUnit / 100;
        return new Amount(convertedAmount);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns><inheritdoc/></returns>
    public int CompareTo(object? obj)
    {
        if (obj is null)
        {
            return 1;
        }

        if (ReferenceEquals(this, obj))
        {
            return 0;
        }

        if (!(obj is Amount))
        {
            throw new ArgumentException($"Object must be of type {nameof(Amount)}");
        }

        return CompareTo((Amount)obj);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns><inheritdoc/></returns>
    public int CompareTo(Amount? other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }

        if (other is null)
        {
            return 1;
        }

        return _amount.CompareTo(other._amount);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns><inheritdoc/></returns>
    public bool Equals(Amount? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return _amount == other._amount;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns><inheritdoc/></returns>
    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        return obj.GetType() == GetType() && Equals((Amount)obj);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns><inheritdoc/></returns>
    public override int GetHashCode()
    {
        return _amount.GetHashCode();
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns><inheritdoc/></returns>
    public override string ToString()
    {
        return ToString("N2");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="format"></param>
    /// <returns></returns>
    public string ToString(string format)
    {
        return _amount.ToString(format, CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Checks that two <seealso cref="Amount"/> are equal.
    /// </summary>
    /// <returns>true if equal, false otherwise.</returns>
    public static bool operator ==(Amount? left, Amount? right)
    {
        if (left is null)
        {
            return right is null;
        }

        return left.Equals(right);
    }

    /// <summary>
    /// Checks that two <seealso cref="Amount"/> are not equal.
    /// </summary>
    /// <returns>true if not equal, false otherwise.</returns>
    public static bool operator !=(Amount? left, Amount? right)
    {
        if (left is null || right is null)
        {
            return false;
        }

        return left.InLowestMonetaryUnit != right.InLowestMonetaryUnit;
    }

    /// <summary>
    /// Checks if the first <seealso cref="Amount"/> is smaler than the second.
    /// </summary>
    /// <param name="left">The first <seealso cref="Amount"/> to check.</param>
    /// <param name="right">The second <seealso cref="Amount"/> to check.</param>
    /// <returns>true if <paramref name="left"/> is smaller, false otherwise.</returns>
    public static bool operator <(Amount? left, Amount? right)
    {
        return left is null ? right is not null : left.CompareTo(right) < 0;
    }

    /// <summary>
    /// Checks if the <paramref name="left"/> is smaller or equal to <paramref name="right"/>.
    /// </summary>
    /// <param name="left">The first <seealso cref="Amount"/> to check.</param>
    /// <param name="right">The second <seealso cref="Amount"/> to check.</param>
    /// <returns>true if <paramref name="left"/> is smaller or equal to <paramref name="right"/>.</returns>
    public static bool operator <=(Amount? left, Amount? right)
    {
        return left is null || left.CompareTo(right) <= 0;
    }

    /// <summary>
    /// Checks if <paramref name="left"/> is larger than <paramref name="right"/>.
    /// </summary>
    /// <param name="left">The first <paramref name="left"/> to check.</param>
    /// <param name="right">The second <paramref name="right"/> to check.</param>
    /// <returns>true if <paramref name="left"/> is larger than <paramref name="right"/>, false otherwise.</returns>
    public static bool operator >(Amount? left, Amount? right)
    {
        return left is not null && left.CompareTo(right) > 0;
    }

    /// <summary>
    /// Checks if <paramref name="left"/> is larger than, or equal to<paramref name="right"/>.
    /// </summary>
    /// <param name="left">The first <paramref name="left"/> to check.</param>
    /// <param name="right">The second <paramref name="right"/> to check.</param>
    /// <returns>true if <paramref name="left"/> is larger than or equal to <paramref name="right"/>, false othervise.</returns>
    public static bool operator >=(Amount? left, Amount? right)
    {
        return left is null ? right is null : left.CompareTo(right) >= 0;
    }

    private long RoundAndGetMonetaryUnit()
    {
        // Use "Banker's Rounding" by default.
        const MidpointRounding roundingMode = MidpointRounding.ToEven;
        var roundedAmount = Math.Round(this._amount, 2, roundingMode);
        roundedAmount *= 100;
        var longAmount = Convert.ToInt64(roundedAmount);
        return longAmount;
    }
}