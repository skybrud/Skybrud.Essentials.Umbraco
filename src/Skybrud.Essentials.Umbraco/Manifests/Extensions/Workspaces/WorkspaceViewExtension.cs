using System.Text.Json.Serialization;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Workspaces;

/// <summary>
/// Represents a workspace view extension declared by an Umbraco package manifest.
/// </summary>
public class WorkspaceViewExtension : ConditionalExtension, IElementExtension {

    /// <summary>
    /// Gets the type of the extension.
    /// </summary>
    /// <remarks>
    /// The value is always <c>workspaceView</c>.
    /// </remarks>
    public override string Type => "workspaceView";

    /// <summary>
    /// Gets or sets the location of the JavaScript module that provides the
    /// workspace view element.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Element { get; set; }

    /// <summary>
    /// Gets or sets the optional name of the custom element that provides the
    /// workspace view.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ElementName { get; set; }

    /// <summary>
    /// Gets or sets the location of the JavaScript module associated with the
    /// workspace view.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Js { get; set; }

    /// <summary>
    /// Gets or sets the metadata associated with the workspace view.
    /// </summary>
    [JsonPropertyName("meta")]
    public required WorkspaceViewMeta Meta { get; set; }

}