using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Examine;
using Skybrud.Essentials.Strings.Extensions;
using Umbraco.Cms.Core;

namespace Skybrud.Essentials.Umbraco.Examine;

/// <summary>
/// Static class with various extension methods for <see cref="ValueSet"/>.
/// </summary>
public static class ExamineValueSetExtensions {

    #region String

    /// <summary>
    /// Gets the first string value of the field with the specified <paramref name="key"/>. If field is found, but the
    /// first value isn't already a string, the value will be converted to a string. If a matching field isn't found,
    /// <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="valueSet">The value set.</param>
    /// <param name="key">The key of the field.</param>
    /// <returns>A <see cref="string"/> value if successful; otherwise; <see langword="null"/>.</returns>
    public static string? GetString(this ValueSet valueSet, string key) {
        return valueSet.TryGetString(key, out string? value) ? value : null;
    }

    /// <summary>
    /// Attempts to get the first string value of a field with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="valueSet">The value set.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="value">When this method returns, contains the value associated with the specified key, if the key is found; otherwise, the default value for the type of the value parameter. This parameter is passed uninitialized.</param>
    /// <returns><c>true</c> if the value set contains a field with the specified key; otherwise, <c>false</c>.</returns>
    public static bool TryGetString(this ValueSet valueSet, string key, [NotNullWhen(true)] out string? value) {
        value = valueSet.Values.TryGetValue(key, out IReadOnlyList<object>? values) && values.Count > 0 ? values[0].ToInvariantString() : null;
        return value is not null;
    }

    #endregion

    #region Int32

    /// <summary>
    /// Gets the first integer value of the field with the specified <paramref name="key"/>. If field is found, but the
    /// first value isn't already an integer, the value will be converted to an integer. If a matching field isn't found,
    /// <c>0</c> is returned instead.
    /// </summary>
    /// <param name="valueSet">The value set.</param>
    /// <param name="key">The key of the field.</param>
    /// <returns>A <see cref="string"/> value if successful; otherwise; <c>0</c>.</returns>
    public static int GetInt32(this ValueSet valueSet, string key) {
        return valueSet.TryGetInt32(key, out int value) ? value : 0;
    }

    /// <summary>
    /// Gets the first integer value of the field with the specified <paramref name="key"/>. If field is found, but the
    /// first value isn't already an integer, the value will be converted to an integer. If a matching field isn't found,
    /// <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="valueSet">The value set.</param>
    /// <param name="key">The key of the field.</param>
    /// <returns>A <see cref="string"/> value if successful; otherwise; <see langword="null"/>.</returns>
    public static int? GetInt32OrNull(this ValueSet valueSet, string key) {
        return valueSet.TryGetInt32(key, out int? value) ? value : null;
    }

    /// <summary>
    /// Attempts to get the first value of the field with the specified <paramref name="key"/>. If the value is not already an <see cref="int"/>, the method will try to convert it.
    /// </summary>
    /// <param name="valueSet">The value set.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="result">When this method returns, contains the value associated with the specified key, if the key is found; otherwise, <c>0</c>. This parameter is passed uninitialized.</param>
    /// <returns><c>true</c> if the value set contains a field with the specified key; otherwise, <c>false</c>.</returns>
    public static bool TryGetInt32(this ValueSet valueSet, string key, out int result) {

        if (!valueSet.Values.TryGetValue(key, out IReadOnlyList<object>? values) || values.Count == 0) {
            result = 0;
            return false;
        }

        result = 0;

        switch (values[0]) {

            case int numeric:
                result = numeric;
                return true;

            case string str:
                if (!int.TryParse(str, CultureInfo.InvariantCulture, out int temp)) return false;
                result = temp;
                return true;

            default:
                return false;

        }

    }

