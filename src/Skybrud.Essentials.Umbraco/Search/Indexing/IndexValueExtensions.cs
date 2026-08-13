using System;
using System.Collections.Generic;
using System.Globalization;
using Skybrud.Essentials.Time;
using Skybrud.Essentials.Umbraco.Examine;
using Umbraco.Cms.Core.PropertyEditors;

namespace Skybrud.Essentials.Umbraco.Search.Indexing;

/// <summary>
/// Static class with extension methods for working with <see cref="IndexValue"/> objects.
/// </summary>
public static class IndexValueExtensions {

    /// <summary>
    /// Provides extension methods for adding typed field values to a list of <see cref="IndexValue"/> entries.
    /// </summary>
    /// <param name="list">The target list that receives created <see cref="IndexValue"/> items.</param>
    extension(List<IndexValue> list) {

        /// <summary>
        /// Adds a new 32-bit integer value to the list of <see cref="IndexValue"/> entries.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="value">The 32-bit integer value to add.</param>
        /// <param name="culture">The culture identifier associated with the value, or <see langword="null"/> for culture-neutral values.</param>
        public void Add(string fieldName, int value, string? culture = null) {
            list.Add(new IndexValue { FieldName = fieldName, Values = [value], Culture = culture });
        }

        /// <summary>
        /// Adds a new 64-bit integer value to the list of <see cref="IndexValue"/> entries.
        /// </summary>
        /// <param name="fieldName">The name of the field to associate with the value.</param>
        /// <param name="value">The long value to add.</param>
        /// <param name="culture">The culture identifier associated with the value, or <see langword="null"/> for culture-neutral values.</param>
        public void Add(string fieldName, long value, string? culture = null) {
            list.Add(new IndexValue { FieldName = fieldName, Values = [value], Culture = culture });
        }

        /// <summary>
        /// Adds a new string value to the list of <see cref="IndexValue"/> entries.
        /// </summary>
        /// <param name="fieldName">The name of the field to associate with the value.</param>
        /// <param name="value">The string value to add.</param>
        /// <param name="culture">The culture identifier associated with the value, or <see langword="null"/> for culture-neutral values.</param>
        public void Add(string fieldName, string value, string? culture = null) {
            list.Add(new IndexValue { FieldName = fieldName, Values = [value], Culture = culture });
        }

        /// <summary>
        /// Adds a date and time value to the list of <see cref="IndexValue"/> entries using an invariant, sortable timestamp format.
        /// </summary>
        /// <param name="fieldName">Name of the field to associate with the value.</param>
        /// <param name="value">Date and time value to add.</param>
        /// <param name="culture">The culture identifier associated with the value, or <see langword="null"/> for culture-neutral values.</param>
        public void Add(string fieldName, DateTimeOffset value, string? culture = null) {
            list.Add(new IndexValue { FieldName = fieldName, Values = [value.ToString(ExamineDateFormats.Sortable, CultureInfo.InvariantCulture)], Culture = culture });
        }

        /// <summary>
        /// Adds a date and time value to the list of <see cref="IndexValue"/> entries using an invariant, sortable timestamp format.
        /// </summary>
        /// <param name="fieldName">Name of the field to associate with the value.</param>
        /// <param name="value">Date and time value to add.</param>
        /// <param name="culture">The culture identifier associated with the value, or <see langword="null"/> for culture-neutral values.</param>
        public void Add(string fieldName, EssentialsTime value, string? culture = null) {
            list.Add(new IndexValue { FieldName = fieldName, Values = [value.DateTimeOffset.ToString(ExamineDateFormats.Sortable, CultureInfo.InvariantCulture)], Culture = culture });
        }

        /// <summary>
        /// Adds a field entry with one or more values to the list of <see cref="IndexValue"/> entries.
        /// </summary>
        /// <param name="fieldName">Name of the field to add.</param>
        /// <param name="values">Values associated with the field.</param>
        /// <param name="culture">The culture identifier associated with the value, or <see langword="null"/> for culture-neutral values.</param>
        public void Add(string fieldName, IEnumerable<object?> values, string? culture = null) {
            list.Add(new IndexValue { FieldName = fieldName, Values = values, Culture = culture });
        }

    }

}