using System.Collections.Generic;
using Skybrud.Essentials.Umbraco.Manifests.Conditions;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Properties;

/// <summary>
/// Represents an Umbraco property action extension.
/// </summary>
public class PropertyActionExtension : IExtension {


    /// <summary>
    /// Gets the extension type.
    /// </summary>
    public string Type => "propertyAction";

    /// <summary>
    /// Gets or sets the kind of property action.
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
    /// Gets or sets the aliases of the property editor UIs for which the action is available.
    /// </summary>
    public required List<string> ForPropertyEditorUis { get; set; }

    /// <summary>
    /// Gets or sets the conditions that determine when the action is available.
    /// </summary>
    public List<ICondition> Conditions { get; set; } = [];

}