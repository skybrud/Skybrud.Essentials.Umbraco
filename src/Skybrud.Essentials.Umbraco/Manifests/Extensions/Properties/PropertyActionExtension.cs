using System.Collections.Generic;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Properties;

/// <summary>
/// Represents an Umbraco property action extension.
/// </summary>
public class PropertyActionExtension : ConditionalExtension {

    /// <summary>
    /// Gets the extension type.
    /// </summary>
    public override string Type => "propertyAction";

    /// <summary>
    /// Gets or sets the aliases of the property editor UIs for which the action is available.
    /// </summary>
    public required List<string> ForPropertyEditorUis { get; set; }

}