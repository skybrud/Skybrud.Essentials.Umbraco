namespace Skybrud.Essentials.Umbraco.Manifests.Extensions;

/// <summary>
/// Represents an extension declared by an Umbraco package manifest.
/// </summary>
public interface IExtension {

    /// <summary>
    /// Gets the type of the extension.
    /// </summary>
    string Type { get; }

    /// <summary>
    /// Gets the unique alias of the extension.
    /// </summary>
    string Alias { get; }

    /// <summary>
    /// Gets the human-readable name of the extension.
    /// </summary>
    string Name { get; }

}