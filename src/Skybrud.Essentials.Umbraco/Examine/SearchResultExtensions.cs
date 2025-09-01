using System;
using System.Diagnostics.CodeAnalysis;
using Examine;
using Skybrud.Essentials.Strings;

namespace Skybrud.Essentials.Umbraco.Examine;

/// <summary>
/// Static class with various extension methods for working with Examine.
/// </summary>
public static class SearchResultExtensions {

    #region Boolean

    /// <summary>
    /// Returns the <see cref="bool"/> value of the field with the specified <paramref name="key"/>, or <see langword="false"/> if the field doesn't exist or the value cannot be converted to a <see cref="bool"/>.
    /// </summary>
    /// <param name="result">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <returns>An instance of <see cref="bool"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool GetBoolean(this ISearchResult result, string key) {
        return result.TryGetBoolean(key, out bool value) && value;
    }

    /// <summary>
    /// Returns the <see cref="bool"/> value of the field with the specified <paramref name="key"/>, or <see langword="null"/> if the field doesn't exist or the value cannot be converted to a <see cref="bool"/>.
    /// </summary>
    /// <param name="result">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <returns>An instance of <see cref="bool"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static bool? GetBooleanOrNull(this ISearchResult result, string key) {
        return result.TryGetBoolean(key, out bool value) ? value : null;
    }

    /// <summary>
    /// Attempts to get the value of the field with the specified <paramref name="key"/> and convert it to a <see cref="bool"/>.
    /// </summary>
    /// <param name="searchResult">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="result">When this method returns, contains the value associated with the specified key, if the key is found, and if the value can be converted to a <see cref="int"/>; otherwise, <see langword="false"/>. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true"/> if the value set contains a field with the specified key and the value can be converted to a <see cref="bool"/>; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetBoolean(this ISearchResult searchResult, string key, out bool result) {
        result = false;
        return searchResult.Values.TryGetValue(key, out string? str) && StringUtils.TryParseBoolean(str, out result);
    }

    /// <summary>
    /// Attempts to get the value of the field with the specified <paramref name="key"/> and convert it to a <see cref="bool"/>.
    /// </summary>
    /// <param name="searchResult">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="result">When this method returns, contains the value associated with the specified key, if the key is found, and if the value can be converted to a <see cref="int"/>; otherwise, <see langword="null"/>. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true"/> if the value set contains a field with the specified key and the value can be converted to a <see cref="bool"/>; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetBoolean(this ISearchResult searchResult, string key, [NotNullWhen(true)] out bool? result) {
        result = null;
        return searchResult.Values.TryGetValue(key, out string? str) && StringUtils.TryParseBoolean(str, out result);
    }

    /// <summary>
    /// Attempts to get the value of the field with the specified <paramref name="key"/> and convert it to a <see cref="bool"/>.
    /// </summary>
    /// <param name="result">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <returns>The bool value if successful.</returns>
    /// <exception cref="Exception">If the field doesn't exist or the value is can not be converted to a <see cref="bool"/>.</exception>
    public static bool GetRequiredBoolean(this ISearchResult result, string key) {
        if (!result.TryGetBoolean(key, out bool value)) throw new Exception($"Failed getting boolean value from the '{key}' field.");
        return value;
    }

    #endregion

    #region Guid

    /// <summary>
    /// Returns the <see cref="Guid"/> value of the field with the specified <paramref name="key"/>, or <see cref="Guid.Empty"/> if the field doesn't exist or the value cannot be converted to a <see cref="Guid"/>.
    /// </summary>
    /// <param name="result">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <returns>An instance of <see cref="Guid"/> if successful; otherwise, <see cref="Guid.Empty"/>.</returns>
    public static Guid GetGuid(this ISearchResult result, string key) {
        return result.TryGetGuid(key, out Guid value) ? value : Guid.Empty;
    }

    /// <summary>
    /// Returns the <see cref="Guid"/> value of the field with the specified <paramref name="key"/>, or <see langword="null"/> if the field doesn't exist or the value cannot be converted to a <see cref="Guid"/>.
    /// </summary>
    /// <param name="result">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <returns>An instance of <see cref="Guid"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static Guid? GetGuidOrNull(this ISearchResult result, string key) {
        return result.TryGetGuid(key, out Guid value) ? value : null;
    }

    /// <summary>
    /// Attempts to get the value of the field with the specified <paramref name="key"/> and convert it to a <see cref="Guid"/>.
    /// </summary>
    /// <param name="searchResult">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="result">When this method returns, contains the value associated with the specified key, if the key is found; otherwise, <see cref="Guid.Empty"/>. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true"/> if the value set contains a field with the specified key and the value can be converted to a <see cref="Guid"/>; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetGuid(this ISearchResult searchResult, string key, out Guid result) {

        if (searchResult.Values.TryGetValue(key, out string? str)) {
            return Guid.TryParse(str, out result);
        }

        result = Guid.Empty;
        return false;

    }

    /// <summary>
    /// Attempts to get the value of the field with the specified <paramref name="key"/> and convert it to a <see cref="Guid"/>.
    /// </summary>
    /// <param name="result">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <returns>The GUID value if successful.</returns>
    /// <exception cref="Exception">If the field doesn't exist or the value is can not be converted to a <see cref="Guid"/>.</exception>
    public static Guid GetRequiredGuid(this ISearchResult result, string key) {
        if (!result.TryGetGuid(key, out Guid value)) throw new Exception($"Failed getting GUID value from the '{key}' field.");
        return value;
    }

    #endregion

    #region Int32

    /// <summary>
    /// Returns the <see cref="int"/> value of the field with the specified <paramref name="key"/>, or <c>0</c> if the field doesn't exist or the value cannot be converted to a <see cref="int"/>.
    /// </summary>
    /// <param name="result">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <returns>An instance of <see cref="int"/> if successful; otherwise, <c>0</c>.</returns>
    public static int GetInt32(this ISearchResult result, string key) {
        return result.TryGetInt32(key, out int value) ? value : 0;
    }

    /// <summary>
    /// Returns the <see cref="int"/> value of the field with the specified <paramref name="key"/>, or <see langword="null"/> if the field doesn't exist or the value cannot be converted to a <see cref="int"/>.
    /// </summary>
    /// <param name="result">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <returns>An instance of <see cref="int"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static int? GetInt32OrNull(this ISearchResult result, string key) {
        return result.TryGetInt32(key, out int value) ? value : null;
    }

    /// <summary>
    /// Attempts to get the value of the field with the specified <paramref name="key"/> and convert it to a <see cref="int"/>.
    /// </summary>
    /// <param name="searchResult">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="result">When this method returns, contains the value associated with the specified key, if the key is found, and if the value can be converted to a <see cref="int"/>; otherwise, <c>0</c>. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true"/> if the value set contains a field with the specified key and the value can be converted to a <see cref="int"/>; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt32(this ISearchResult searchResult, string key, out int result) {
        result = 0;
        return searchResult.Values.TryGetValue(key, out string? str) && StringUtils.TryParseInt32(str, out result);
    }

    /// <summary>
    /// Attempts to get the value of the field with the specified <paramref name="key"/> and convert it to a <see cref="int"/>.
    /// </summary>
    /// <param name="searchResult">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="result">When this method returns, contains the value associated with the specified key, if the key is found, and if the value can be converted to a <see cref="int"/>; otherwise, <see langword="null"/>. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true"/> if the value set contains a field with the specified key and the value can be converted to a <see cref="int"/>; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt32(this ISearchResult searchResult, string key, [NotNullWhen(true)] out int? result) {
        result = null;
        return searchResult.Values.TryGetValue(key, out string? str) && StringUtils.TryParseInt32(str, out result);
    }

    /// <summary>
    /// Attempts to get the value of the field with the specified <paramref name="key"/> and convert it to a <see cref="int"/>.
    /// </summary>
    /// <param name="result">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <returns>The int value if successful.</returns>
    /// <exception cref="Exception">If the field doesn't exist or the value is can not be converted to a <see cref="int"/>.</exception>
    public static int GetRequiredInt32(this ISearchResult result, string key) {
        if (!result.TryGetInt32(key, out int value)) throw new Exception($"Failed getting 32-bit integer value from the '{key}' field.");
        return value;
    }

    #endregion

    #region Int64

    /// <summary>
    /// Returns the <see cref="long"/> value of the field with the specified <paramref name="key"/>, or <c>0</c> if the field doesn't exist or the value cannot be converted to a <see cref="long"/>.
    /// </summary>
    /// <param name="result">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <returns>An instance of <see cref="long"/> if successful; otherwise, <c>0</c>.</returns>
    public static long GetInt64(this ISearchResult result, string key) {
        return result.TryGetInt64(key, out long value) ? value : 0;
    }

    /// <summary>
    /// Returns the <see cref="long"/> value of the field with the specified <paramref name="key"/>, or <see langword="null"/> if the field doesn't exist or the value cannot be converted to a <see cref="long"/>.
    /// </summary>
    /// <param name="result">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <returns>An instance of <see cref="long"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static long? GetInt64OrNull(this ISearchResult result, string key) {
        return result.TryGetInt64(key, out long value) ? value : null;
    }

    /// <summary>
    /// Attempts to get the value of the field with the specified <paramref name="key"/> and convert it to a <see cref="long"/>.
    /// </summary>
    /// <param name="searchResult">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="result">When this method returns, contains the value associated with the specified key, if the key is found, and if the value can be converted to a <see cref="int"/>; otherwise, <c>0</c>. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true"/> if the value set contains a field with the specified key and the value can be converted to a <see cref="long"/>; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt64(this ISearchResult searchResult, string key, out long result) {
        result = 0;
        return searchResult.Values.TryGetValue(key, out string? str) && StringUtils.TryParseInt64(str, out result);
    }

    /// <summary>
    /// Attempts to get the value of the field with the specified <paramref name="key"/> and convert it to a <see cref="long"/>.
    /// </summary>
    /// <param name="searchResult">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="result">When this method returns, contains the value associated with the specified key, if the key is found, and if the value can be converted to a <see cref="int"/>; otherwise, <see langword="null"/>. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true"/> if the value set contains a field with the specified key and the value can be converted to a <see cref="long"/>; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt64(this ISearchResult searchResult, string key, [NotNullWhen(true)] out long? result) {
        result = null;
        return searchResult.Values.TryGetValue(key, out string? str) && StringUtils.TryParseInt64(str, out result);
    }

    /// <summary>
    /// Attempts to get the value of the field with the specified <paramref name="key"/> and convert it to a <see cref="long"/>.
    /// </summary>
    /// <param name="result">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <returns>The long value if successful.</returns>
    /// <exception cref="Exception">If the field doesn't exist or the value is can not be converted to a <see cref="long"/>.</exception>
    public static long GetRequiredInt64(this ISearchResult result, string key) {
        if (!result.TryGetInt64(key, out long value)) throw new Exception($"Failed getting 64-bit integer value from the '{key}' field.");
        return value;
    }

    #endregion

    #region Float

    /// <summary>
    /// Returns the <see cref="float"/> value of the field with the specified <paramref name="key"/>, or <c>0</c> if the field doesn't exist or the value cannot be converted to a <see cref="float"/>.
    /// </summary>
    /// <param name="result">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <returns>An instance of <see cref="float"/> if successful; otherwise, <c>0</c>.</returns>
    public static float GetFloat(this ISearchResult result, string key) {
        return result.TryGetFloat(key, out float value) ? value : 0;
    }

    /// <summary>
    /// Returns the <see cref="float"/> value of the field with the specified <paramref name="key"/>, or <see langword="null"/> if the field doesn't exist or the value cannot be converted to a <see cref="float"/>.
    /// </summary>
    /// <param name="result">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <returns>An instance of <see cref="float"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static float? GetFloatOrNull(this ISearchResult result, string key) {
        return result.TryGetFloat(key, out float value) ? value : null;
    }

    /// <summary>
    /// Attempts to get the value of the field with the specified <paramref name="key"/> and convert it to a <see cref="float"/>.
    /// </summary>
    /// <param name="searchResult">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="result">When this method returns, contains the value associated with the specified key, if the key is found, and if the value can be converted to a <see cref="float"/>; otherwise, <c>0</c>. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true"/> if the value set contains a field with the specified key and the value can be converted to a <see cref="float"/>; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetFloat(this ISearchResult searchResult, string key, out float result) {
        result = 0;
        return searchResult.Values.TryGetValue(key, out string? str) && StringUtils.TryParseFloat(str, out result);
    }

    /// <summary>
    /// Attempts to get the value of the field with the specified <paramref name="key"/> and convert it to a <see cref="int"/>.
    /// </summary>
    /// <param name="searchResult">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="result">When this method returns, contains the value associated with the specified key, if the key is found, and if the value can be converted to a <see cref="float"/>; otherwise, <see langword="null"/>. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true"/> if the value set contains a field with the specified key and the value can be converted to a <see cref="float"/>; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetFloat(this ISearchResult searchResult, string key, [NotNullWhen(true)] out float? result) {
        result = null;
        return searchResult.Values.TryGetValue(key, out string? str) && StringUtils.TryParseFloat(str, out result);
    }

    /// <summary>
    /// Attempts to get the value of the field with the specified <paramref name="key"/> and convert it to a <see cref="float"/>.
    /// </summary>
    /// <param name="result">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <returns>The <see cref="float"/> value if successful.</returns>
    /// <exception cref="Exception">If the field doesn't exist or the value is can not be converted to a <see cref="float"/>.</exception>
    public static float GetRequiredFloat(this ISearchResult result, string key) {
        if (!result.TryGetFloat(key, out float value)) throw new Exception($"Failed getting single-precision floating point number from the '{key}' field.");
        return value;
    }

    #endregion

    #region Double

    /// <summary>
    /// Returns the <see cref="double"/> value of the field with the specified <paramref name="key"/>, or <c>0</c> if the field doesn't exist or the value cannot be converted to a <see cref="double"/>.
    /// </summary>
    /// <param name="result">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <returns>An instance of <see cref="double"/> if successful; otherwise, <c>0</c>.</returns>
    public static double GetDouble(this ISearchResult result, string key) {
        return result.TryGetDouble(key, out double value) ? value : 0;
    }

    /// <summary>
    /// Returns the <see cref="double"/> value of the field with the specified <paramref name="key"/>, or <see langword="null"/> if the field doesn't exist or the value cannot be converted to a <see cref="double"/>.
    /// </summary>
    /// <param name="result">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <returns>An instance of <see cref="double"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static double? GetDoubleOrNull(this ISearchResult result, string key) {
        return result.TryGetDouble(key, out double value) ? value : null;
    }

    /// <summary>
    /// Attempts to get the value of the field with the specified <paramref name="key"/> and convert it to a <see cref="double"/>.
    /// </summary>
    /// <param name="searchResult">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="result">When this method returns, contains the value associated with the specified key, if the key is found, and if the value can be converted to a <see cref="double"/>; otherwise, <c>0</c>. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true"/> if the value set contains a field with the specified key and the value can be converted to a <see cref="double"/>; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetDouble(this ISearchResult searchResult, string key, out double result) {
        result = 0;
        return searchResult.Values.TryGetValue(key, out string? str) && StringUtils.TryParseDouble(str, out result);
    }

    /// <summary>
    /// Attempts to get the value of the field with the specified <paramref name="key"/> and convert it to a <see cref="int"/>.
    /// </summary>
    /// <param name="searchResult">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="result">When this method returns, contains the value associated with the specified key, if the key is found, and if the value can be converted to a <see cref="double"/>; otherwise, <see langword="null"/>. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true"/> if the value set contains a field with the specified key and the value can be converted to a <see cref="double"/>; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetDouble(this ISearchResult searchResult, string key, [NotNullWhen(true)] out double? result) {
        result = null;
        return searchResult.Values.TryGetValue(key, out string? str) && StringUtils.TryParseDouble(str, out result);
    }

    /// <summary>
    /// Attempts to get the value of the field with the specified <paramref name="key"/> and convert it to a <see cref="double"/>.
    /// </summary>
    /// <param name="result">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <returns>The <see cref="double"/> value if successful.</returns>
    /// <exception cref="Exception">If the field doesn't exist or the value is can not be converted to a <see cref="double"/>.</exception>
    public static double GetRequiredDouble(this ISearchResult result, string key) {
        if (!result.TryGetDouble(key, out double value)) throw new Exception($"Failed getting double-precision floating point number from the '{key}' field.");
        return value;
    }

    #endregion

    #region String

    /// <summary>
    /// Returns the string value of the field with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="searchResult">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <returns>An instance if <see cref="string"/> holding the field value if successful; otherwise, <see langword="null"/>.</returns>
    public static string? GetString(this ISearchResult searchResult, string key) {
        return searchResult.Values.TryGetValue(key, out string? result) ? result : null;
    }

    /// <summary>
    /// Attempts to get the value of the field with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="searchResult">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="result">When this method returns, contains the value associated with the specified key, if the key is found; otherwise, <see langword="null"/>. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true"/> if the result contains a field with the specified key; otherwise, <see langword="null"/>.</returns>
    public static bool TryGetString(this ISearchResult searchResult, string key, [NotNullWhen(true)] out string? result) {

        if (searchResult.Values.TryGetValue(key, out result)) {
            return true;
        }

        result = null;
        return false;

    }

    /// <summary>
    /// Returns the string value of the field with the specified <paramref name="key"/>. If the field doesn't exist, or if the value is <see langword="null"/>, an exception is thrown.
    /// </summary>
    /// <param name="result">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <returns>The string value if successful.</returns>
    /// <exception cref="Exception">If the field doesn't exist or the value is <see langword="null"/>.</exception>
    public static string GetRequiredString(this ISearchResult result, string key) {
        if (!result.TryGetString(key, out string? value)) throw new Exception($"Failed getting string value from the '{key}' field.");
        return value;
    }

    #endregion

}