    /// <summary>
    /// Attempts to get the first value of the field with the specified <paramref name="key"/>. If the value is not already an <see cref="int"/>, the method will try to convert it.
    /// </summary>
    /// <param name="valueSet">The value set.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="result">When this method returns, contains the value associated with the specified key, if the key is found; otherwise, <c>null</c>. This parameter is passed uninitialized.</param>
    /// <returns><c>true</c> if the value set contains a field with the specified key; otherwise, <c>false</c>.</returns>
    public static bool TryGetInt32(this ValueSet valueSet, string key, [NotNullWhen(true)] out int? result) {

        if (!valueSet.Values.TryGetValue(key, out IReadOnlyList<object>? values) || values.Count == 0) {
            result = null;
            return false;
        }

        result = null;

        switch (values[0]) {

            case int numeric:
                result = numeric;
                return true;

            case string str:
                if (!int.TryParse(str, CultureInfo.InvariantCulture, out int temp)) return false;
                result = temp;
                return true;

            default:
                return false;

        }

    }

    #endregion

    #region Guid

    /// <summary>
    /// Gets the first GUID value of the field with the specified <paramref name="key"/>. If field is found, but the
    /// first value isn't already a GUID, the value will be converted to a GUID. If a matching field isn't found,
    /// <see cref="Guid.Empty"/> is returned instead.
    /// </summary>
    /// <param name="valueSet">The value set.</param>
    /// <param name="key">The key of the field.</param>
    /// <returns>A <see cref="Guid"/> value if successful; otherwise; <see cref="Guid.Empty"/>.</returns>
    public static Guid GetGuid(this ValueSet valueSet, string key) {
        return valueSet.TryGetGuid(key, out Guid value) ? value : Guid.Empty;
    }

    /// <summary>
    /// Gets the first GUID value of the field with the specified <paramref name="key"/>. If field is found, but the
    /// first value isn't already a GUID, the value will be converted to a GUID. If a matching field isn't found,
    /// <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="valueSet">The value set.</param>
    /// <param name="key">The key of the field.</param>
    /// <returns>A <see cref="Guid"/> value if successful; otherwise; <see langword="null"/>.</returns>
    public static Guid? GetGuidOrNull(this ValueSet valueSet, string key) {
        return valueSet.TryGetGuid(key, out Guid? value) ? value : null;
    }

    /// <summary>
    /// Attempts to get the first value of the field with the specified <paramref name="key"/>. If the value matches not already a <see cref="Guid"/>, the method will try to convert it.
    /// </summary>
    /// <param name="valueSet">The value set.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="result">When this method returns, contains the GUID value associated with the specified key, if the key is found and the value is a valid GUID; otherwise, <c>0</c>. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true"/> if the value set contains a field with the specified key and the value matches a valid GUID; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetGuid(this ValueSet valueSet, string key, out Guid result) {

        if (!valueSet.Values.TryGetValue(key, out IReadOnlyList<object>? values) || values.Count == 0) {
            result = Guid.Empty;
            return false;
        }

        result = Guid.Empty;

