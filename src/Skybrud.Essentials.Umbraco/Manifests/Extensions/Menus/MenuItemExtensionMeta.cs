using System.Collections.Generic;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Menus;

public class MenuItemExtensionMeta {

    public required string Label { get; set; }

    public required string Icon { get; set; }

    public required string EntityType { get; set; }

    public required List<string> Menus { get; set; }

}