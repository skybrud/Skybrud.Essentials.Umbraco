using System.Text.Json.Serialization;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Modals;

/// <summary>
/// Represents a modal extension declared by an Umbraco package manifest.
/// </summary>
public class ModalExtension : IExtension {

    /// <summary>
    /// Gets the type of the extension.
    /// </summary>
    /// <remarks>
    /// The value is always <c>modal</c>.
    /// </remarks>
    public string Type => "modal";

    /// <summary>
    /// Gets or sets the unique alias of the extension.
    /// </summary>
    public required string Alias { get; set; }

    /// <summary>
    /// Gets or sets the human-readable name of the extension.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the location of the JavaScript module that provides the
    /// modal element.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Element { get; set; }

    /// <summary>
    /// Gets or sets the optional name of the custom element that provides the
    /// modal.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ElementName { get; set; }

    /// <summary>
    /// Gets or sets the location of the JavaScript module associated with the modal.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Js { get; set; }

    /// <summary>
    /// Gets or sets the optional kind of the modal extension.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Kind { get; set; }

    /// <summary>
    /// Gets or sets the weight used to determine the priority of the extension.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Weight { get; set; }

    /// <summary>
    /// Gets or sets the metadata associated with the modal extension.
    /// </summary>
    /// <remarks>
    /// The structure of the metadata depends on the modal implementation.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ModalMeta? Meta { get; set; }

}