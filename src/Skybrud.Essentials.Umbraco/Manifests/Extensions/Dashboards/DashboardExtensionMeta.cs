using System.Text.Json.Serialization;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Dashboards;

/// <summary>
/// Class representing the meta of a <see cref="DashboardExtension"/>.
/// </summary>
public class DashboardExtensionMeta {

    /// <summary>
    /// The displayed name (label) in the navigation.
    /// </summary>
    public required string Label { get; set; }

    /// <summary>
    /// This is the URL path part for this view. This is used for navigating or deep linking directly to the dashboard.
    /// </summary>
    [JsonPropertyName("pathname")]
    public required string PathName { get; set; }

}