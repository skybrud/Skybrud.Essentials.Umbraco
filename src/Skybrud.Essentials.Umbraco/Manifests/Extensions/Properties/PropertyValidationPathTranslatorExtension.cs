namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Properties;

/// <summary>
/// Represents an extension for translating validation paths for values belonging to a property editor.
/// </summary>
public class PropertyValidationPathTranslatorExtension : IExtension {

    /// <summary>
    /// Gets the extension type.
    /// </summary>
    public string Type => "propertyValidationPathTranslator";

    /// <summary>
    /// Gets or sets the unique alias of the extension.
    /// </summary>
    public required string Alias { get; set; }

    /// <summary>
    /// Gets or sets the friendly name of the extension.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the path to the JavaScript module providing the extension API.
    /// </summary>
    public required string Api { get; set; }

    /// <summary>
    /// Gets or sets the alias of the property editor for which validation paths are translated.
    /// </summary>
    public required string ForEditorAlias { get; set; }

}