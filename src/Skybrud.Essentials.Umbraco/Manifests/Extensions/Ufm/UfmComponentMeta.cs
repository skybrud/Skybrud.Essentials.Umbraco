using System.Text.Json.Serialization;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Ufm;

/// <summary>
/// Represents the UFM-specific configuration for a
/// <see cref="UfmComponentExtension"/>.
/// </summary>
/// <remarks>
/// See the
/// <see href="https://apidocs.umbraco.com/v17/ui-api/interfaces/packages_ufm.MetaUfmComponent.html">
/// <c>MetaUfmComponent</c> TypeScript definition
/// </see>
/// for the corresponding Umbraco Backoffice API type.
/// </remarks>
public class UfmComponentMeta {

    /// <summary>
    /// Gets or sets the alias used to identify the component within UFM.
    /// </summary>
    /// <remarks>
    /// This alias is distinct from <see cref="UfmComponentExtension.Alias"/>,
    /// which identifies the extension in the Umbraco extension registry.
    /// </remarks>
    public required string Alias { get; set; }

    /// <summary>
    /// Gets or sets the optional marker used as shorthand for the UFM component.
    /// </summary>
    /// <remarks>
    /// This property is omitted during serialization when its value is
    /// <see langword="null"/>.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Marker { get; set; }

}