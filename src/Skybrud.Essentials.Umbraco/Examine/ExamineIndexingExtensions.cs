using System;
using System.Collections.Generic;
using System.Linq;
using Examine;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Time.Iso8601;
using Umbraco.Cms.Core;

namespace Skybrud.Essentials.Umbraco.Examine;

/// <summary>
/// Static class with various extension methods for <see cref="IndexingItemEventArgs"/>.
/// </summary>
public static class ExamineIndexingExtensions {

    /// <summary>
    /// Adds a value to the keyed item, if it doesn't exist the key will be created.
    /// </summary>
    /// <param name="e">The event arguments about the node being indexed.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="value">The value to be added.</param>
    /// <returns>The updated event arguments.</returns>
    public static IndexingItemEventArgs Add(this IndexingItemEventArgs e, string key, object value) {
        e.ValueSet.Add(key, value);
        return e;
    }

    /// <summary>
    /// Sets the value of the field with the specified <paramref name="key"/> to <paramref name="value"/>. If the field doesn't exist, it will be created.
    /// </summary>
    /// <param name="e">The event arguments about the node being indexed.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="value">The value to be set.</param>
    /// <returns>The updated event arguments.</returns>
    public static IndexingItemEventArgs Set(this IndexingItemEventArgs e, string key, object value) {
        e.ValueSet.Add(key, value);
        return e;
    }

    /// <summary>
    /// Adds a new field with <paramref name="key"/> and <paramref name="value"/> if the field does not already exist.
    /// </summary>
    /// <param name="e"></param>
    /// <param name="key">The key of the field.</param>
    /// <param name="value">The new value.</param>
    public static IndexingItemEventArgs AddDefaultValue(this IndexingItemEventArgs e, string key, string value) {

        // Does the field already exist?
        if (e.ValueSet.Values.ContainsKey(key)) return e;

        // Add the default value
        e.ValueSet.TryAdd(key, value);

        return e;

    }

    /// <summary>
    /// If a field with <paramref name="key"/> doesn't already exist, a new field where the key is a combination of
    /// <paramref name="key"/> and <paramref name="suffix"/> will be added with <paramref name="value"/>.
    /// </summary>
    /// <param name="e"></param>
    /// <param name="key">The key of the field.</param>
    /// <param name="value">The new value.</param>
    /// <param name="suffix">The suffix for the key of the new field.</param>
    public static IndexingItemEventArgs AddDefaultValue(this IndexingItemEventArgs e, string key, string value, string suffix) {

        // Does the field already exist?
        if (e.ValueSet.Values.ContainsKey(key)) return e;

        // Add the default value
        e.ValueSet.TryAdd($"{key}{suffix}", value);

        return e;

    }

    /// <summary>
    /// Adds a new field with the specified <paramref name="key"/> and <paramref name="value"/>. Examine doesn't support boolean, so the value will be indexed as either <c>1</c> or <c>0</c>.
    /// </summary>
    /// <param name="e">The event arguments about the node being indexed.</param>
    /// <param name="key">The key of the new field.</param>
    /// <param name="value">The boolean value to index.</param>
    public static IndexingItemEventArgs AddBoolean(this IndexingItemEventArgs e, string key, bool value) {
        e.ValueSet.TryAdd(key, value ? "1" : "0");
        return e;
    }

    /// <summary>
    /// Adds a new <c>hideFromSearch</c> field to the value set indicating whether the node should be hidden (excluded) from search results.
    /// </summary>
    /// <param name="e"></param>
    public static IndexingItemEventArgs AddHideFromSearch(this IndexingItemEventArgs e) {
        return AddHideFromSearch(e, default(HashSet<int>));
    }

    /// <summary>
    /// Adds a new <c>hideFromSearch</c> field to the value set indicating whether the node should be hidden
    /// (excluded) from search results.
    ///
    /// The <paramref name="ignoreId"/> parameter can be used to specify an area of the website that should
    /// automatically be hidden from search results. This is done by checking whether the ID of the
    /// <paramref name="ignoreId"/> parameter is part of the <c>path</c> field of the value set for the current node.
    /// </summary>
    /// <param name="e"></param>
    /// <param name="ignoreId">The ID for which the node itself and it's descendants should be hidden.</param>
    public static IndexingItemEventArgs AddHideFromSearch(this IndexingItemEventArgs e, int ignoreId) {
        return AddHideFromSearch(e, new HashSet<int> { ignoreId });
    }

    /// <summary>
    /// Adds a new <c>hideFromSearch</c> field to the value set indicating whether the node should be hidden
    /// (excluded) from search results.
    ///
    /// The <paramref name="ignoreIds"/> parameter can be used to specify areas of the website that should
    /// automatically be hidden from search results. This is done by checking whether at least one of the IDs the
    /// <paramref name="ignoreIds"/> parameter is part of the <c>path</c> field of the value set for the current node.
    /// </summary>
    /// <param name="e"></param>
    /// <param name="ignoreIds">The IDs for which itself and it's descendants should be hidden.</param>
    public static IndexingItemEventArgs AddHideFromSearch(this IndexingItemEventArgs e, params int[] ignoreIds) {
        return AddHideFromSearch(e, new HashSet<int>(ignoreIds));
    }

