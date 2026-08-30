using System.Text.Json.Serialization;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.PropertyEditors;

/// <summary>
/// Represents metadata associated with an Umbraco property editor schema.
/// </summary>
public class PropertyEditorSchemaMeta {

    /// <summary>
    /// Gets or sets the alias of the property editor UI that should be used by default for this schema.
    /// </summary>
    public required string DefaultPropertyEditorUiAlias { get; set; }

    /// <summary>
    /// Gets or sets the optional settings that define how the property editor schema can be configured.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PropertyEditorSettings? Settings { get; set; }

}