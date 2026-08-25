using System.Collections.Generic;
using Skybrud.Essentials.Umbraco.Manifests.Conditions;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Sections;

public class SectionSidebarAppExtension : IExtension {

    public string Type => "sectionSidebarApp";

    public string Kind { get; set; } = "menu";

    public required string Alias { get; set; }

    public required string Name { get; set; }

    public required SectionSidebarAppExtensionMeta Meta { get; set; }

    public List<ICondition> Conditions { get; set; } = [];

}