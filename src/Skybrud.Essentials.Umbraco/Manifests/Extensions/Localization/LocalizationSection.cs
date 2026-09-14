using System.Collections.Generic;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Localization;

/// <summary>
/// Class representing a section of localized values in an Umbraco manifest.
/// </summary>
public class LocalizationSection : Dictionary<string, string> {

    /// <summary>
    /// Initializes a new instance of the <see cref="LocalizationSection"/> class.
    /// </summary>
    public LocalizationSection() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="LocalizationSection"/> class
    /// with the entries from the specified dictionary.
    /// </summary>
    /// <param name="dictionary">The dictionary whose entries are copied to the new localization section.</param>
    public LocalizationSection(IDictionary<string, string> dictionary) : base(dictionary) { }

    /// <summary>
    /// Adds a new key-value pair to the localization section.
    /// </summary>
    /// <param name="key">The key of the localized value.</param>
    /// <param name="value">The localized value.</param>
    /// <returns>The current instance of <see cref="LocalizationSection"/>.</returns>
    public new LocalizationSection Add(string key, string value) {
        this[key] = value;
        return this;
    }

    /// <summary>
    /// Creates and returns a new instance of <see cref="LocalizationSection"/>.
    /// </summary>
    /// <returns>A new instance of <see cref="LocalizationSection"/>.</returns>
    public static LocalizationSection Create() {
        return new LocalizationSection();
    }

    /// <summary>
    /// Creates a new <see cref="LocalizationSection"/> containing the entries
    /// from the specified dictionary.
    /// </summary>
    /// <param name="dictionary">The dictionary whose entries are copied to the new localization section.</param>
    /// <returns>
    /// A new <see cref="LocalizationSection"/> containing the entries from <paramref name="dictionary"/>.
    /// </returns>
    public static LocalizationSection Create(IDictionary<string, string> dictionary) {
        return new LocalizationSection(dictionary);
    }

}