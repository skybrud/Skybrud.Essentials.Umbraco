using System.Collections.Generic;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Workspaces;

public class WorkspaceViewExtension {

    public string Type => "workspaceView";

    public required string Alias { get; set; }

    public required string Name { get; set; }

    public string? Element { get; set; }

    public string? ElementName { get; set; }

    public string? Js { get; set; }

    public int? Weight { get; set; }

    public required WorkspaceViewExtensionMeta Meta { get; set; }

    public List<object> Conditions { get; set; } = [];

}