    /// <summary>
    /// Adds a new <c>hideFromSearch</c> field to the value set indicating whether the node should be hidden
    /// (excluded) from search results.
    ///
    /// The <paramref name="ignoreIds"/> parameter can be used to specify areas of the website that should
    /// automatically be hidden from search results. This is done by checking whether at least one of the IDs the
    /// <paramref name="ignoreIds"/> parameter is part of the <c>path</c> field of the value set for the current node.
    /// </summary>
    /// <param name="e"></param>
    /// <param name="ignoreIds">The IDs for which itself and it's descendants should be hidden.</param>
    public static IndexingItemEventArgs AddHideFromSearch(this IndexingItemEventArgs e, HashSet<int>? ignoreIds) {

        e.ValueSet.Values.TryGetValue(ExamineFields.Path, out IReadOnlyList<object>? objList);
        int[] ids = objList is null || objList.Count == 0 ? [] : StringUtils.ParseInt32Array(objList[0].ToString());

        if (ignoreIds != null && ids.Any(ignoreIds.Contains)) {
            e.ValueSet.Set(ExamineFields.HideFromSearch, "1");
            return e;
        }

        // Skip if the field already exists, as we don't want to override it
        if (e.ValueSet.Values.ContainsKey(ExamineFields.HideFromSearch)) return e;

        // Add a new field with the value "0" indicating that the node should not be hidden from search results
        e.ValueSet.TryAdd(ExamineFields.HideFromSearch, "0");

        return e;

    }

    /// <summary>
    /// Adds a search-friendly version of the <c>path</c> field where the IDs are separated by spaces instead of commas.
    /// </summary>
    /// <param name="e">The event arguments about the node being indexed.</param>
    public static IndexingItemEventArgs IndexPath(this IndexingItemEventArgs e) {
        return IndexCsv(e, ExamineFields.Path);
    }

    /// <summary>
    /// If a field with <paramref name="key"/> exists, a new field in which commas in the value has been replaced
    /// by spaces, making each value searchable.
    ///
    /// The key of the new field will use <c>_search</c> as suffix - e.g. if <paramref name="key"/> is <c>path</c>,
    /// the new field will have the key <c>path_search</c>.
    /// </summary>
    /// <param name="e">The event arguments about the node being indexed.</param>
    /// <param name="key">The key of the field to make searchable.</param>
    public static IndexingItemEventArgs IndexCsv(this IndexingItemEventArgs e, string key) {
        return IndexCsv(e, key, $"{key}_search");
    }

    /// <summary>
    /// If a field with <paramref name="key"/> exists, a new field in which commas in the value has been replaced
    /// by spaces, making each value searchable.
    /// </summary>
    /// <param name="e">The event arguments about the node being indexed.</param>
    /// <param name="key">The key of the field to make searchable.</param>
    /// <param name="newKey">The key of the new field.</param>
    public static IndexingItemEventArgs IndexCsv(this IndexingItemEventArgs e, string key, string newKey) {

        // Attempt to get the values of the specified field
        if (!e.ValueSet.Values.TryGetValue(key, out IReadOnlyList<object>? values)) return e;

        // Get the first value and replace all commas with an empty space
        string? value = values
            .FirstOrDefault()?
            .ToString()?
            .Replace(',', ' ')
            .Replace('[', ' ')
            .Replace(']', ' ')
            .Replace('"', ' ');

        // Ignore if null, empty or white space
        if (string.IsNullOrWhiteSpace(value)) return e;

        // Added the searchable value to the index
        e.ValueSet.TryAdd(newKey, value);

        return e;

    }


    /// <summary>
    /// Adds searchable versions of the date values in the fields with the specified <paramref name="keys"/>.
    ///
    /// The searchable values will be added in new fields using the <c>_range</c> prefix for the keys (as it enables
    /// a ranged query) and the value will be formatted using <c>yyyyMMddHHmm00000</c>.
    /// </summary>
    /// <param name="e"></param>
    /// <param name="keys">The keys of the fields.</param>
    public static IndexingItemEventArgs IndexDate(this IndexingItemEventArgs e, params string[]? keys) {
        if (keys is null) return e;
        foreach (string key in keys) IndexDate(e, key);
        return e;
    }

    /// <summary>
    /// Determines a content date of the item and adds additional fields for various formats to the item's value set.
    /// </summary>
    /// <param name="e">The event args for the item being indexed.</param>
    /// <param name="fields">A list of field to look for - e.g. <c>createDate</c> or <c>newsDate</c>.</param>
    public static IndexingItemEventArgs IndexContentDate(this IndexingItemEventArgs e, IEnumerable<string> fields) {

        foreach (string field in fields) {
            if (e.ValueSet.TryGetDateTime(field, out DateTime dt)) {
                return IndexDateTime(e, ExamineFields.ContentDate, dt);
            }
        }

        return e;

    }

