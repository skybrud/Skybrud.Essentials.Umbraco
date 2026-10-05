using System.Text.Json.Serialization;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.PropertyEditors;

/// <summary>
/// Represents an Umbraco property editor UI extension.
/// </summary>
public class PropertyEditorUiExtension : Extension, IElementExtension {

    /// <summary>
    /// Gets the extension type for the property editor UI.
    /// </summary>
    /// <remarks>
    /// The value is typically <c>propertyEditorUi</c>.
    /// </remarks>
    public override string Type => "propertyEditorUi";

    /// <summary>
    /// Gets or sets the location of the JavaScript module that provides the
    /// property editor UI element.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Element { get; set; }

    /// <summary>
    /// Gets or sets the HTML custom element name used for the property editor UI.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ElementName { get; set; }

    /// <summary>
    /// Gets or sets the location of the JavaScript module associated with the property editor UI.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Js { get; set; }

    /// <summary>
    /// Gets or sets the metadata associated with the property editor UI.
    /// </summary>
    public required PropertyEditorUiMeta Meta { get; set; }

}