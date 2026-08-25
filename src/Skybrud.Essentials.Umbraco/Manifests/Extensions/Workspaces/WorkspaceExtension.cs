namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Workspaces;

public class WorkspaceExtension : IExtension {

    public string Type => "workspace";

    public string Kind { get; set; } = "default";

    public required string Alias { get; set; }

    public required string Name { get; set; }

    public required WorkspaceExtensionMeta Meta { get; set; }

}