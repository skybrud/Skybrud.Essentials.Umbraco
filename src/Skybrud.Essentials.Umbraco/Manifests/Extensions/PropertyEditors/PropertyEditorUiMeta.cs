using System.Text.Json.Serialization;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.PropertyEditors;

/// <summary>
/// Represents metadata associated with an Umbraco property editor UI.
/// </summary>
public class PropertyEditorUiMeta {

    /// <summary>
    /// Gets or sets the label displayed for the property editor UI in the
    /// Umbraco backoffice.
    /// </summary>
    public required string Label { get; set; }

    /// <summary>
    /// Gets or sets the alias of the property editor schema used by the
    /// property editor UI.
    /// </summary>
    public required string PropertyEditorSchemaAlias { get; set; }

    /// <summary>
    /// Gets or sets the icon displayed for the property editor UI in the Umbraco backoffice.
    /// </summary>
    public required string Icon { get; set; }

    /// <summary>
    /// Gets or sets the group used to categorize the property editor UI in the
    /// Umbraco backoffice.
    /// </summary>
    public required string Group { get; set; }

    /// <summary>
    /// Gets or sets the optional settings that define how the property editor UI can be configured.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PropertyEditorSettings? Settings { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the property editor UI supports read-only mode.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsReadOnly { get; set; }

}