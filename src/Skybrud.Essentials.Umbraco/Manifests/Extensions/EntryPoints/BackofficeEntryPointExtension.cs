namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.EntryPoints;

/// <summary>
/// Represents a backoffice entry point extension declared by an Umbraco package manifest.
/// </summary>
public class BackofficeEntryPointExtension : Extension, IPlainJsExtension {

    /// <summary>
    /// Gets the type of the extension.
    /// </summary>
    /// <remarks>
    /// The value is always <c>backofficeEntryPoint</c>.
    /// </remarks>
    public override string Type => "backofficeEntryPoint";

    /// <summary>
    /// Gets or sets the location of the JavaScript module that is loaded when the
    /// Umbraco backoffice starts.
    /// </summary>
    public required string Js { get; set; }

}