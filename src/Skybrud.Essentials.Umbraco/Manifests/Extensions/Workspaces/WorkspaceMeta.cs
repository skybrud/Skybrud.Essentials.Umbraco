namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Workspaces;

/// <summary>
/// Represents metadata associated with an Umbraco workspace extension.
/// </summary>
public class WorkspaceMeta {

    /// <summary>
    /// Gets or sets the entity type handled by the workspace.
    /// </summary>
    public required string EntityType { get; set; }

}