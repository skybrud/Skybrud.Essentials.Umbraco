using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.PropertyEditors;

/// <summary>
/// Represents metadata associated with an Umbraco property editor UI.
/// </summary>
/// <remarks>
/// Based on <c>MetaPropertyEditorUi</c> in <c>umbraco-package-schema.json</c>.
/// </remarks>>
public class PropertyEditorUiMeta {

    /// <summary>
    /// Gets or sets the label displayed for the property editor UI in the
    /// Umbraco backoffice.
    /// </summary>
    /// <remarks>
    /// <c>umbraco-package-schema.json</c> specifies that theis property is required.
    /// </remarks>
    public required string Label { get; set; }

    /// <summary>
    /// Gets or sets the group used to categorize the property editor UI in the
    /// Umbraco backoffice.
    /// </summary>
    /// <remarks>
    /// <c>umbraco-package-schema.json</c> specifies that theis property is required, but also
    /// describes <c>Common</c> as a fallback if not specified.
    /// </remarks>
    public string? Group { get; set; }

    /// <summary>
    /// Gets or sets the icon displayed for the property editor UI in the Umbraco backoffice.
    /// </summary>
    /// <remarks>
    /// <c>umbraco-package-schema.json</c> specifies that theis property is required.
    /// </remarks>
    public required string Icon { get; set; }

    /// <summary>
    /// Gets or sets a list of keywords that can be used to search for this property editor UI in
    /// the property editor picker. If not specified, the property editor UI will not have any
    /// keywords.
    /// </summary>
    public List<string>? Keywords { get; set; }

    /// <summary>
    /// Gets or sets the alias of the property editor schema that this property editor UI is for.
    /// If not specified, the property editor UI can only be used to configure other property
    /// editors.
    /// </summary>
    public string? PropertyEditorSchemaAlias { get; set; }

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