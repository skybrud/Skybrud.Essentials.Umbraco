using System.Diagnostics.CodeAnalysis;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.PropertyEditors;

/// <summary>
/// Represents a default value for an Umbraco property editor setting.
/// </summary>
public class PropertyEditorSettingsDefaultData {

    /// <summary>
    /// Gets or sets the alias of the setting to which the default value applies.
    /// </summary>
    public required string Alias { get; set; }

    /// <summary>
    /// Gets or sets the default value of the setting.
    /// </summary>
    /// <remarks>
    /// The value can contain any JSON value supported by the corresponding property editor setting.
    /// </remarks>
    public object? Value { get; set; }

    /// <summary>
    /// Initializes a new, empty instance. Using this constructor, you must set the <see cref="Alias"/> and <see cref="Value"/> properties before using the instance.
    /// </summary>
    public PropertyEditorSettingsDefaultData() { }

    /// <summary>
    /// Initializes a new instance with the specified <paramref name="alias"/> and <paramref name="value"/>.
    /// </summary>
    /// <param name="alias">The alias of the config property.</param>
    /// <param name="value">The value of the config property.</param>
    [SetsRequiredMembers]
    public PropertyEditorSettingsDefaultData(string alias, object? value) {
        Alias = alias;
        Value = value;
    }

}