using System.Text.Json.Serialization;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Localization;

/// <summary>
/// Represents a localization extension declared by an Umbraco package manifest.
/// </summary>
public class LocalizationExtension : Extension {

    /// <summary>
    /// Gets the type of the extension.
    /// </summary>
    /// <remarks>
    /// The value is always <c>localization</c>.
    /// </remarks>
    public override string Type => "localization";

    /// <summary>
    /// Gets or sets the location of the JavaScript module that provides the
    /// localization entries.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Js { get; set; }

    /// <summary>
    /// The meta information of the extension.
    /// </summary>
    public required LocalizationMeta Meta { get; set; }

}