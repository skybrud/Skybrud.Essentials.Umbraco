using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Examine;
using Skybrud.Essentials.Strings;
using Umbraco.Cms.Core;

namespace Skybrud.Essentials.Umbraco.Examine;

/// <summary>
/// Static class with various extension methods for working with Examine.
/// </summary>
public static class SearchResultExtensions {

    private static readonly char[] _udiSeparator = [',', ' '];

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
    /// Returns the value of the field with the specified <paramref name="key"/> converted using the specified <paramref name="func"/>.
    /// </summary>
    /// <typeparam name="TResult">The type to which the <see cref="int"/> value will be converted.</typeparam>
    /// <param name="result">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="func">A callback function for converting the <see cref="int"/> value into an instance of <typeparamref name="TResult"/>.</param>
    /// <returns>An instance of <typeparamref name="TResult"/> holding the converted field value if successful; otherwise, the default value of <typeparamref name="TResult"/>.</returns>
    public static TResult? GetInt32<TResult>(this ISearchResult result, string key, Func<int, TResult> func) {
        return result.TryGetInt32(key, out int value) ? func(value) : default;
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

    /// <summary>
    /// Attempts to get the value of the field with the specified <paramref name="key"/> and convert it to a <see cref="int"/>.
    /// If successful, the value is converted using the specified <paramref name="func"/> and returned.
    /// If the field doesn't exist or the value cannot be converted to a <see cref="int"/>, an exception is thrown.
    /// </summary>
    /// <typeparam name="TResult">The type to which the <see cref="int"/> value will be converted.</typeparam>
    /// <param name="result">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="func">A callback function for converting the <see cref="int"/> value into an instance of <typeparamref name="TResult"/>.</param>
    /// <returns>The converted value if successful.</returns>
    /// <exception cref="Exception">If the field doesn't exist or the value cannot be converted to a <see cref="int"/>.</exception>
    public static TResult GetRequiredInt32<TResult>(this ISearchResult result, string key, Func<int, TResult> func) {
        return func(GetRequiredInt32(result, key));
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
    /// Returns the value of the field with the specified <paramref name="key"/> converted using the specified <paramref name="func"/>.
    /// </summary>
    /// <typeparam name="TResult">The type to which the <see cref="long"/> value will be converted.</typeparam>
    /// <param name="result">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="func">A callback function for converting the <see cref="long"/> value into an instance of <typeparamref name="TResult"/>.</param>
    /// <returns>An instance of <typeparamref name="TResult"/> holding the converted field value if successful; otherwise, the default value of <typeparamref name="TResult"/>.</returns>
    public static TResult? GetInt64<TResult>(this ISearchResult result, string key, Func<long, TResult> func) {
        return result.TryGetInt64(key, out long value) ? func(value) : default;
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

    /// <summary>
    /// Attempts to get the value of the field with the specified <paramref name="key"/> and convert it to a <see cref="long"/>.
    /// If successful, the value is converted using the specified <paramref name="func"/> and returned.
    /// If the field doesn't exist or the value cannot be converted to a <see cref="long"/>, an exception is thrown.
    /// </summary>
    /// <typeparam name="TResult">The type to which the <see cref="long"/> value will be converted.</typeparam>
    /// <param name="result">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="func">A callback function for converting the <see cref="long"/> value into an instance of <typeparamref name="TResult"/>.</param>
    /// <returns>The converted value if successful.</returns>
    /// <exception cref="Exception">If the field doesn't exist or the value cannot be converted to a <see cref="long"/>.</exception>
    public static TResult GetRequiredInt64<TResult>(this ISearchResult result, string key, Func<long, TResult> func) {
        return func(GetRequiredInt64(result, key));
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
    /// Returns the value of the field with the specified <paramref name="key"/> converted using the specified <paramref name="func"/>.
    /// </summary>
    /// <typeparam name="TResult">The type to which the <see cref="float"/> value will be converted.</typeparam>
    /// <param name="result">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="func">A callback function for converting the <see cref="float"/> value into an instance of <typeparamref name="TResult"/>.</param>
    /// <returns>An instance of <typeparamref name="TResult"/> holding the converted field value if successful; otherwise, the default value of <typeparamref name="TResult"/>.</returns>
    public static TResult? GetFloat<TResult>(this ISearchResult result, string key, Func<float, TResult> func) {
        return result.TryGetFloat(key, out float value) ? func(value) : default;
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

    /// <summary>
    /// Attempts to get the value of the field with the specified <paramref name="key"/> and convert it to a <see cref="float"/>.
    /// If successful, the value is converted using the specified <paramref name="func"/> and returned.
    /// If the field doesn't exist or the value cannot be converted to a <see cref="float"/>, an exception is thrown.
    /// </summary>
    /// <typeparam name="TResult">The type to which the <see cref="float"/> value will be converted.</typeparam>
    /// <param name="result">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="func">A callback function for converting the <see cref="float"/> value into an instance of <typeparamref name="TResult"/>.</param>
    /// <returns>The converted value if successful.</returns>
    /// <exception cref="Exception">If the field doesn't exist or the value cannot be converted to a <see cref="float"/>.</exception>
    public static TResult GetRequiredFloat<TResult>(this ISearchResult result, string key, Func<float, TResult> func) {
        return func(GetRequiredFloat(result, key));
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
    /// Returns the value of the field with the specified <paramref name="key"/> converted using the specified <paramref name="func"/>.
    /// </summary>
    /// <typeparam name="TResult">The type to which the <see cref="double"/> value will be converted.</typeparam>
    /// <param name="result">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="func">A callback function for converting the <see cref="double"/> value into an instance of <typeparamref name="TResult"/>.</param>
    /// <returns>An instance of <typeparamref name="TResult"/> holding the converted field value if successful; otherwise, the default value of <typeparamref name="TResult"/>.</returns>
    public static TResult? GetDouble<TResult>(this ISearchResult result, string key, Func<double, TResult> func) {
        return result.TryGetDouble(key, out double value) ? func(value) : default;
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

    /// <summary>
    /// Attempts to get the value of the field with the specified <paramref name="key"/> and convert it to a <see cref="double"/>.
    /// If successful, the value is converted using the specified <paramref name="func"/> and returned.
    /// If the field doesn't exist or the value cannot be converted to a <see cref="double"/>, an exception is thrown.
    /// </summary>
    /// <typeparam name="TResult">The type to which the <see cref="double"/> value will be converted.</typeparam>
    /// <param name="result">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="func">A callback function for converting the <see cref="double"/> value into an instance of <typeparamref name="TResult"/>.</param>
    /// <returns>The converted value if successful.</returns>
    /// <exception cref="Exception">If the field doesn't exist or the value cannot be converted to a <see cref="double"/>.</exception>
    public static TResult GetRequiredDouble<TResult>(this ISearchResult result, string key, Func<double, TResult> func) {
        return func(GetRequiredDouble(result, key));
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
    /// Returns the value of the field with the specified <paramref name="key"/> converted using the specified <paramref name="func"/>.
    /// </summary>
    /// <typeparam name="TResult">The type to which the string value will be converted.</typeparam>
    /// <param name="searchResult">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="func">A callback function for converting the string value into an instance of <typeparamref name="TResult"/>.</param>
    /// <returns>An instance if <typeparamref name="TResult"/> holding the field value if successful; otherwise, the default value of <typeparamref name="TResult"/>.</returns>
    public static TResult? GetString<TResult>(this ISearchResult searchResult, string key, Func<string, TResult> func) {
        return searchResult.Values.TryGetValue(key, out string? result) ? func(result) : default;
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

    /// <summary>
    /// Returns the value of the field with the specified <paramref name="key"/> converted using the specified <paramref name="func"/>. If the field doesn't exist, or if the value is <see langword="null"/>, an exception is thrown.
    /// </summary>
    /// <typeparam name="TResult">The type to which the string value will be converted.</typeparam>
    /// <param name="result">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="func">A callback function for converting the string value into an instance of <typeparamref name="TResult"/>.</param>
    /// <returns>The converted value if successful.</returns>
    /// <exception cref="Exception">If the field doesn't exist or the value is <see langword="null"/>.</exception>
    public static TResult GetRequiredString<TResult>(this ISearchResult result, string key, Func<string, TResult> func) {
        if (!result.TryGetString(key, out string? value)) throw new Exception($"Failed getting string value from the '{key}' field.");
        return func(value);
    }

    #endregion

    #region Udi

    /// <summary>
    /// Returns the <see cref="Udi"/> value of the field with the specified <paramref name="key"/>, or <see langword="null"/> if the field doesn't exist or the value cannot be converted to a <see cref="Udi"/>. If the field value contains multiple UDI strings separated by commas or spaces, only the first value will be returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public static Udi? GetUdi(this ISearchResult result, string key) {
        if (!result.TryGetString(key, out string? value)) return null;
        string first = value.Split(_udiSeparator, StringSplitOptions.RemoveEmptyEntries)[0];
        return UdiParser.TryParse(first, out Udi? udi) ? udi : null;
    }

    /// <summary>
    /// Returns a list of <see cref="Udi"/> values from the field with the specified <paramref name="key"/>. The field value is expected to be a list of UDI strings separated by either commas or spaces.
    /// </summary>
    /// <param name="result">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <returns>A list of <see cref="Udi"/> values.</returns>
    public static IReadOnlyList<Udi> GetUdiList(this ISearchResult result, string key) {

        if (!result.AllValues.TryGetValue(key, out IReadOnlyList<string>? values)) return [];

        List<Udi> temp = [];

        foreach (string value in values) {
            foreach (string str in value.Split(_udiSeparator, StringSplitOptions.RemoveEmptyEntries)) {
                if (UdiParser.TryParse(str, out Udi? udi)) temp.Add(udi);
            }
        }

        return temp;

    }

    /// <summary>
    /// Attempts to get the value of the field with the specified <paramref name="key"/> and convert it to a <see cref="Udi"/>.
    /// </summary>
    /// <param name="searchResult">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="result">When this method returns, holds the <see cref="Udi"/> value if found; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the value was found and converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetUdi(this ISearchResult searchResult, string key, out Udi? result) {
        result = GetUdi(searchResult, key);
        return result is not null;
    }

    /// <summary>
    /// Attempts to get the value of the field with the specified <paramref name="key"/> and convert it to a <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of the UDI.</typeparam>
    /// <param name="searchResult">The search result.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="result">When this method returns, holds the <typeparamref name="TResult"/> value if found; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the value was found and converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetUdi<TResult>(this ISearchResult searchResult, string key, out TResult? result) where TResult : Udi {
        result = GetUdi(searchResult, key) as TResult;
        return result is not null;
    }

    #endregion

}