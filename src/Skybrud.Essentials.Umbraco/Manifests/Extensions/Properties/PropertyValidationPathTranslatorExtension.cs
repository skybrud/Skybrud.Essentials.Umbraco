using System.Text.Json.Serialization;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Properties;

/// <summary>
/// Represents an extension for translating validation paths for values belonging to a property editor.
/// </summary>
public class PropertyValidationPathTranslatorExtension : Extension, IApiExtension {

    /// <summary>
    /// Gets the extension type.
    /// </summary>
    public override string Type => "propertyValidationPathTranslator";

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
    /// Gets or sets the alias of the property editor for which validation paths are translated.
    /// </summary>
    public required string ForEditorAlias { get; set; }

}