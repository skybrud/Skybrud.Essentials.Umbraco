using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Strings.Extensions;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Skybrud.Essentials.Umbraco.PublishedContent;

/// <summary>
/// Static class with various extension methods for <see cref="IPublishedElement"/>.
/// </summary>
public static class PublishedElementExtensions {

    #region Boolean

    /// <summary>
    /// Returns the boolean value of the property with the specified <paramref name="propertyAlias"/>, or <see langword="false"/> if a matching property could not be found, or it's value converted to a <see cref="bool"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <returns>An instance of <see cref="bool"/>.</returns>
    public static bool GetBoolean(this IPublishedElement? element, string propertyAlias) {
        return element?.Value(propertyAlias) switch {
            bool boolean => boolean,
            int number => number == 1,
            string str => StringUtils.ParseBoolean(str),
            _ => false
        };
    }

    /// <summary>
    /// Returns the boolean value of the property with the specified <paramref name="propertyAlias"/>, or the specified <paramref name="fallback"/> value if a matching property could not be found, or it's value converted to a <see cref="bool"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>An instance of <see cref="bool"/> if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static bool GetBoolean(this IPublishedElement? element, string propertyAlias, bool fallback) {
        return element?.Value(propertyAlias) switch {
            bool boolean => boolean,
            int number => number switch {
                0 => false,
                1 => true,
                _ => fallback
            },
            string str => StringUtils.ParseBoolean(str, fallback),
            _ => fallback
        };
    }

    /// <summary>
    /// Returns the boolean value of the property with the specified <paramref name="propertyAlias"/>, or <see langword="null"/> if a matching property could not be found, or it's value converted to a <see cref="bool"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <returns>An instance of <see cref="bool"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static bool? GetBooleanOrNull(this IPublishedElement? element, string propertyAlias) {
        return element?.Value(propertyAlias) switch {
            bool boolean => boolean,
            int number => number == 1,
            string str => StringUtils.ParseBooleanOrNull(str),
            _ => null
        };
    }

    /// <summary>
    /// Attempts to get a boolean value from the property with the specified <paramref name="propertyAlias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <param name="value">When this method returns, holds the <see cref="bool"/> value if successful; otherwise, <see langword="false"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetBoolean(this IPublishedElement? element, string propertyAlias, out bool value) {

        if (element.TryGetBoolean(propertyAlias, out bool? temp)) {
            value = temp.Value;
            return true;
        }

        value = false;
        return false;

    }

    /// <summary>
    /// Attempts to get a boolean value from the property with the specified <paramref name="propertyAlias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <param name="value">When this method returns, holds the <see cref="bool"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetBoolean(this IPublishedElement? element, string propertyAlias, [NotNullWhen(true)] out bool? value) {

        if (element is not null && element.HasProperty(propertyAlias)) {
            value = element.GetBooleanOrNull(propertyAlias);
            return value is not null;
        }

        value = null;
        return false;

    }

    #endregion

    #region Int32

    /// <summary>
    /// Returns the 32-bit signed integer value of the property with the specified <paramref name="propertyAlias"/>, or <c>0</c> if a matching property could not be found, or it's value converted to a <see cref="int"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <returns>An instance of <see cref="int"/>.</returns>
    public static int GetInt32(this IPublishedElement element, string propertyAlias) {
        return GetInt32OrNull(element, propertyAlias) ?? 0;
    }

    /// <summary>
    /// Returns the 32-bit signed integer value of the property with the specified <paramref name="propertyAlias"/>, or <see langword="null"/> if a matching property could not be found, or it's value converted to a <see cref="int"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <returns>An instance of <see cref="int"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static int? GetInt32OrNull(this IPublishedElement? element, string propertyAlias) {
        return element?.Value(propertyAlias) switch {
            bool boolean => boolean ? 1 : 0,
            int number => number,
            string str => StringUtils.ParseInt32OrNull(str),
            _ => null
        };
    }

    /// <summary>
    /// Attempts to get a 32-bit signed integer value from the property with the specified <paramref name="propertyAlias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <param name="value">When this method returns, holds the <see cref="int"/> value if successful; otherwise, <see langword="false"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt32(this IPublishedElement? element, string propertyAlias, out int value) {

        if (element.TryGetInt32(propertyAlias, out int? temp)) {
            value = temp.Value;
            return true;
        }

        value = 0;
        return false;

    }

    /// <summary>
    /// Attempts to get a 32-bit signed integer value from the property with the specified <paramref name="propertyAlias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <param name="value">When this method returns, holds the <see cref="int"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt32(this IPublishedElement? element, string propertyAlias, [NotNullWhen(true)] out int? value) {

        if (element is not null && element.HasProperty(propertyAlias)) {
            value = element.GetInt32OrNull(propertyAlias);
            return value is not null;
        }

        value = null;
        return false;

    }

    #endregion

    #region Int64

    /// <summary>
    /// Returns the 64-bit signed integer value of the property with the specified <paramref name="propertyAlias"/>, or <c>0</c> if a matching property could not be found, or it's value converted to a <see cref="long"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <returns>An instance of <see cref="long"/>.</returns>
    public static long GetInt64(this IPublishedElement element, string propertyAlias) {
        return GetInt64OrNull(element, propertyAlias) ?? 0;
    }

    /// <summary>
    /// Returns the 64-bit signed integer value of the property with the specified <paramref name="propertyAlias"/>, or <see langword="null"/> if a matching property could not be found, or it's value converted to a <see cref="long"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <returns>An instance of <see cref="long"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static long? GetInt64OrNull(this IPublishedElement? element, string propertyAlias) {
        return element?.Value(propertyAlias) switch {
            bool boolean => boolean ? 1 : 0,
            long number => number,
            string str => StringUtils.ParseInt64OrNull(str),
            _ => null
        };
    }

    /// <summary>
    /// Attempts to get a 64-bit signed integer value from the property with the specified <paramref name="propertyAlias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <param name="value">When this method returns, holds the <see cref="long"/> value if successful; otherwise, <see langword="false"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt64(this IPublishedElement? element, string propertyAlias, out long value) {

        if (element.TryGetInt64(propertyAlias, out long? temp)) {
            value = temp.Value;
            return true;
        }

        value = 0;
        return false;

    }

    /// <summary>
    /// Attempts to get a 64-bit signed integer value from the property with the specified <paramref name="propertyAlias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <param name="value">When this method returns, holds the <see cref="long"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt64(this IPublishedElement? element, string propertyAlias, [NotNullWhen(true)] out long? value) {

        if (element is not null && element.HasProperty(propertyAlias)) {
            value = element.GetInt64OrNull(propertyAlias);
            return value is not null;
        }

        value = null;
        return false;

    }

    #endregion

    #region Float

    /// <summary>
    /// Returns the single-precision floating point value of the property with the specified <paramref name="propertyAlias"/>, or <c>0</c> if a matching property could not be found, or it's value converted to a <see cref="float"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <returns>An instance of <see cref="float"/>.</returns>
    public static float GetFloat(this IPublishedElement element, string propertyAlias) {
        return GetFloatOrNull(element, propertyAlias) ?? 0;
    }

    /// <summary>
    /// Returns the single-precision floating point value of the property with the specified <paramref name="propertyAlias"/>, or <see langword="null"/> if a matching property could not be found, or it's value converted to a <see cref="float"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <returns>An instance of <see cref="float"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static float? GetFloatOrNull(this IPublishedElement? element, string propertyAlias) {
        return element?.Value(propertyAlias) switch {
            int number => number,
            float floating => floating,
            string str => StringUtils.ParseFloatOrNull(str),
            _ => null
        };
    }

    /// <summary>
    /// Attempts to get a single-precision floating point value from the property with the specified <paramref name="propertyAlias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <param name="value">When this method returns, holds the <see cref="float"/> value if successful; otherwise, <see langword="false"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetFloat(this IPublishedElement? element, string propertyAlias, out float value) {

        if (element.TryGetFloat(propertyAlias, out float? temp)) {
            value = temp.Value;
            return true;
        }

        value = 0;
        return false;

    }

    /// <summary>
    /// Attempts to get a single-precision floating point value from the property with the specified <paramref name="propertyAlias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <param name="value">When this method returns, holds the <see cref="float"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetFloat(this IPublishedElement? element, string propertyAlias, [NotNullWhen(true)] out float? value) {

        if (element is not null && element.HasProperty(propertyAlias)) {
            value = element.GetFloatOrNull(propertyAlias);
            return value is not null;
        }

        value = null;
        return false;

    }

    #endregion

    #region Double

    /// <summary>
    /// Returns the double-precision floating point value of the property with the specified <paramref name="propertyAlias"/>, or <c>0</c> if a matching property could not be found, or it's value converted to a <see cref="double"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <returns>An instance of <see cref="double"/>.</returns>
    public static double GetDouble(this IPublishedElement element, string propertyAlias) {
        return GetDoubleOrNull(element, propertyAlias) ?? 0;
    }

    /// <summary>
    /// Returns the double-precision floating point value of the property with the specified <paramref name="propertyAlias"/>, or <see langword="null"/> if a matching property could not be found, or it's value converted to a <see cref="double"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <returns>An instance of <see cref="double"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static double? GetDoubleOrNull(this IPublishedElement? element, string propertyAlias) {
        return element?.Value(propertyAlias) switch {
            long number => number,
            double floating => floating,
            string str => StringUtils.ParseDoubleOrNull(str),
            _ => null
        };
    }

    /// <summary>
    /// Attempts to get a double-precision floating point value from the property with the specified <paramref name="propertyAlias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <param name="value">When this method returns, holds the <see cref="double"/> value if successful; otherwise, <see langword="false"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetDouble(this IPublishedElement? element, string propertyAlias, out double value) {

        if (element.TryGetDouble(propertyAlias, out double? temp)) {
            value = temp.Value;
            return true;
        }

        value = 0;
        return false;

    }

    /// <summary>
    /// Attempts to get a double-precision floating point value from the property with the specified <paramref name="propertyAlias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <param name="value">When this method returns, holds the <see cref="double"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetDouble(this IPublishedElement? element, string propertyAlias, [NotNullWhen(true)] out double? value) {

        if (element is not null && element.HasProperty(propertyAlias)) {
            value = element.GetDoubleOrNull(propertyAlias);
            return value is not null;
        }

        value = null;
        return false;

    }

    #endregion

    #region Guid

    /// <summary>
    /// Returns the GUID value of the property with the specified <paramref name="propertyAlias"/>, or <see cref="Guid.Empty"/> if a matching property could not be found, or it's value converted to a <see cref="Guid"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <returns>An instance of <see cref="Guid"/>.</returns>
    public static Guid GetGuid(this IPublishedElement element, string propertyAlias) {
        return element.Value(propertyAlias) switch {
            Guid guid => guid,
            string str => Guid.TryParse(str, out Guid g) ? g : Guid.Empty,
            _ => Guid.Empty
        };
    }

    /// <summary>
    /// Returns the GUID value of the property with the specified <paramref name="propertyAlias"/>, or <see langword="null"/> if a matching property could not be found, or it's value converted to a <see cref="Guid"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <returns>An instance of <see cref="Guid"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static Guid? GetGuidOrNull(this IPublishedElement? element, string propertyAlias) {
        return element?.Value(propertyAlias) switch {
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
    /// <param name="value">When this method returns, holds <see cref="Guid"/> value if successful; otherwise, <see cref="Guid.Empty"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetGuid(this IPublishedElement? element, string alias, out Guid value) {
        if (element.TryGetGuid(alias, out Guid? guid)) {
            value = guid.Value;
            return true;
        }
        value = Guid.Empty;
        return false;
    }

    /// <summary>
    /// Attempts to get a GUID value from the property with the specified <paramref name="propertyAlias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <param name="value">When this method returns, holds <see cref="Guid"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetGuid(this IPublishedElement? element, string propertyAlias, [NotNullWhen(true)] out Guid? value) {

        if (element is not null && element.HasProperty(propertyAlias)) {
            value = element.GetGuidOrNull(propertyAlias);
            return value is not null;
        }

        value = null;
        return false;

    }

    #endregion

    #region String

    /// <summary>
    /// Returns the string value of the property with the specified <paramref name="propertyAlias"/>, or <see langword="null"/> if a matching property could not be found, or it's value converted to a <see cref="string"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <returns>An instance of <see cref="string"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static string? GetString(this IPublishedElement? element, string propertyAlias) {
        return element?.Value<string>(propertyAlias);
    }

    /// <summary>
    /// Returns the string value of the property with the specified <paramref name="propertyAlias"/>, or <paramref name="fallback"/> if a matching property could not be found, or it's value converted to a <see cref="string"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>An instance of <see cref="string"/> if successful; otherwise, <paramref name="fallback"/>.</returns>
    [return: NotNullIfNotNull(nameof(fallback))]
    public static string? GetString(this IPublishedElement? element, string propertyAlias, string? fallback) {
        string? value = element?.Value<string>(propertyAlias);
        return string.IsNullOrWhiteSpace(value) ? fallback : value;
    }

    /// <summary>
    /// Returns the first string value of the properties matching the specified <paramref name="propertyAliases"/>. If a matching property or a non-empty string value isn't found, <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAliases">A collection of property aliases to look for.</param>
    /// <returns></returns>propertyAlias
    public static string? GetString(this IPublishedElement? element, IEnumerable<string> propertyAliases) {
        foreach (string alias in propertyAliases) if (TryGetString(element, alias, out string? value)) return value;
        return null;
    }

    /// <summary>
    /// Attempts to get a string value from the property with the specified <paramref name="propertyAlias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <param name="value">When this method returns, holds the string value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetString(this IPublishedElement? element, string propertyAlias, [NotNullWhen(true)] out string? value) {

        if (element is not null && element.HasProperty(propertyAlias)) {
            value = element.GetString(propertyAlias).NullIfWhiteSpace();
            return value is not null;
        }

        value = null;
        return false;

    }

    /// <summary>
    /// Attempts to get the first string value of the properties matching the specified <paramref name="propertyAliases"/>. If a matching property or a non-empty string value isn't found, <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAliases">The aliases of the properties.</param>
    /// <param name="value">When this method returns, holds the string value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetString(this IPublishedElement element, IEnumerable<string> propertyAliases, [NotNullWhen(true)] out string? value) {
        return (value = GetStringOrNull(element, propertyAliases)) is not null;
    }

    /// <summary>
    /// Returns the string value if the property with the specified <paramref name="propertyAlias"/> exists and has a non-empty value; otherwise, <see langword="null"/> is returned.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The property aliases to check.</param>
    /// <returns>A string value if successful; otherwise, <see langword="null"/>.</returns>
    public static string? GetStringOrNull(this IPublishedElement element, string propertyAlias) {
        return element.GetString(propertyAlias).NullIfWhiteSpace();
    }

    /// <summary>
    /// Returns the first string value of the properties matching the specified <paramref name="propertyAliases"/>. If
    /// a non-empty string value isn't found, <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAliases">The property aliases to check.</param>
    /// <returns>The string value if successful; otherwise, <see langword="null"/>.</returns>
    public static string? GetStringOrNull(this IPublishedElement element, IEnumerable<string> propertyAliases) {

        foreach (string propertyAlias in propertyAliases) {
            if (element.TryGetString(propertyAlias, out string? value)) return value;
        }

        return null;

    }

    #endregion

    #region DateTime

    /// <summary>
    /// Returns a <see cref="DateTime"/> value of the property with the specified <paramref name="propertyAlias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <returns>An instance of <see cref="DateTime"/>.</returns>
    public static DateTime GetDateTime(this IPublishedElement? element, string propertyAlias) {

        // Get the property value
        DateTime? dt = element?.Value<DateTime>(propertyAlias);

        // Correct for wrong time zone as Umbraco returns the DateTime as "Utc" even though it is actually "Local"
        return dt is null ? DateTime.MinValue : new DateTime(dt.Value.Ticks, DateTimeKind.Local);

    }

    /// <summary>
    /// Returns a <see cref="DateTime"/> value of the property with the specified <paramref name="propertyAlias"/>, or
    /// <see langword="null"/> if the type of the property value doesn't match a <see cref="DateTime"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <returns>An instance of <see cref="DateTime"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static DateTime? GetDateTimeOrNull(this IPublishedElement? element, string propertyAlias) {

        // Get the property value
        DateTime? dt = element?.Value<DateTime>(propertyAlias);

        // Correct for wrong time zone as Umbraco returns the DateTime as "Utc" even though it is actually "Local"
        return dt is null ? null : new DateTime(dt.Value.Ticks, DateTimeKind.Local);

    }

    /// <summary>
    /// Attempts to get the <see cref="DateTime"/> value of the property with the specified <paramref name="propertyAlias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <param name="value">When this method returns, holds the <see cref="DateTime"/> value if successful; otherwise <see cref="DateTime.MinValue"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetDateTime(this IPublishedElement? element, string propertyAlias, out DateTime value) {

        if (element is not null && element.HasValue(propertyAlias) && element.Value(propertyAlias) is DateTime dt) {

            // Correct for wrong time zone as Umbraco returns the DateTime as "Utc" even though it is actually "Local"
            value = new DateTime(dt.Ticks, DateTimeKind.Local);

            return true;

        }

        value = default;
        return false;

    }

    /// <summary>
    /// Attempts to get the <see cref="DateTime"/> value of the property with the specified <paramref name="propertyAlias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <param name="value">When this method returns, holds the <see cref="DateTime"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetDateTime(this IPublishedElement? element, string propertyAlias, out DateTime? value) {

        if (element is not null && element.HasValue(propertyAlias) && element.Value(propertyAlias) is DateTime dt) {

            // Correct for wrong time zone as Umbraco returns the DateTime as "Utc" even though it is actually "Local"
            value = new DateTime(dt.Ticks, DateTimeKind.Local);

            return true;

        }

        value = null;
        return false;

    }

    #endregion

    #region Udi

    /// <summary>
    /// Returns the UDI value of the property with the specified <paramref name="propertyAlias"/>, or <see langword="null"/> if a matching property could not be found, or it's value converted to a <see cref="Udi"/> instance.
    /// </summary>
    /// <param name="element">The <see cref="IPublishedElement"/> holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <returns>An instance of <see cref="Udi"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static Udi? GetUdi(this IPublishedElement element, string propertyAlias) {
        object? value = element.Value(propertyAlias);
        return value switch {
            Udi udi => udi,
            IEnumerable<Udi> udis => udis.FirstOrDefault(),
            string str when UdiParser.TryParse(str, out Udi? udi) => udi,
            _ => null
        };
    }

    /// <summary>
    /// Returns a collection of UDI values of the property with the specified <paramref name="propertyAlias"/>, or an empty collection if a matching property could not be found, or it's value converted to a collection of <see cref="Udi"/> instances.
    /// </summary>
    /// <param name="element">The <see cref="IPublishedElement"/> holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <returns>A collection of <see cref="Udi"/> instances.</returns>
    public static IEnumerable<Udi> GetUdis(this IPublishedElement element, string propertyAlias) {
        object? value = element.Value(propertyAlias);
        return value switch {
            Udi udi => [udi],
            IEnumerable<Udi> udis => udis,
            string str => UdiUtils.ParseUdis(str),
            _ => []
        };
    }

    /// <summary>
    /// Attempts to get a UDI value from the property with the specified <paramref name="propertyAlias"/>.
    /// </summary>
    /// <param name="element">The <see cref="IPublishedElement"/> holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <param name="value">When this method returns, holds the <see cref="Udi"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetUdi(this IPublishedElement element, string propertyAlias, [NotNullWhen(true)] out Udi? value) {
        value = GetUdi(element, propertyAlias);
        return value is not null;
    }

    #endregion

    /// <summary>
    /// Returns the enum value of the property with the specified <paramref name="propertyAlias"/>, or the default value of <typeparamref name="TEnum"/> if a matching property could not be found, or it's value converted to a <typeparamref name="TEnum"/> instance.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="element">The <see cref="IPublishedElement"/> holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <returns>An instance of <typeparamref name="TEnum"/>, or the default value if not found.</returns>
    public static TEnum GetEnum<TEnum>(this IPublishedElement element, string propertyAlias) where TEnum : struct, Enum {
        return element.Value<TEnum>(propertyAlias);
    }

    /// <summary>
    /// Returns the enum value of the property with the specified <paramref name="propertyAlias"/>, or <paramref name="fallback"/> if a matching property could not be found, or it's value converted to a <typeparamref name="TEnum"/> instance.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="element">The <see cref="IPublishedElement"/> holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <param name="fallback">The fallback value to return if the property is not found.</param>
    /// <returns>An instance of <typeparamref name="TEnum"/>, or the fallback value if not found.</returns>
    public static TEnum GetEnum<TEnum>(this IPublishedElement element, string propertyAlias, TEnum fallback) where TEnum : struct, Enum {
        return element.Value(propertyAlias) is TEnum value ? value : fallback;
    }

    /// <summary>
    /// Attempts to get the value of type <typeparamref name="T"/> from the property with the specified <paramref name="propertyAlias"/>.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="element">The <see cref="IPublishedElement"/> holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <param name="value">When this method returns, holds the <typeparamref name="T"/> value of the property if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetValue<T>(this IPublishedElement? element, string propertyAlias, out T? value) {

        value = default;

        if (element == null) return false;
        if (!element.HasValue(propertyAlias)) return false;

        value = element.Value<T>(propertyAlias);
        return value != null;

    }

    /// <summary>
    /// Returns a read-only list of type <typeparamref name="T"/> from the property with the specified
    /// <paramref name="propertyAlias"/>. If a matching property could not be found, or it's value converted to a list
    /// of type <typeparamref name="T"/>, an empty list is returned instead.
    /// </summary>
    /// <typeparam name="T">The type of the items in the list.</typeparam>
    /// <param name="element">The <see cref="IPublishedElement"/> holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <returns>A list of <typeparamref name="T"/>.</returns>
    public static IReadOnlyList<T> GetReadOnlyList<T>(this IPublishedElement element, string propertyAlias) {
        return element.Value<IReadOnlyList<T>>(propertyAlias) ?? [];
    }

}