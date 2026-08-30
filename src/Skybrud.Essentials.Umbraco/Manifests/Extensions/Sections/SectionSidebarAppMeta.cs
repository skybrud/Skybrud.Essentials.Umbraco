using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Sections;

/// <summary>
/// Represents metadata associated with an Umbraco section sidebar app extension.
/// </summary>
public class SectionSidebarAppMeta {

    /// <summary>
    /// Gets or sets the label displayed for the section sidebar app in the
    /// Umbraco backoffice.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }

    /// <summary>
    /// Gets or sets the aliases of the sections in which the sidebar app is available.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Menu { get; set; }

    /// <summary>
    /// Gets or sets additional metadata associated with the section sidebar app.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, object>? Properties { get; set; }

}