using System.Collections.Generic;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions;

public class EntityUserPermissionExtensionMeta {

    public required List<string> Verbs { get; set; }

    public required string Label { get; set; }

    public required string Description { get; set; }

    public required string Group { get; set; }

}