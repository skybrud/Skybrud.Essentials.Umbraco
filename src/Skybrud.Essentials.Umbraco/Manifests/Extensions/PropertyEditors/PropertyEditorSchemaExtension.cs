using Umbraco.Cms.Core.PropertyEditors;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.PropertyEditors;

/// <summary>
/// Represents an Umbraco property editor schema extension.
/// </summary>
public class PropertyEditorSchemaExtension : IExtension {

    /// <summary>
    /// Gets the extension type for the property editor schema.
    /// </summary>
    /// <remarks>
    /// The value is always <c>propertyEditorSchema</c>.
    /// </remarks>
    public string Type => "propertyEditorSchema";

    /// <summary>
    /// Gets or sets the unique schema alias; must match the C# <see cref="DataEditor"/> alias
    /// </summary>
    public required string Alias { get; set; }

    /// <summary>
    /// Gets or sets the human-readable schema name.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the weight used to determine the ordering of the property editor schema.
    /// </summary>
    public int? Weight { get; set; }

    /// <summary>
    /// Gets or sets the optional kind used to identify a specialized variant of the property editor schema.
    /// </summary>
    public string? Kind { get; set; }

    /// <summary>
    /// Gets or sets the metadata associated with the property editor schema.
    /// </summary>
    public required PropertyEditorSchemaMeta Meta { get; set; }

}