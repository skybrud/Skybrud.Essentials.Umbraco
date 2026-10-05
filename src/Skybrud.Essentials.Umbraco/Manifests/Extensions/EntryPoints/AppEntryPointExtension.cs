using System.Text.Json.Serialization;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.EntryPoints;

/// <summary>
/// Represents an app entry point extension declared by an Umbraco package manifest.
/// </summary>
public class AppEntryPointExtension : Extension {

    /// <summary>
    /// Gets the type of the extension.
    /// </summary>
    /// <remarks>
    /// The value is always <c>appEntryPoint</c>.
    /// </remarks>
    public override string Type => "appEntryPoint";

    /// <summary>
    /// Gets or sets the location of the JavaScript module to load.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Js { get; set; }

}