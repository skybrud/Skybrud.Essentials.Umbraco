namespace Skybrud.Essentials.Umbraco.Manifests.Extensions;

/// <summary>
/// Represents an Umbraco extension that is implemented by a JavaScript module.
/// </summary>
public interface IPlainJsExtension {

    /// <summary>
    /// Gets the path to the JavaScript module to load for the extension.
    /// </summary>
    string Js { get; }

}