    /// <summary>
    /// Adds additional fields with searchable versions of the date and time value in the field with the specified <paramref name="key"/>. If successful, the following fields will be added:
    ///
    /// <list type="bullet">
    ///   <item><c>{key}_search</c></item>
    ///   <item><c>{key}_ticks</c></item>
    ///   <item><c>{key}_year</c></item>
    ///   <item><c>{key}_month</c></item>
    ///   <item><c>{key}_day</c></item>
    ///   <item><c>{key}_week</c></item>
    /// </list>
    /// </summary>
    /// <param name="e">The event arguments about the node being indexed.</param>
    /// <param name="key">The key of the field to make searchable.</param>
    public static IndexingItemEventArgs IndexDateTime(this IndexingItemEventArgs e, string key) {
        return e.ValueSet.TryGetDateTime(key, out DateTime dt) ? IndexDateTime(e, key, dt) : e;
    }

    /// <summary>
    /// Adds fields with searchable versions of the date value in the field with the specified <paramref name="key"/>. The following fields will be added:
    ///
    /// <list type="bullet">
    ///   <item><c>{key}_search</c></item>
    ///   <item><c>{key}_ticks</c></item>
    ///   <item><c>{key}_year</c></item>
    ///   <item><c>{key}_month</c></item>
    ///   <item><c>{key}_day</c></item>
    ///   <item><c>{key}_week</c></item>
    /// </list>
    /// </summary>
    /// <param name="e">The event arguments about the node being indexed.</param>
    /// <param name="key">The key of the field.</param>
    /// <param name="dateTime">The date and time value to index.</param>
    /// <returns>The updated event arguments.</returns>
    public static IndexingItemEventArgs IndexDateTime(IndexingItemEventArgs e, string key, DateTime dateTime) {

        // Convert to UTC
        DateTime utc = dateTime.ToUniversalTime();

        // Index as UTC
        e.ValueSet.TryAdd($"{key}_search", utc.ToString(ExamineDateFormats.Sortable));
        e.ValueSet.TryAdd($"{key}_ticks", utc.Ticks.ToString());

        // Index using "current" time zone
        e.ValueSet.TryAdd($"{key}_year", dateTime.Year);
        e.ValueSet.TryAdd($"{key}_month", dateTime.Month);
        e.ValueSet.TryAdd($"{key}_day", dateTime.Day);
        e.ValueSet.TryAdd($"{key}_week", Iso8601Utils.GetWeekNumber(dateTime));

        return e;

    }

    /// <summary>
    /// Parses the UDIs in the field with the specified <paramref name="key"/>, and adds a new field with
    /// searchable versions of the UDIs.
    ///
    /// Specifically the method will look for any GUID based UDI's, and then format the GUIDs to formats <c>N</c>
    /// and <c>D</c> - that is <c>00000000000000000000000000000000</c> and
    /// <c>00000000-0000-0000-0000-000000000000</c>. The type of the reference entity is not added to the new field.
    ///
    /// The key of the new field will use <c>_search</c> as suffix - e.g. if <paramref name="key"/> is
    /// <c>related</c>, the new field will have the key <c>related_search</c>.
    /// </summary>
    /// <param name="e">The event arguments about the node being indexed.</param>
    /// <param name="key">The key of the field to make searchable.</param>
    public static IndexingItemEventArgs IndexUdis(this IndexingItemEventArgs e, string key) {
        return IndexUdis(e, key, $"{key}_search");
    }

    /// <summary>
    /// Parses the UDIs in the field with the specified <paramref name="key"/>, and adds a new field with
    /// searchable versions of the UDIs.
    ///
    /// Specifically the method will look for any GUID based UDI's, and then format the GUIDs to formats <c>N</c>
    /// and <c>D</c> - that is <c>00000000000000000000000000000000</c> and
    /// <c>00000000-0000-0000-0000-000000000000</c>. The type of the reference entity is not added to the new field.
    /// </summary>
    /// <param name="e">The event arguments about the node being indexed.</param>
    /// <param name="key">The key of the field to make searchable.</param>
    /// <param name="newKey">The key of the new field.</param>
    public static IndexingItemEventArgs IndexUdis(this IndexingItemEventArgs e, string key, string newKey) {

        // Attempt to get the values of the specified field
        if (!e.ValueSet.Values.TryGetValue(key, out IReadOnlyList<object>? values)) return e;

        // Get the first value of the field
        string? value = values.FirstOrDefault()?.ToString();
        if (string.IsNullOrWhiteSpace(value)) return e;

        // Parse the UDI's and adds as GUIDs instead (both N and D formats)
        List<string> newValues = [];
        foreach (string piece in StringUtils.ParseStringArray(value)) {
            if (UdiParser.TryParse(piece, out GuidUdi? udi)) {
                newValues.Add(udi!.Guid.ToString("N"));
                newValues.Add(udi.Guid.ToString("D")); // TODO: should we stop indexing D (with hyphens) format?
            } else {
                newValues.Add(piece.Split('/').Last());
            }
        }

        // Added the searchable value to the index
        e.ValueSet.TryAdd(newKey, string.Join(" ", newValues));

        return e;

    }

}