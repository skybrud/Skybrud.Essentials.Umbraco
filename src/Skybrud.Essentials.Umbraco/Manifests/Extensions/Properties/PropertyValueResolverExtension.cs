namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Properties;

/// <summary>
/// Represents an extension for resolving values belonging to a property editor.
/// </summary>
public class PropertyValueResolverExtension : IExtension {

    /// <summary>
    /// Gets the extension type.
    /// </summary>
    public string Type => "propertyValueResolver";

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
    /// Gets or sets the alias of the property editor for which values are resolved.
    /// </summary>
    public required string ForEditorAlias { get; set; }

}