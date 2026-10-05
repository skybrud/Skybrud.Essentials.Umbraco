using System.Collections.Generic;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Users;

public class EntityUserPermissionExtension : Extension {

    public override string Type => "entityUserPermission";

    public required List<string> ForEntityTypes { get; set; }

    public required EntityUserPermissionMeta Meta { get; set; }

}