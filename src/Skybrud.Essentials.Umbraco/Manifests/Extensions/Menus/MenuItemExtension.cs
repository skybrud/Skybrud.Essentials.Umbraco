using System.Collections.Generic;
using Skybrud.Essentials.Umbraco.Manifests.Conditions;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Menus;

public class MenuItemExtension : IExtension {

    public string Type => "menuItem";

    public required string Alias { get; set; }

    public required string Name { get; set; }

    public int? Weight { get; set; }

    public required MenuItemExtensionMeta Meta { get; set; }

    public List<ICondition> Conditions { get; set; } = [];

}