using System.Collections.Generic;
using System.Text.Json.Serialization;
using Skybrud.Essentials.Umbraco.Manifests.Conditions;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Dashboards;

/// <summary>
/// Represents an Umbraco dashboard extension.
/// </summary>
public class DashboardExtension : IExtension {

    /// <summary>
    /// Gets the extension type for the dashboard.
    /// </summary>
    /// <remarks>
    /// The value is always <c>dashboard</c>.
    /// </remarks>
    public string Type => "dashboard";

    /// <summary>
    /// Gets or sets the unique alias of the dashboard.
    /// </summary>
    public required string Alias { get; set; }

    /// <summary>
    /// Gets or sets the human-readable name of the dashboard.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the location of the JavaScript module that provides the
    /// dashboard element.
    /// </summary>
    public required string Element { get; set; }

    /// <summary>
    /// Gets or sets the optional name of the custom element that provides the dashboard.
    /// </summary>
    /// <remarks>
    /// This can be used when the JavaScript module does not provide the dashboard element as its default export.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ElementName { get; set; }

    /// <summary>
    /// Gets or sets the weight used to determine the ordering of the dashboard.
    /// </summary>
    /// <remarks>
    /// Dashboards with a higher weight are displayed before dashboards with a lower weight.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Weight { get; set; }

    /// <summary>
    /// Gets or sets the metadata associated with the dashboard.
    /// </summary>
    public required DashboardMeta Meta { get; set; }

    /// <summary>
    /// Gets or sets the optional conditions that determine when the dashboard is available.
    /// </summary>
    public List<ICondition> Conditions { get; set; } = [];

}