using System.Text.Json.Serialization;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Dashboards;

/// <summary>
/// Represents an Umbraco dashboard extension.
/// </summary>
public class DashboardExtension : ConditionalExtension, IElementExtension {

    /// <summary>
    /// Gets the extension type for the dashboard.
    /// </summary>
    /// <remarks>
    /// The value is always <c>dashboard</c>.
    /// </remarks>
    public override string Type => "dashboard";

    /// <summary>
    /// Gets or sets the location of the JavaScript module that provides the
    /// dashboard element.
    /// </summary>
    public string? Element { get; set; }

    /// <summary>
    /// Gets or sets the optional name of the custom element that provides the dashboard.
    /// </summary>
    /// <remarks>
    /// This can be used when the JavaScript module does not provide the dashboard element as its default export.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ElementName { get; set; }

    /// <summary>
    /// Gets the path to the JavaScript module to load for the extension.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Js { get; set; }

    /// <summary>
    /// Gets or sets the metadata associated with the dashboard.
    /// </summary>
    public required DashboardMeta Meta { get; set; }

}