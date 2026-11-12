using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Skybrud.Essentials.Umbraco;

/// <summary>
/// Static class with various extension methods for <see cref="IPublishedElement"/>.
/// </summary>
[Obsolete("Use the 'Skybrud.Essentials.Umbraco.PublishedContent.PublishedElementExtensions' class instead.")]
public static class PublishedElementExtensions {

    #region Boolean

    /// <summary>
    /// Returns the boolean value of the property with the specified <paramref name="alias"/>, or <see langword="false"/> if a matching property could not be found, or it's value converted to a <see cref="bool"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>An instance of <see cref="bool"/>.</returns>
    public static bool GetBoolean(this IPublishedElement element, string alias) {
        return PublishedContent.PublishedElementExtensions.GetBoolean(element, alias);
    }

    /// <summary>
    /// Returns the boolean value of the property with the specified <paramref name="propertyAlias"/>, or the specified <paramref name="fallback"/> value if a matching property could not be found, or it's value converted to a <see cref="bool"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>An instance of <see cref="bool"/> if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static bool GetBoolean(this IPublishedElement element, string propertyAlias, bool fallback) {
        return PublishedContent.PublishedElementExtensions.GetBoolean(element, propertyAlias, fallback);
    }

    /// <summary>
    /// Returns the boolean value of the property with the specified <paramref name="alias"/>, or <see langword="null"/> if a matching property could not be found, or it's value converted to a <see cref="bool"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>An instance of <see cref="bool"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static bool? GetBooleanOrNull(this IPublishedElement? element, string alias) {
        return PublishedContent.PublishedElementExtensions.GetBooleanOrNull(element, alias);
    }

    /// <summary>
    /// Attempts to get a boolean value from the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="result">When this method returns, holds the <see cref="bool"/> value if successful; otherwise, <see langword="false"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetBoolean(this IPublishedElement? element, string alias, out bool result) {
        return PublishedContent.PublishedElementExtensions.TryGetBoolean(element, alias, out result);
    }

    /// <summary>
    /// Attempts to get a boolean value from the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="result">When this method returns, holds the <see cref="bool"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetBoolean(this IPublishedElement? element, string alias, [NotNullWhen(true)] out bool? result) {
        return PublishedContent.PublishedElementExtensions.TryGetBoolean(element, alias, out result);
    }

    #endregion

    #region Int32

    /// <summary>
    /// Returns the 32-bit signed integer value of the property with the specified <paramref name="alias"/>, or <c>0</c> if a matching property could not be found, or it's value converted to a <see cref="int"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>An instance of <see cref="int"/>.</returns>
    public static int GetInt32(this IPublishedElement element, string alias) {
        return PublishedContent.PublishedElementExtensions.GetInt32(element, alias);
    }

    /// <summary>
    /// Returns the 32-bit signed integer value of the property with the specified <paramref name="alias"/>, or <see langword="null"/> if a matching property could not be found, or it's value converted to a <see cref="int"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>An instance of <see cref="int"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static int? GetInt32OrNull(this IPublishedElement? element, string alias) {
        return PublishedContent.PublishedElementExtensions.GetInt32OrNull(element, alias);
    }

    /// <summary>
    /// Attempts to get a 32-bit signed integer value from the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="result">When this method returns, holds the <see cref="int"/> value if successful; otherwise, <see langword="false"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt32(this IPublishedElement? element, string alias, out int result) {
        return PublishedContent.PublishedElementExtensions.TryGetInt32(element, alias, out result);
    }

    /// <summary>
    /// Attempts to get a 32-bit signed integer value from the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="result">When this method returns, holds the <see cref="int"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt32(this IPublishedElement? element, string alias, [NotNullWhen(true)] out int? result) {
        return PublishedContent.PublishedElementExtensions.TryGetInt32(element, alias, out result);
    }

    #endregion

    #region Int64

    /// <summary>
    /// Returns the 64-bit signed integer value of the property with the specified <paramref name="alias"/>, or <c>0</c> if a matching property could not be found, or it's value converted to a <see cref="long"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>An instance of <see cref="long"/>.</returns>
    public static long GetInt64(this IPublishedElement element, string alias) {
        return PublishedContent.PublishedElementExtensions.GetInt64(element, alias);
    }

    /// <summary>
    /// Returns the 64-bit signed integer value of the property with the specified <paramref name="alias"/>, or <see langword="null"/> if a matching property could not be found, or it's value converted to a <see cref="long"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>An instance of <see cref="long"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static long? GetInt64OrNull(this IPublishedElement? element, string alias) {
        return PublishedContent.PublishedElementExtensions.GetInt64OrNull(element, alias);
    }

    /// <summary>
    /// Attempts to get a 64-bit signed integer value from the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="result">When this method returns, holds the <see cref="long"/> value if successful; otherwise, <see langword="false"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt64(this IPublishedElement? element, string alias, out long result) {
        return PublishedContent.PublishedElementExtensions.TryGetInt64(element, alias, out result);
    }

    /// <summary>
    /// Attempts to get a 64-bit signed integer value from the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="result">When this method returns, holds the <see cref="long"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt64(this IPublishedElement? element, string alias, [NotNullWhen(true)] out long? result) {
        return PublishedContent.PublishedElementExtensions.TryGetInt64(element, alias, out result);
    }

    #endregion

    #region Float

    /// <summary>
    /// Returns the single-precision floating point value of the property with the specified <paramref name="alias"/>, or <c>0</c> if a matching property could not be found, or it's value converted to a <see cref="float"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>An instance of <see cref="float"/>.</returns>
    public static float GetFloat(this IPublishedElement element, string alias) {
        return PublishedContent.PublishedElementExtensions.GetFloat(element, alias);
    }

    /// <summary>
    /// Returns the single-precision floating point value of the property with the specified <paramref name="alias"/>, or <see langword="null"/> if a matching property could not be found, or it's value converted to a <see cref="float"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>An instance of <see cref="float"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static float? GetFloatOrNull(this IPublishedElement? element, string alias) {
        return PublishedContent.PublishedElementExtensions.GetFloatOrNull(element, alias);
    }

    /// <summary>
    /// Attempts to get a single-precision floating point value from the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="result">When this method returns, holds the <see cref="float"/> value if successful; otherwise, <see langword="false"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetFloat(this IPublishedElement? element, string alias, out float result) {
        return PublishedContent.PublishedElementExtensions.TryGetFloat(element, alias, out result);
    }

    /// <summary>
    /// Attempts to get a single-precision floating point value from the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="result">When this method returns, holds the <see cref="float"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetFloat(this IPublishedElement? element, string alias, [NotNullWhen(true)] out float? result) {
        return PublishedContent.PublishedElementExtensions.TryGetFloat(element, alias, out result);
    }

    #endregion

    #region Double

    /// <summary>
    /// Returns the double-precision floating point value of the property with the specified <paramref name="alias"/>, or <c>0</c> if a matching property could not be found, or it's value converted to a <see cref="double"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>An instance of <see cref="double"/>.</returns>
    public static double GetDouble(this IPublishedElement element, string alias) {
        return PublishedContent.PublishedElementExtensions.GetDouble(element, alias);
    }

    /// <summary>
    /// Returns the double-precision floating point value of the property with the specified <paramref name="alias"/>, or <see langword="null"/> if a matching property could not be found, or it's value converted to a <see cref="double"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>An instance of <see cref="double"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static double? GetDoubleOrNull(this IPublishedElement? element, string alias) {
        return PublishedContent.PublishedElementExtensions.GetDoubleOrNull(element, alias);
    }

    /// <summary>
    /// Attempts to get a double-precision floating point value from the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="result">When this method returns, holds the <see cref="double"/> value if successful; otherwise, <see langword="false"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetDouble(this IPublishedElement? element, string alias, out double result) {
        return PublishedContent.PublishedElementExtensions.TryGetDouble(element, alias, out result);
    }

    /// <summary>
    /// Attempts to get a double-precision floating point value from the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="result">When this method returns, holds the <see cref="double"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetDouble(this IPublishedElement? element, string alias, [NotNullWhen(true)] out double? result) {
        return PublishedContent.PublishedElementExtensions.TryGetDouble(element, alias, out result);
    }

    #endregion

    #region Guid

    /// <summary>
    /// Returns the GUID value of the property with the specified <paramref name="alias"/>, or <see cref="Guid.Empty"/> if a matching property could not be found, or it's value converted to a <see cref="Guid"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>An instance of <see cref="Guid"/>.</returns>
    public static Guid GetGuid(this IPublishedElement element, string alias) {
        return PublishedContent.PublishedElementExtensions.GetGuid(element, alias);
    }

    /// <summary>
    /// Returns the GUID value of the property with the specified <paramref name="alias"/>, or <see langword="null"/> if a matching property could not be found, or it's value converted to a <see cref="Guid"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>An instance of <see cref="Guid"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static Guid? GetGuidOrNull(this IPublishedElement? element, string alias) {
        return PublishedContent.PublishedElementExtensions.GetGuidOrNull(element, alias);
    }

    /// <summary>
    /// Attempts to get a GUID value from the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="result">When this method returns, holds <see cref="Guid"/> value if successful; otherwise, <see cref="Guid.Empty"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetGuid(this IPublishedElement? element, string alias, out Guid result) {
        return PublishedContent.PublishedElementExtensions.TryGetGuid(element, alias, out result);
    }

    /// <summary>
    /// Attempts to get a GUID value from the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="result">When this method returns, holds <see cref="Guid"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetGuid(this IPublishedElement? element, string alias, [NotNullWhen(true)] out Guid? result) {
        return PublishedContent.PublishedElementExtensions.TryGetGuid(element, alias, out result);
    }

    #endregion

    #region String

    /// <summary>
    /// Returns the string value of the property with the specified <paramref name="alias"/>, or <see langword="null"/> if a matching property could not be found, or it's value converted to a <see cref="string"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>An instance of <see cref="string"/> if successful; otherwise, <see langword="null"/>.</returns>
    [Obsolete("Use the 'Skybrud.Essentials.Umbraco.PublishedContent.PublishedElementExtensions.GetString' method instead.")]
    public static string? GetString(this IPublishedElement? element, string alias) {
        return PublishedContent.PublishedElementExtensions.GetString(element, alias);
    }

    /// <summary>
    /// Returns the string value of the property with the specified <paramref name="alias"/>, or <paramref name="fallback"/> if a matching property could not be found, or it's value converted to a <see cref="string"/> instance.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>An instance of <see cref="string"/> if successful; otherwise, <paramref name="fallback"/>.</returns>
    [Obsolete("Use the 'Skybrud.Essentials.Umbraco.PublishedContent.PublishedElementExtensions.GetString' method instead.")]
    [return: NotNullIfNotNull(nameof(fallback))]
    public static string? GetString(this IPublishedElement? element, string alias, string? fallback) {
        return PublishedContent.PublishedElementExtensions.GetString(element, alias, fallback);
    }

    /// <summary>
    /// Returns the first string value of the properties matching the specified <paramref name="aliases"/>. If a matching property or a non-empty string value isn't found, <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="aliases">A collection of property aliases to look for.</param>
    /// <returns></returns>
    [Obsolete("Use the 'Skybrud.Essentials.Umbraco.PublishedContent.PublishedElementExtensions.GetString' method instead.")]
    public static string? GetString(this IPublishedElement? element, IEnumerable<string> aliases) {
        return PublishedContent.PublishedElementExtensions.GetString(element, aliases);
    }

    /// <summary>
    /// Attempts to get a string value from the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="result">When this method returns, holds the string value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    [Obsolete("Use the 'Skybrud.Essentials.Umbraco.PublishedContent.PublishedElementExtensions.TryGetString' method instead.")]
    public static bool TryGetString(this IPublishedElement? element, string alias, [NotNullWhen(true)] out string? result) {
        return PublishedContent.PublishedElementExtensions.TryGetString(element, alias, out result);
    }

    /// <summary>
    /// Attempts to get the first string value of the properties matching the specified <paramref name="aliases"/>. If a matching property or a non-empty string value isn't found, <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="aliases">The aliases of the properties.</param>
    /// <param name="result">When this method returns, holds the string value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    [Obsolete("Use the 'Skybrud.Essentials.Umbraco.PublishedContent.PublishedElementExtensions.TryGetString' method instead.")]
    public static bool TryGetString(this IPublishedElement element, IEnumerable<string> aliases, [NotNullWhen(true)] out string? result) {
        return PublishedContent.PublishedElementExtensions.TryGetString(element, aliases, out result);
    }

    /// <summary>
    /// Returns the string value if the property with the specified <paramref name="propertyAlias"/> exists and has a non-empty value; otherwise, <see langword="null"/> is returned.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="propertyAlias">The property aliases to check.</param>
    /// <returns>A string value if successful; otherwise, <see langword="null"/>.</returns>
    [Obsolete("Use the 'Skybrud.Essentials.Umbraco.PublishedContent.PublishedElementExtensions.GetStringOrNull' method instead.")]
    public static string? GetStringOrNull(this IPublishedElement element, string propertyAlias) {
        return PublishedContent.PublishedElementExtensions.GetString(element, propertyAlias);
    }

    /// <summary>
    /// Returns the first string value of the properties matching the specified <paramref name="propertyAliases"/>. If
    /// a non-empty string value isn't found, <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="content"></param>
    /// <param name="propertyAliases">The property aliases to check.</param>
    /// <returns>The string value if successful; otherwise, <see langword="null"/>.</returns>
    [Obsolete("Use the 'Skybrud.Essentials.Umbraco.PublishedContent.PublishedElementExtensions.GetStringOrNull' method instead.")]
    public static string? GetStringOrNull(this IPublishedElement content, IEnumerable<string> propertyAliases) {
        return PublishedContent.PublishedElementExtensions.GetString(content, propertyAliases);
    }

    #endregion

    #region DateTime

    /// <summary>
    /// Returns a <see cref="DateTime"/> value of the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>An instance of <see cref="DateTime"/>.</returns>
    [Obsolete("Use the 'Skybrud.Essentials.Umbraco.PublishedContent.PublishedElementExtensions.GetDateTime' method instead.")]
    public static DateTime GetDateTime(this IPublishedElement? element, string alias) {
        return PublishedContent.PublishedElementExtensions.GetDateTime(element, alias);
    }

    /// <summary>
    /// Returns a <see cref="DateTime"/> value of the property with the specified <paramref name="alias"/>, or
    /// <see langword="null"/> if the type of the property value doesn't match a <see cref="DateTime"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>An instance of <see cref="DateTime"/> if successful; otherwise, <see langword="null"/>.</returns>
    [Obsolete("Use the 'Skybrud.Essentials.Umbraco.PublishedContent.PublishedElementExtensions.GetDateTimeOrNull' method instead.")]
    public static DateTime? GetDateTimeOrNull(this IPublishedElement? element, string alias) {
        return PublishedContent.PublishedElementExtensions.GetDateTimeOrNull(element, alias);
    }

    /// <summary>
    /// Attempts to get the <see cref="DateTime"/> value of the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="value">When this method returns, holds the <see cref="DateTime"/> value if successful; otherwise <see cref="DateTime.MinValue"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    [Obsolete("Use the 'Skybrud.Essentials.Umbraco.PublishedContent.PublishedElementExtensions.TryGetDateTime' method instead.")]
    public static bool TryGetDateTime(this IPublishedElement? element, string alias, out DateTime value) {
        return PublishedContent.PublishedElementExtensions.TryGetDateTime(element, alias, out value);
    }

    /// <summary>
    /// Attempts to get the <see cref="DateTime"/> value of the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The element holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="value">When this method returns, holds the <see cref="DateTime"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    [Obsolete("Use the 'Skybrud.Essentials.Umbraco.PublishedContent.PublishedElementExtensions.TryGetDateTime' method instead.")]
    public static bool TryGetDateTime(this IPublishedElement? element, string alias, out DateTime? value) {
        return PublishedContent.PublishedElementExtensions.TryGetDateTime(element, alias, out value);
    }

    #endregion

    #region Udi

    /// <summary>
    /// Returns the UDI value of the property with the specified <paramref name="alias"/>, or <see langword="null"/> if a matching property could not be found, or it's value converted to a <see cref="Udi"/> instance.
    /// </summary>
    /// <param name="element">The <see cref="IPublishedElement"/> holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>An instance of <see cref="Udi"/> if successful; otherwise, <see langword="null"/>.</returns>
    [Obsolete("Use the 'Skybrud.Essentials.Umbraco.PublishedContent.PublishedElementExtensions.GetUdi' method instead.")]
    public static Udi? GetUdi(this IPublishedElement element, string alias) {
        return PublishedContent.PublishedElementExtensions.GetUdi(element, alias);
    }

    /// <summary>
    /// Returns a collection of UDI values of the property with the specified <paramref name="alias"/>, or an empty collection if a matching property could not be found, or it's value converted to a collection of <see cref="Udi"/> instances.
    /// </summary>
    /// <param name="element">The <see cref="IPublishedElement"/> holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <returns>A collection of <see cref="Udi"/> instances.</returns>
    [Obsolete("Use the 'Skybrud.Essentials.Umbraco.PublishedContent.PublishedElementExtensions.GetUdi' method instead.")]
    public static IEnumerable<Udi> GetUdis(this IPublishedElement element, string alias) {
        return PublishedContent.PublishedElementExtensions.GetUdis(element, alias);
    }

    /// <summary>
    /// Attempts to get a UDI value from the property with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="element">The <see cref="IPublishedElement"/> holding the property.</param>
    /// <param name="alias">The alias of the property.</param>
    /// <param name="result">When this method returns, holds the <see cref="Udi"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    [Obsolete("Use the 'Skybrud.Essentials.Umbraco.PublishedContent.PublishedElementExtensions.TryGetUdi' method instead.")]
    public static bool TryGetUdi(this IPublishedElement element, string alias, [NotNullWhen(true)] out Udi? result) {
        return PublishedContent.PublishedElementExtensions.TryGetUdi(element, alias, out result);
    }

    #endregion

    #region Enum

    /// <summary>
    /// Returns the enum value of the property with the specified <paramref name="propertyAlias"/>, or the default value of <typeparamref name="TEnum"/> if a matching property could not be found, or it's value converted to a <typeparamref name="TEnum"/> instance.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="element">The <see cref="IPublishedElement"/> holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <returns>An instance of <typeparamref name="TEnum"/>, or the default value if not found.</returns>
    [Obsolete("Use the 'Skybrud.Essentials.Umbraco.PublishedContent.PublishedElementExtensions.GetEnum' method instead.")]
    public static TEnum GetEnum<TEnum>(this IPublishedElement element, string propertyAlias) where TEnum : struct, Enum {
        return PublishedContent.PublishedElementExtensions.GetEnum<TEnum>(element, propertyAlias);
    }

    /// <summary>
    /// Returns the enum value of the property with the specified <paramref name="propertyAlias"/>, or <paramref name="fallback"/> if a matching property could not be found, or it's value converted to a <typeparamref name="TEnum"/> instance.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="element">The <see cref="IPublishedElement"/> holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <param name="fallback">The fallback value to return if the property is not found.</param>
    /// <returns>An instance of <typeparamref name="TEnum"/>, or the fallback value if not found.</returns>
    [Obsolete("Use the 'Skybrud.Essentials.Umbraco.PublishedContent.PublishedElementExtensions.GetEnum' method instead.")]
    public static TEnum GetEnum<TEnum>(this IPublishedElement element, string propertyAlias, TEnum fallback) where TEnum : struct, Enum {
        return PublishedContent.PublishedElementExtensions.GetEnum(element, propertyAlias, fallback);
    }

    /// <summary>
    /// Attempts to get the value of type <typeparamref name="T"/> from the property with the specified <paramref name="propertyAlias"/>.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="element">The <see cref="IPublishedElement"/> holding the property.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <param name="result">When this method returns, holds the <typeparamref name="T"/> value of the property if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    [Obsolete("Use the 'Skybrud.Essentials.Umbraco.PublishedContent.PublishedElementExtensions.TryGetValue' method instead.")]
    public static bool TryGetValue<T>(this IPublishedElement? element, string propertyAlias, out T? result) {
        return PublishedContent.PublishedElementExtensions.TryGetValue(element, propertyAlias, out result);
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
    [Obsolete("Use the 'Skybrud.Essentials.Umbraco.PublishedContent.PublishedElementExtensions.GetReadOnlyList' method instead.")]
    public static IReadOnlyList<T> GetReadOnlyList<T>(this IPublishedElement element, string propertyAlias) {
        return PublishedContent.PublishedElementExtensions.GetReadOnlyList<T>(element, propertyAlias);
    }

    #endregion

}