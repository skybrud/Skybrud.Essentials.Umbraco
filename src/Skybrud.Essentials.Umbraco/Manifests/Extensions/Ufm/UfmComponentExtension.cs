using System.Text.Json.Serialization;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Ufm;

/// <summary>
/// Represents an Umbraco Flavored Markup (UFM) component extension.
/// </summary>
/// <remarks>
/// <para>
/// A UFM component is a formatter that can be used in Umbraco Flavored Markup,
/// such as in property descriptions and advanced labels.
/// </para>
/// <para>
/// See the
/// <see href="https://apidocs.umbraco.com/v17/ui-api/interfaces/packages_ufm.ManifestUfmComponent.html">
/// <c>ManifestUfmComponent</c> TypeScript definition
/// </see>
/// and the
/// <see href="https://docs.umbraco.com/umbraco-cms/17.latest/customizing/extending-overview/extension-types">
/// Umbraco extension type documentation
/// </see>
/// for more information.
/// </para>
/// </remarks>
public class UfmComponentExtension : IExtension {

    /// <summary>
    /// Gets the extension type.
    /// </summary>
    /// <value>
    /// Always <c>"ufmComponent"</c>.
    /// </value>
    public string Type => "ufmComponent";

    /// <summary>
    /// Gets or sets the unique alias of the extension.
    /// </summary>
    /// <remarks>
    /// This alias identifies the extension in the Umbraco extension registry
    /// and is distinct from <see cref="UfmComponentMeta.Alias"/>, which identifies
    /// the component within UFM.
    /// </remarks>
    public required string Alias { get; set; }

    /// <summary>
    /// Gets or sets the human-readable name of the extension.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the path to the JavaScript module for the extension.
    /// </summary>
    /// <remarks>
    /// This property is omitted during serialization when its value is
    /// <see langword="null"/>.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Js { get; set; }

    /// <summary>
    /// Gets or sets the path to the JavaScript module that exports the API
    /// implementation for the extension.
    /// </summary>
    /// <remarks>
    /// This property is omitted during serialization when its value is
    /// <see langword="null"/>.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Api { get; set; }

    /// <summary>
    /// Gets or sets the kind of the extension.
    /// </summary>
    /// <remarks>
    /// The kind can be used to inherit additional configuration from a
    /// registered extension kind. This property is omitted during serialization
    /// when its value is <see langword="null"/>.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Kind { get; set; }

    /// <summary>
    /// Gets or sets the weight used to order the extension relative to other
    /// extensions of the same type.
    /// </summary>
    /// <remarks>
    /// Lower values are ordered before higher values. This property is omitted
    /// during serialization when its value is <see langword="null"/>.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Weight { get; set; }

    /// <summary>
    /// Gets or sets the UFM-specific configuration for the component.
    /// </summary>
    /// <seealso cref="UfmComponentMeta"/>
    public required UfmComponentMeta Meta { get; set; }

}