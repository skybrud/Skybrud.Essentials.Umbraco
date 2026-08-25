using System.Collections.Generic;
using Skybrud.Essentials.Umbraco.Manifests.Conditions;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Workspaces;

public class WorkspaceViewExtension : IExtension {

    public string Type => "workspaceView";

    public string? Kind { get; set; }

    public required string Alias { get; set; }

    public required string Name { get; set; }

    public string? Element { get; set; }

    public string? ElementName { get; set; }

    public string? Js { get; set; }

    public int? Weight { get; set; }

    public required WorkspaceViewExtensionMeta Meta { get; set; }

    public List<ICondition> Conditions { get; set; } = [];

}