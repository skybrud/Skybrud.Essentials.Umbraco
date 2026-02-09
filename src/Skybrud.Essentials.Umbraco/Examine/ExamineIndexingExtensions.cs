using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Examine;
using Umbraco.Cms.Core;

namespace Skybrud.Essentials.Umbraco.Examine;

/// <summary>
/// Static class with various extension methods for aiding indexing in Umbraco/Examine.
/// </summary>
public static class ExamineIndexingExtensions {

    /// <summary>
    /// Gets the first string value of the field with the specified <paramref name="key"/>. If field is found, but the
    /// first value isn't already a string, the value will be converted to a string. If a matching field isn't found,
    /// <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="e">The event arguments about the node being indexed.</param>
    /// <param name="key">The key of the field.</param>
    /// <returns>A <see cref="string"/> value if successful; otherwise; <see langword="null"/>.</returns>
    public static string? GetString(this IndexingItemEventArgs e, string key) {
        return TryGetString(e, key, out string? value) ? value : null;
    }

    /// <summary>
    /// Attempts to get the first string value of a field with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="e">The event arguments about the node being indexed.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="value">When this method returns, contains the value associated with the specified key, if the key is found; otherwise, the default value for the type of the value parameter. This parameter is passed uninitialized.</param>
    /// <returns><c>true</c> if the value set contains a field with the specified key; otherwise, <c>false</c>.</returns>
    public static bool TryGetString(this IndexingItemEventArgs e, string key, [NotNullWhen(true)] out string? value) {
        value = e.ValueSet.Values.TryGetValue(key, out IReadOnlyList<object>? values) ? values.FirstOrDefault()?.ToString() : null;
        return value != null;
    }

    #region Udi

    /// <summary>
    /// Attempts to retrieve a <see cref="Udi"/> value from the specified key in the event arguments.
    /// </summary>
    /// <remarks>This method first attempts to retrieve a string value associated with the specified key from
    /// the event arguments. If the string value is found, it attempts to parse it as a <see cref="Udi"/>. If either
    /// step fails, the method returns <see langword="false"/>.</remarks>
    /// <param name="e">The <see cref="IndexingItemEventArgs"/> instance containing the event data.</param>
    /// <param name="key">The key used to locate the value to parse as a <see cref="Udi"/>.</param>
    /// <param name="result">When this method returns, contains the parsed <see cref="Udi"/> if the operation succeeds; otherwise, <see
    /// langword="null"/>. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true"/> if the value associated with the specified key was successfully parsed as a <see cref="Udi"/>; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetUdi(this IndexingItemEventArgs e, string key, [NotNullWhen(true)] out Udi? result) {
        if (e.TryGetString(key, out string? value)) return UdiParser.TryParse(value, out result);
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
    /// <param name="e">The event arguments about the node being indexed.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="result">When this method returns, contains the value associated with the specified key, if the key is found; otherwise, <see langword="null"/>. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true"/> if the value set contains a field with the specified key and the value can be converted to an instance of <typeparamref name="TResult"/>; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetUdi<TResult>(this IndexingItemEventArgs e, string key, [NotNullWhen(true)] out TResult? result) where TResult : Udi {
        if (e.TryGetString(key, out string? value)) return UdiParser.TryParse(value, out result);
        result = null;
        return false;
    }

    #endregion

}