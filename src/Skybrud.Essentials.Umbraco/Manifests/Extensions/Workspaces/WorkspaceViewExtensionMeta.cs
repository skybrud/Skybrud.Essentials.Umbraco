using System.Text.Json.Serialization;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Workspaces;

public class WorkspaceViewExtensionMeta {

    public required string Label { get; set; }

    [JsonPropertyName("pathname")]
    public required string PathName { get; set; }

    public required string Icon { get; set; }

}