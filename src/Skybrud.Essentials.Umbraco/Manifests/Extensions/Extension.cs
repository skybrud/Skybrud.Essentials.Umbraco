namespace Skybrud.Essentials.Umbraco.Manifests.Extensions;

/// <summary>
/// Represents the base configuration of an Umbraco extension manifest.
/// </summary>
public abstract class Extension : IExtension {

    /// <summary>
    /// Gets the extension type.
    /// </summary>
    public abstract string Type { get; }

    /// <summary>
    /// Gets the unique alias of the extension.
    /// </summary>
    public required string Alias { get; init; }

    /// <summary>
    /// Gets the friendly name of the extension.
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Gets the kind of the extension.
    /// </summary>
    /// <remarks>
    /// The kind identifies a predefined configuration or specialization of the extension type.
    /// </remarks>
    public string? Kind { get; init; }

    /// <summary>
    /// Gets the weight used when ordering the extension relative to other extensions.
    /// </summary>
    public int? Weight { get; init; }

}