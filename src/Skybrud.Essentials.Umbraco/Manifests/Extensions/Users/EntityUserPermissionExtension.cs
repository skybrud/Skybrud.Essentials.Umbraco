using System.Collections.Generic;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Users;

public class EntityUserPermissionExtension : IExtension {

    public string Type => "entityUserPermission";

    public required string Alias { get; set; }

    public required string Name { get; set; }

    public required List<string> ForEntityTypes { get; set; }

    public required EntityUserPermissionMeta Meta { get; set; }

}