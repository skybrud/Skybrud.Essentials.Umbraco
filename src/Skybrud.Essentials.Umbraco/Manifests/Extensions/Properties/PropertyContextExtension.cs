using System.Collections.Generic;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Properties;

/// <summary>
/// Represents an Umbraco property context extension.
/// </summary>
public class PropertyContextExtension : IExtension {

    /// <summary>
    /// Gets the extension type.
    /// </summary>
    public string Type => "propertyContext";

    /// <summary>
    /// Gets or sets the kind of property context.
    /// </summary>
    public required string Kind { get; set; }

    /// <summary>
    /// Gets or sets the unique alias of the extension.
    /// </summary>
    public required string Alias { get; set; }

    /// <summary>
    /// Gets or sets the friendly name of the extension.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the aliases of the property editor UIs for which the context is available.
    /// </summary>
    public required List<string> ForPropertyEditorUis { get; set; }

}