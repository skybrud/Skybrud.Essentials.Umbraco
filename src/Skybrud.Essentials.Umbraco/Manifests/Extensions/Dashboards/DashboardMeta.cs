using System.Text.Json.Serialization;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Dashboards;

/// <summary>
/// Represents metadata associated with an Umbraco dashboard.
/// </summary>
public class DashboardMeta {

    /// <summary>
    /// Gets or sets the label displayed for the dashboard in the Umbraco
    /// backoffice.
    /// </summary>
    public required string Label { get; set; }

    /// <summary>
    /// Gets or sets the routable URL pathname of the dashboard.
    /// </summary>
    [JsonPropertyName("pathname")]
    public required string Pathname { get; set; }

}