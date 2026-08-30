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

}