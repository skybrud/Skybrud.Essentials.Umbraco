using System.Text.Json.Serialization;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Workspaces;

/// <summary>
/// Represents metadata associated with an Umbraco workspace view extension.
/// </summary>
public class WorkspaceViewMeta {

    /// <summary>
    /// Gets or sets the label displayed for the workspace view in the Umbraco
    /// backoffice.
    /// </summary>
    public required string Label { get; set; }

    /// <summary>
    /// Gets or sets the routable pathname of the workspace view.
    /// </summary>
    [JsonPropertyName("pathname")]
    public required string PathName { get; set; }

    /// <summary>
    /// Gets or sets the optional icon displayed for the workspace view.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Icon { get; set; }

}