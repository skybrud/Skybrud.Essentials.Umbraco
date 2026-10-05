using System.Text.Json.Serialization;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Properties;

/// <summary>
/// Represents an extension for cloning values belonging to a property editor.
/// </summary>
public class PropertyValueClonerExtension : Extension, IApiExtension {

    /// <summary>
    /// Gets the extension type.
    /// </summary>
    public override string Type => "propertyValueCloner";

    /// <summary>
    /// Gets or sets the path to the JavaScript module providing the extension API.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Api { get; set; }

    /// <summary>
    /// Gets the path to the JavaScript module to load for the extension.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Js { get; set; }

    /// <summary>
    /// Gets or sets the alias of the property editor for which values can be cloned.
    /// </summary>
    public required string ForEditorAlias { get; set; }

}