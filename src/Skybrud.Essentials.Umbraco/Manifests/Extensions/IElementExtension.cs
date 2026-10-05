namespace Skybrud.Essentials.Umbraco.Manifests.Extensions;

/// <summary>
/// Represents an Umbraco extension that can provide a custom element.
/// </summary>
public interface IElementExtension {

    /// <summary>
    /// Gets the JavaScript module that exports the custom element.
    /// </summary>
    string? Element { get; }

    /// <summary>
    /// Gets the name of the custom element.
    /// </summary>
    string? ElementName { get; }

    /// <summary>
    /// Gets the JavaScript module to load for the extension.
    /// </summary>
    string? Js { get; }

}