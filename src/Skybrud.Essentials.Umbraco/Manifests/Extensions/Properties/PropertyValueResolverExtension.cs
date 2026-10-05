namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Properties;

/// <summary>
/// Represents an extension for resolving values belonging to a property editor.
/// </summary>
public class PropertyValueResolverExtension : Extension, IExtension {

    /// <summary>
    /// Gets the extension type.
    /// </summary>
    public override string Type => "propertyValueResolver";

    /// <summary>
    /// Gets or sets the path to the JavaScript module providing the extension API.
    /// </summary>
    public required string Api { get; set; }

    /// <summary>
    /// Gets or sets the alias of the property editor for which values are resolved.
    /// </summary>
    public required string ForEditorAlias { get; set; }

}