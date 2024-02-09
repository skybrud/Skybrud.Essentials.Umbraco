using System;
using System.Diagnostics.CodeAnalysis;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Strings.Extensions;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Skybrud.Essentials.Umbraco;

/// <summary>
/// Static class with various extension methods for <see cref="IPublishedElement"/>.
/// </summary>
public static class PublishedElementExtensions {

    #region Boolean

    /// <summary>
    /// Returns the boolean value of the property with the specified <paramref name="alias"/>, or <see langword="false"/> if a matching property could not be found or it's value converted to a <see cref="bool"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>An instance of <see cref="bool"/>.</returns>
    public static bool GetBoolean(this IPublishedElement element, string alias) {
        return element.Value(alias) switch {
            bool boolean => boolean,
            int number => number == 1,
            string str => StringUtils.ParseBoolean(str),
            _ => false
        };
    }

    /// <summary>
    /// Returns the boolean value of the property with the specified <paramref name="alias"/>, or <see langword="null"/> if a matching property could not be found or it's value converted to a <see cref="bool"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>An instance of <see cref="bool"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static bool? GetBooleanOrNull(this IPublishedElement? element, string alias) {
        return element?.Value(alias) switch {
            bool boolean => boolean,
            int number => number == 1,
            string str => StringUtils.ParseBooleanOrNull(str),
            _ => null
        };
    }

    /// <summary>
    /// Attempts to get a boolean value from the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="result">When this method returns, holds the <see cref="bool"/> value if successful; otherwise, <see langword="false"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetBoolean(this IPublishedElement? element, string alias, out bool result) {

        if (element.TryGetBoolean(alias, out bool? temp)) {
            result = temp.Value;
            return true;
        }

        result = default;
        return false;

    }

    /// <summary>
    /// Attempts to get a boolean value from the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="result">When this method returns, holds the <see cref="bool"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetBoolean(this IPublishedElement? element, string alias, [NotNullWhen(true)] out bool? result) {

        if (element is not null && element.HasProperty(alias)) {
            result = element.GetBooleanOrNull(alias);
            return result is not null;
        }

        result = null;
        return false;

    }

    #endregion

    #region Int32

    /// <summary>
    /// Returns the 32-bit signed integer value of the property with the specified <paramref name="alias"/>, or <c>0</c> if a matching property could not be found or it's value converted to a <see cref="int"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>An instance of <see cref="int"/>.</returns>
    public static int GetInt32(this IPublishedElement element, string alias) {
        return GetInt32OrNull(element, alias) ?? default;
    }

    /// <summary>
    /// Returns the 32-bit signed integer value of the property with the specified <paramref name="alias"/>, or <see langword="null"/> if a matching property could not be found or it's value converted to a <see cref="int"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>An instance of <see cref="int"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static int? GetInt32OrNull(this IPublishedElement? element, string alias) {
        return element?.Value(alias) switch {
            bool boolean => boolean ? 1 : 0,
            int number => number,
            string str => StringUtils.ParseInt32OrNull(str),
            _ => null
        };
    }

    /// <summary>
    /// Attempts to get a 32-bit signed integer value from the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="result">When this method returns, holds the <see cref="int"/> value if successful; otherwise, <see langword="false"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt32(this IPublishedElement? element, string alias, out int result) {

        if (element.TryGetInt32(alias, out int? temp)) {
            result = temp.Value;
            return true;
        }

        result = default;
        return false;

    }

    /// <summary>
    /// Attempts to get a 32-bit signed integer value from the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="result">When this method returns, holds the <see cref="int"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt32(this IPublishedElement? element, string alias, [NotNullWhen(true)] out int? result) {

        if (element is not null && element.HasProperty(alias)) {
            result = element.GetInt32OrNull(alias);
            return result is not null;
        }

        result = null;
        return false;

    }

    #endregion

    #region Int64

    /// <summary>
    /// Returns the 64-bit signed integer value of the property with the specified <paramref name="alias"/>, or <c>0</c> if a matching property could not be found or it's value converted to a <see cref="long"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>An instance of <see cref="long"/>.</returns>
    public static long GetInt64(this IPublishedElement element, string alias) {
        return GetInt64OrNull(element, alias) ?? default;
    }

    /// <summary>
    /// Returns the 64-bit signed integer value of the property with the specified <paramref name="alias"/>, or <see langword="null"/> if a matching property could not be found or it's value converted to a <see cref="long"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>An instance of <see cref="long"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static long? GetInt64OrNull(this IPublishedElement? element, string alias) {
        return element?.Value(alias) switch {
            bool boolean => boolean ? 1 : 0,
            long number => number,
            string str => StringUtils.ParseInt64OrNull(str),
            _ => null
        };
    }

    /// <summary>
    /// Attempts to get a 64-bit signed integer value from the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="result">When this method returns, holds the <see cref="long"/> value if successful; otherwise, <see langword="false"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt64(this IPublishedElement? element, string alias, out long result) {

        if (element.TryGetInt64(alias, out long? temp)) {
            result = temp.Value;
            return true;
        }

        result = default;
        return false;

    }

    /// <summary>
    /// Attempts to get a 64-bit signed integer value from the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="result">When this method returns, holds the <see cref="long"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt64(this IPublishedElement? element, string alias, [NotNullWhen(true)] out long? result) {

        if (element is not null && element.HasProperty(alias)) {
            result = element.GetInt64OrNull(alias);
            return result is not null;
        }

        result = null;
        return false;

    }

    #endregion

    #region Float

    /// <summary>
    /// Returns the single-precision floating point value of the property with the specified <paramref name="alias"/>, or <c>0</c> if a matching property could not be found or it's value converted to a <see cref="float"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>An instance of <see cref="float"/>.</returns>
    public static float GetFloat(this IPublishedElement element, string alias) {
        return GetFloatOrNull(element, alias) ?? default;
    }

    /// <summary>
    /// Returns the single-precision floating point value of the property with the specified <paramref name="alias"/>, or <see langword="null"/> if a matching property could not be found or it's value converted to a <see cref="float"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>An instance of <see cref="float"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static float? GetFloatOrNull(this IPublishedElement? element, string alias) {
        return element?.Value(alias) switch {
            int number => number,
            float floating => floating,
            string str => StringUtils.ParseFloatOrNull(str),
            _ => null
        };
    }

    /// <summary>
    /// Attempts to get a single-precision floating point value from the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="result">When this method returns, holds the <see cref="float"/> value if successful; otherwise, <see langword="false"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetFloat(this IPublishedElement? element, string alias, out float result) {

        if (element.TryGetFloat(alias, out float? temp)) {
            result = temp.Value;
            return true;
        }

        result = default;
        return false;

    }

    /// <summary>
    /// Attempts to get a single-precision floating point value from the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="result">When this method returns, holds the <see cref="float"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetFloat(this IPublishedElement? element, string alias, [NotNullWhen(true)] out float? result) {

        if (element is not null && element.HasProperty(alias)) {
            result = element.GetFloatOrNull(alias);
            return result is not null;
        }

        result = null;
        return false;

    }

    #endregion

    #region Double

    /// <summary>
    /// Returns the double-precision doubleing point value of the property with the specified <paramref name="alias"/>, or <c>0</c> if a matching property could not be found or it's value converted to a <see cref="double"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>An instance of <see cref="double"/>.</returns>
    public static double GetDouble(this IPublishedElement element, string alias) {
        return GetDoubleOrNull(element, alias) ?? default;
    }

    /// <summary>
    /// Returns the double-precision doubleing point value of the property with the specified <paramref name="alias"/>, or <see langword="null"/> if a matching property could not be found or it's value converted to a <see cref="double"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>An instance of <see cref="double"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static double? GetDoubleOrNull(this IPublishedElement? element, string alias) {
        return element?.Value(alias) switch {
            long number => number,
            double floating => floating,
            string str => StringUtils.ParseDoubleOrNull(str),
            _ => null
        };
    }

    /// <summary>
    /// Attempts to get a double-precision doubleing point value from the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="result">When this method returns, holds the <see cref="double"/> value if successful; otherwise, <see langword="false"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetDouble(this IPublishedElement? element, string alias, out double result) {

        if (element.TryGetDouble(alias, out double? temp)) {
            result = temp.Value;
            return true;
        }

        result = default;
        return false;

    }

    /// <summary>
    /// Attempts to get a double-precision doubleing point value from the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="result">When this method returns, holds the <see cref="double"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetDouble(this IPublishedElement? element, string alias, [NotNullWhen(true)] out double? result) {

        if (element is not null && element.HasProperty(alias)) {
            result = element.GetDoubleOrNull(alias);
            return result is not null;
        }

        result = null;
        return false;

    }

    #endregion

    #region Guid

    /// <summary>
    /// Returns the GUID value of the property with the specified <paramref name="alias"/>, or <see cref="Guid.Empty"/> if a matching property could not be found or it's value converted to a <see cref="Guid"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>An instance of <see cref="Guid"/>.</returns>
    public static Guid GetGuid(this IPublishedElement element, string alias) {
        return element.Value(alias) switch {
            Guid guid => guid,
            string str => Guid.TryParse(str, out Guid g) ? g : Guid.Empty,
            _ => Guid.Empty
        };
    }

    /// <summary>
    /// Returns the GUID value of the property with the specified <paramref name="alias"/>, or <see langword="null"/> if a matching property could not be found or it's value converted to a <see cref="Guid"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>An instance of <see cref="Guid"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static Guid? GetGuidOrNull(this IPublishedElement? element, string alias) {
        return element?.Value(alias) switch {
            Guid guid => guid,
            string str => (Guid.TryParse(str, out Guid g) ? g : null),
            _ => null
        };
    }

    /// <summary>
    /// Attempts to get a GUID value from the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="result">When this method returns, holds <see cref="Guid"/> value if successful; otherwise, <see cref="Guid.Empty"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetGuid(this IPublishedElement? element, string alias, out Guid result) {
        if (element.TryGetGuid(alias, out Guid? guid)) {
            result = guid.Value;
            return true;
        }
        result = Guid.Empty;
        return false;
    }

    /// <summary>
    /// Attempts to get a GUID value from the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="result">When this method returns, holds <see cref="Guid"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetGuid(this IPublishedElement? element, string alias, [NotNullWhen(true)] out Guid? result) {

        if (element is not null && element.HasProperty(alias)) {
            result = element.GetGuidOrNull(alias);
            return result is not null;
        }

        result = null;
        return false;

    }

    #endregion

    #region String

    /// <summary>
    /// Returns the string value of the property with the specified <paramref name="alias"/>, or <see langword="null"/> if a matching property could not be found or it's value converted to a <see cref="string"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>An instance of <see cref="string"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static string? GetString(this IPublishedElement? element, string alias) {
        return element?.Value<string>(alias);
    }

    /// <summary>
    /// Returns the string value of the property with the specified <paramref name="alias"/>, or <paramref name="fallback"/> if a matching property could not be found or it's value converted to a <see cref="string"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>An instance of <see cref="string"/> if successful; otherwise, <paramref name="fallback"/>.</returns>
    [return: NotNullIfNotNull(nameof(fallback))]
    public static string? GetString(this IPublishedElement? element, string alias, string? fallback) {
        string? value = element?.Value<string>(alias);
        return string.IsNullOrWhiteSpace(value) ? fallback : value;
    }

    /// <summary>
    /// Attempts to get a string value from the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="result">When this method returns, holds the string value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetString(this IPublishedElement? element, string alias, [NotNullWhen(true)] out string? result) {

        if (element is not null && element.HasProperty(alias)) {
            result = element.GetString(alias).NullIfWhiteSpace();
            return result is not null;
        }

        result = null;
        return false;

    }

    #endregion

    #region DateTime

    /// <summary>
    /// Returns a <see cref="DateTime"/> value of the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>An instance of <see cref="DateTime"/>.</returns>
    public static DateTime GetDateTime(this IPublishedElement? element, string alias) {

        // Get the property value
        DateTime? dt = element?.Value<DateTime>(alias);

        // Correct for wrong time zone as Umbraco returns the DateTime as "Utc" even though it is actually "Local"
        return dt is null ? DateTime.MinValue : new DateTime(dt.Value.Ticks, DateTimeKind.Local);

    }

    /// <summary>
    /// Returns a <see cref="DateTime"/> value of the property with the specified <paramref name="alias"/>, or
    /// <see langword="null"/> if the type of the property value doesn't match a <see cref="DateTime"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>An instance of <see cref="DateTime"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static DateTime? GetDateTimeOrNull(this IPublishedElement? element, string alias) {

        // Get the property value
        DateTime? dt = element?.Value<DateTime>(alias);

        // Correct for wrong time zone as Umbraco returns the DateTime as "Utc" even though it is actually "Local"
        return dt is null ? null : new DateTime(dt.Value.Ticks, DateTimeKind.Local);

    }

    /// <summary>
    /// Attempts to get the <see cref="DateTime"/> value of the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="value">When this method returns, holds the <see cref="DateTime"/> value if successful; otherwise <see cref="DateTime.MinValue"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetDateTime(this IPublishedElement? element, string alias, out DateTime value) {

        if (element is not null && element.HasValue(alias) && element.Value(alias) is DateTime dt) {

            // Correct for wrong time zone as Umbraco returns the DateTime as "Utc" even though it is actually "Local"
            value = new DateTime(dt.Ticks, DateTimeKind.Local);

            return true;

        }

        value = default;
        return false;

    }

    /// <summary>
    /// Attempts to get the <see cref="DateTime"/> value of the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="value">When this method returns, holds the <see cref="DateTime"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetDateTime(this IPublishedElement? element, string alias, out DateTime? value) {

        if (element is not null && element.HasValue(alias) && element.Value(alias) is DateTime dt) {

            // Correct for wrong time zone as Umbraco returns the DateTime as "Utc" even though it is actually "Local"
            value = new DateTime(dt.Ticks, DateTimeKind.Local);

            return true;

        }

        value = null;
        return false;

    }

    #endregion

    /// <summary>
    /// Attempts to get the value of type <typeparamref name="T"/> from the property with the specified <paramref name="propertyAlias"/>.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="element">The <see cref="IPublishedElement"/> holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <param name="result">When this method returns, holds the <typeparamref name="T"/> value of the property if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetValue<T>(this IPublishedElement? element, string propertyAlias, out T? result) {

        result = default;

        if (element == null) return false;
        if (!element.HasValue(propertyAlias)) return false;

        result = element.Value<T>(propertyAlias);
        return result != null;

    }

}