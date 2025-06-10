using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Examine;

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

}