        switch (values[0]) {

            case Guid guid:
                result = guid;
                return true;

            case string str:
                if (!Guid.TryParse(str, out Guid temp)) return false;
                result = temp;
                return true;

            default:
                return false;

        }

    }

    /// <summary>
    /// Attempts to get the first value of the field with the specified <paramref name="key"/>. If the value matches not already a <see cref="Guid"/>, the method will try to convert it.
    /// </summary>
    /// <param name="valueSet">The value set.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="result">When this method returns, contains the GUID value associated with the specified key, if the key is found and the value is a valid GUID; otherwise, <see langword="null"/>. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true"/> if the value set contains a field with the specified key and the value matches a valid GUID; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetGuid(this ValueSet valueSet, string key, [NotNullWhen(true)] out Guid? result) {

        if (!valueSet.Values.TryGetValue(key, out IReadOnlyList<object>? values) || values.Count == 0) {
            result = null;
            return false;
        }

        result = null;

        switch (values[0]) {

            case Guid guid:
                result = guid;
                return true;

            case string str:
                if (!Guid.TryParse(str, out Guid temp)) return false;
                result = temp;
                return true;

            default:
                return false;

        }

    }


    #endregion

    #region DateTime

    /// <summary>
    /// Gets the first <see cref="DateTime"/> value from the field with the specified <paramref name="key"/>. If a
    /// matching field is found, but the value isn't already a <see cref="DateTime"/>, the method will attempt to parse
    /// the value into a <see cref="DateTime"/> value. If a matching field isn't found, or the value can't be parsed to
    /// a <see cref="DateTime"/> instance, <see cref="DateTime.MinValue"/> is returned instead.
    /// </summary>
    /// <param name="valueSet">The value set.</param>
    /// <param name="key">The key of the field.</param>
    /// <returns>A <see cref="DateTime"/> value if successful; otherwise; <see cref="DateTime.MinValue"/>.</returns>
    public static DateTime GetDateTime(this ValueSet valueSet, string key) {
        return TryGetDateTime(valueSet, key, out DateTime value) ? value : DateTime.MinValue;
    }

    /// <summary>
    /// Gets the first <see cref="DateTime"/> value from the field with the specified <paramref name="key"/>. If a
    /// matching field is found, but the value isn't already a <see cref="DateTime"/>, the method will attempt to parse
    /// the value into a <see cref="DateTime"/> value. If a matching field isn't found, or the value can't be parsed to
    /// a <see cref="DateTime"/> instance, <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="valueSet">The value set.</param>
    /// <param name="key">The key of the field.</param>
    /// <returns>A <see cref="DateTime"/> value if successful; otherwise; <see langword="null"/>.</returns>
    public static DateTime? GetDateTimeOrNull(this ValueSet valueSet, string key) {
        return TryGetDateTime(valueSet, key, out DateTime? value) ? value : null;
    }

    /// <summary>
    /// Attempts to get the <see cref="DateTime"/> value of the field with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="valueSet">The value set.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="result">When this method returns, contains the <see cref="DateTime"/> value associated with the specified key, if the key is found and the value is already a <see cref="DateTime"/> instance or it can successfully be converted to a <see cref="DateTime"/> instance; otherwise, <see cref="DateTime.MinValue"/>. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true"/> if the value set contains a field with the specified key and the conversion is successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetDateTime(this ValueSet valueSet, string key, out DateTime result) {

        // Attempt to get the values of the specified field
        if (!valueSet.Values.TryGetValue(key, out IReadOnlyList<object>? values) || values.Count == 0) {
            result = default;
            return false;
        }

        // Get the first value of the field
        switch (values[0]) {

            case DateTime dt:
                result = dt;
                return true;

            case string str:
                return DateTime.TryParseExact(str, ExamineDateFormats.Umbraco, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out result);

        }

        result = default;
        return false;

    }

    /// <summary>
    /// Attempts to get the <see cref="DateTime"/> value of the field with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="valueSet">The value set.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="result">When this method returns, contains the <see cref="DateTime"/> value associated with the specified key, if the key is found and the value is already a <see cref="DateTime"/> instance or it can successfully be converted to a <see cref="DateTime"/> instance; otherwise, <see langword="null"/>. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true"/> if the value set contains a field with the specified key and the conversion is successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetDateTime(this ValueSet valueSet, string key, [NotNullWhen(true)] out DateTime? result) {

        // Attempt to get the values of the specified field
        if (!valueSet.Values.TryGetValue(key, out IReadOnlyList<object>? values) || values.Count == 0) {
            result = null;
            return false;
        }

        // Get the first value of the field
        switch (values[0]) {

            case DateTime dt:
                result = dt;
                return true;

            case string str:
                if (DateTime.TryParseExact(str, ExamineDateFormats.Umbraco, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out DateTime temp)) {
                    result = temp;
                    return true;
                }
                break;

        }

        result = null;
        return false;

    }

    #endregion

    #region Udi

    /// <summary>
    /// Attempts to retrieve a <see cref="Udi"/> value from the specified key in the event arguments.
    /// </summary>
    /// <remarks>This method first attempts to retrieve a string value associated with the specified key from
    /// the event arguments. If the string value is found, it attempts to parse it as a <see cref="Udi"/>. If either
    /// step fails, the method returns <see langword="false"/>.</remarks>
    /// <param name="valueSet">The value set.</param>
    /// <param name="key">The key used to locate the value to parse as a <see cref="Udi"/>.</param>
    /// <param name="result">When this method returns, contains the parsed <see cref="Udi"/> if the operation succeeds; otherwise, <see
    /// langword="null"/>. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true"/> if the value associated with the specified key was successfully parsed as a <see cref="Udi"/>; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetUdi(this ValueSet valueSet, string key, [NotNullWhen(true)] out Udi? result) {
        if (valueSet.TryGetString(key, out string? value) && UdiParser.TryParse(value, out result)) return true;
        result = null;
        return false;
    }

    /// <summary>
    /// Attempts to get the value of the field with the specified <paramref name="key"/> and convert it to an instance of <typeparamref name="TResult"/>.
    /// </summary>
    /// <remarks>This method first attempts to retrieve a string value associated with the specified key from
    /// the event arguments. If the string value is found, it attempts to parse it as a <typeparamref name="TResult"/>. If either
    /// step fails, the method returns <see langword="false"/>.</remarks>
    /// <typeparam name="TResult">The type of the UDI.</typeparam>
    /// <param name="valueSet">The value set.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="result">When this method returns, contains the value associated with the specified key, if the key is found; otherwise, <see langword="null"/>. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true"/> if the value set contains a field with the specified key and the value can be converted to an instance of <typeparamref name="TResult"/>; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetUdi<TResult>(this ValueSet valueSet, string key, [NotNullWhen(true)] out TResult? result) where TResult : Udi {
        if (valueSet.TryGetString(key, out string? value) && UdiParser.TryParse(value, out result)) return true;
        result = null;
        return false;
    }

    #endregion

    /// <summary>
    /// Adds a value to the keyed item, if it doesn't exist the key will be created.
    /// </summary>
    /// <param name="valueSet">The value set.</param>
    /// <param name="key">The key.</param>
    /// <param name="value">The value to be added.</param>
    /// <returns>The number of items stored for the key.</returns>
    public static int Add(this ValueSet valueSet, string key, object value) {

        if (valueSet.Values is not IDictionary<string, IReadOnlyList<object>> dictionary) {
            throw new Exception($"'{nameof(valueSet.Values)}' is not an instance of '{typeof(IDictionary<string, IReadOnlyList<object>>)}'");
        }

        if (!dictionary.TryGetValue(key, out IReadOnlyList<object>? values)) {
            if (value is IReadOnlyList<object> valueAsList) {
                dictionary.Add(key, valueAsList);
                return valueAsList.Count;
            }
            dictionary.Add(key, values = new List<object>());
        }

        if (values is not List<object> list) {
            dictionary[key] = list = [.. values];
        }

        list.Add(value);

        return values.Count;

    }

    /// <summary>
    /// Sets the value of the field with the specified <paramref name="key"/> to <paramref name="value"/>. If the field doesn't exist, it will be created.
    /// </summary>
    /// <param name="valueSet">The value set.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="value">The value to be set.</param>
    public static void Set(this ValueSet valueSet, string key, object value) {

        if (valueSet.Values is not IDictionary<string, IReadOnlyList<object>> dictionary) {
            throw new Exception($"'{nameof(valueSet.Values)}' is not an instance of '{typeof(IDictionary<string, IReadOnlyList<object>>)}'");
        }

        // Convert "value" to a list if it's not already a list
        if (value is not IReadOnlyList<object> list) list = new List<object> { value };

        // Set the key in the dictionary (replace any existing value)
        dictionary[key] = list;

    }

    /// <summary>
    /// Attempts to add the specified <paramref name="value"/> to the item with <paramref name="key"/>, if the item does not already exist.
    /// </summary>
    /// <param name="valueSet">The value set.</param>
    /// <param name="key">The key.</param>
    /// <param name="value">The value to be added.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryAdd(this ValueSet valueSet, string key, object value) {

        if (valueSet.Values.ContainsKey(key)) return false;

        if (valueSet.Values is not IDictionary<string, IReadOnlyList<object>> dictionary) {
            throw new Exception($"'{nameof(valueSet.Values)}' is not an instance of '{typeof(IDictionary<string, IReadOnlyList<object>>)}'");
        }

        // Convert "value" to a list if it's not already a list
        if (value is not IReadOnlyList<object> list) list = new List<object> { value };

        // Add the list to the dictionary
        dictionary.Add(key, list);

        return true;

    }


}