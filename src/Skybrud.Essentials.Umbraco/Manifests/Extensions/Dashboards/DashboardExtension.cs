using System.Collections.Generic;
using Skybrud.Essentials.Umbraco.Manifests.Conditions;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Dashboards;

public class DashboardExtension {

    public string Type => "dashboard";

    public required string Alias { get; set; }

    public required string Name { get; set; }

    public required string ElementName { get; set; }

    public required string Js { get; set; }

    public int Weight { get; set; }

    public required DashboardExtensionMeta Meta { get; set; }

    public List<Condition> Conditions { get; set; } = [];

}