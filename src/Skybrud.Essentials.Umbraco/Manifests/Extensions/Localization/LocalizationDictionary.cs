using System;
using System.Collections.Generic;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Localization;

/// <summary>
/// Class representing a dictionary of localized values in an Umbraco manifest.
/// </summary>
public class LocalizationDictionary : Dictionary<string, LocalizationSection> {

    /// <summary>
    /// Gets or sets the dictionary of localized values for the specified <paramref name="section"/>. If the section does not exist, it will be created.
    /// </summary>
    /// <param name="section">The section of localized values.</param>
    /// <returns>The dictionary of localized values for the specified section.</returns>
    public new LocalizationSection this[string section] {
        get {
            if (TryGetValue(section, out LocalizationSection? dictionary)) return dictionary;
            dictionary = new LocalizationSection();
            base[section] = dictionary;
            return dictionary;
        }
        set => base[section] = value;
    }

    /// <summary>
    /// Adds a new localized value to the specified <paramref name="section"/> with the given <paramref name="key"/> and <paramref name="value"/>. If the section does not exist, it will be created.
    /// </summary>
    /// <param name="section">The section of localized values.</param>
    /// <param name="key">The key of the localized value.</param>
    /// <param name="value">The localized value.</param>
    /// <returns>The current instance of <see cref="LocalizationDictionary"/>.</returns>
    public LocalizationDictionary Add(string section, string key, string value) {
        this[section][key] = value;
        return this;
    }

    /// <summary>
    /// Adds a new section of localized values to the dictionary. If the section already exists, the values will be merged with the existing ones.
    /// </summary>
    /// <param name="section">The section of localized values.</param>
    /// <param name="values">The localized values to add.</param>
    /// <returns>The current instance of <see cref="LocalizationDictionary"/>.</returns>
    public new LocalizationDictionary Add(string section, LocalizationSection values) {
        if (!ContainsKey(section)) this[section] = new LocalizationSection();
        foreach ((string key, string value) in values) this[section][key] = value;
        return this;
    }

    /// <summary>
    /// Adds a new section of localized values to the dictionary. If the section already exists, the values will be merged with the existing ones.
    /// </summary>
    /// <param name="section">The section of localized values.</param>
    /// <param name="values">The localized values to add.</param>
    /// <returns>The current instance of <see cref="LocalizationDictionary"/>.</returns>
    public LocalizationDictionary Add(string section, Dictionary<string, string> values) {
        if (!ContainsKey(section)) this[section] = new LocalizationSection();
        foreach ((string key, string value) in values) this[section][key] = value;
        return this;
    }

    /// <summary>
    /// Adds a new section of localized values to the dictionary. If the section already exists, the values will be merged with the existing ones.
    /// </summary>
    /// <param name="section">The section of localized values.</param>
    /// <param name="values">The localized values to add.</param>
    /// <returns>The current instance of <see cref="LocalizationDictionary"/>.</returns>
    public LocalizationDictionary Add(string section, params (string key, string value)[] values) {
        foreach ((string key, string value) in values) this[section][key] = value;
        return this;
    }

    /// <summary>
    /// Adds a new section of localized values to the dictionary. If the section already exists, the values will be merged with the existing ones.
    /// </summary>
    /// <param name="section">The section of localized values.</param>
    /// <param name="action">The action to perform on the section of localized values.</param>
    /// <returns>The current instance of <see cref="LocalizationDictionary"/>.</returns>
    public LocalizationDictionary Add(string section, Action<Dictionary<string, string>> action) {
        action(this[section]);
        return this;
    }

    [Obsolete("Use the Add method instead.")]
    public LocalizationDictionary Set(string section, string key, string value) {
        if (!ContainsKey(section)) this[section] = new LocalizationSection();
        this[section][key] = value;
        return this;
    }

    /// <summary>
    /// Creates and returns a new instance of <see cref="LocalizationDictionary"/>.
    /// </summary>
    /// <returns>A new instance of <see cref="LocalizationDictionary"/>.</returns>
    public static LocalizationDictionary Create() {
        return new LocalizationDictionary();
    }

}