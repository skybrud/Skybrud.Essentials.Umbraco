using System.Text.Json.Serialization;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Icons;

/// <summary>
/// Represents an icons extension declared by an Umbraco package manifest.
/// </summary>
public class IconsExtension : Extension {

    /// <summary>
    /// Gets the type of the extension.
    /// </summary>
    /// <remarks>
    /// The value is always <c>icons</c>.
    /// </remarks>
    public override string Type => "icons";

    /// <summary>
    /// Gets or sets the location of the JavaScript module that provides the
    /// icons.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public required string Js { get; set; }

}