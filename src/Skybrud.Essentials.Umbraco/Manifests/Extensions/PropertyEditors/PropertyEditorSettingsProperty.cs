using System.Text.Json.Serialization;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.PropertyEditors;

/// <summary>
/// Represents a configurable property exposed by an Umbraco property editor schema.
/// </summary>
public class PropertyEditorSettingsProperty {

    /// <summary>
    /// Gets or sets the unique alias of the setting.
    /// </summary>
    public required string Alias { get; set; }

    /// <summary>
    /// Gets or sets the label displayed for the setting in the Umbraco backoffice.
    /// </summary>
    public required string Label { get; set; }

    /// <summary>
    /// Gets or sets an optional description explaining the purpose of the setting.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the alias of the property editor UI used to edit the setting.
    /// </summary>
    public required string PropertyEditorUiAlias { get; set; }

    /// <summary>
    /// Gets or sets optional configuration supplied to the property editor UI.
    /// </summary>
    /// <remarks>
    /// The value can contain arbitrary JSON specific to the selected property editor UI.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Config { get; set; }

    /// <summary>
    /// Gets or sets the weight used to determine the ordering of the setting.
    /// </summary>
    /// <remarks>
    /// Higher values are given greater priority when ordering settings.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Weight { get; set; }

}