namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.PropertyEditors;

/// <summary>
/// Represents an Umbraco property editor schema extension.
/// </summary>
public class PropertyEditorSchemaExtension : Extension {

    /// <summary>
    /// Gets the extension type for the property editor schema.
    /// </summary>
    /// <remarks>
    /// The value is always <c>propertyEditorSchema</c>.
    /// </remarks>
    public override string Type => "propertyEditorSchema";

    /// <summary>
    /// Gets or sets the metadata associated with the property editor schema.
    /// </summary>
    public required PropertyEditorSchemaMeta Meta { get; set; }

}