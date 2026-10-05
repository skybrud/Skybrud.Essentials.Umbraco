namespace Skybrud.Essentials.Umbraco.Manifests.Extensions;

/// <summary>
/// Represents an extension that provides an API.
/// </summary>
public interface IApiExtension {

    /// <summary>
    /// Gets the path to the JavaScript module that provides the extension API.
    /// </summary>
    string? Api { get; }

    /// <summary>
    /// Gets the path to the JavaScript module to load for the extension.
    /// </summary>
    string? Js { get; }

}