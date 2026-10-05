using System.Text.Json.Serialization;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Sections;

/// <summary>
/// Represents a section sidebar app extension declared by an Umbraco package manifest.
/// </summary>
public class SectionSidebarAppExtension : ConditionalExtension, IElementExtension {

    /// <summary>
    /// Gets the type of the extension.
    /// </summary>
    /// <remarks>
    /// The value is always <c>sectionSidebarApp</c>.
    /// </remarks>
    public override string Type => "sectionSidebarApp";

    /// <summary>
    /// Gets or sets the location of the JavaScript module that provides the
    /// section sidebar app element.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Element { get; set; }

    /// <summary>
    /// Gets or sets the optional name of the custom element that provides the
    /// section sidebar app.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ElementName { get; set; }

    /// <summary>
    /// Gets or sets the location of the JavaScript module associated with the
    /// section sidebar app.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Js { get; set; }

    /// <summary>
    /// Gets or sets the metadata associated with the section sidebar app.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SectionSidebarAppMeta? Meta { get; set; }

}