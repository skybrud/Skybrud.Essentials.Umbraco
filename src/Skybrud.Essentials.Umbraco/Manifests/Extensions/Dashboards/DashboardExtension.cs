using System.Collections.Generic;
using Skybrud.Essentials.Umbraco.Manifests.Conditions;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Dashboards;



public class DashboardExtension : IExtension {

    /// <summary>
    /// The type of the extension. Always returns <c>dashboard</c>.
    /// </summary>
    public string Type => "dashboard";

    /// <summary>
    /// The alias of the extension, ensure it is unique.
    /// </summary>
    public required string Alias { get; set; }

    /// <summary>
    /// The friendly name of the extension.
    /// </summary>
    public required string Name { get; set; }

    // element???

    public required string ElementName { get; set; }

    public required string Js { get; set; }

    /// <summary>
    /// Extensions such as dashboards are ordered by weight with higher numbers being first in the list.
    /// </summary>
    public int? Weight { get; set; }

    public required DashboardExtensionMeta Meta { get; set; }

    public List<ICondition> Conditions { get; set; } = [];

    // kind???
    // overwrites???

}