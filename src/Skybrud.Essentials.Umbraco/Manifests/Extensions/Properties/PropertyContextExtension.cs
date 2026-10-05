using System.Collections.Generic;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Properties;

/// <summary>
/// Represents an Umbraco property context extension.
/// </summary>
public class PropertyContextExtension : ConditionalExtension {

    /// <summary>
    /// Gets the extension type.
    /// </summary>
    public override string Type => "propertyContext";

    /// <summary>
    /// Gets or sets the aliases of the property editor UIs for which the context is available.
    /// </summary>
    public required List<string> ForPropertyEditorUis { get; set; }

}