namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Menus;

/// <summary>
/// Represents a menu extension declared by an Umbraco package manifest.
/// </summary>
public class MenuExtension : Extension {

    /// <summary>
    /// Gets the type of the extension.
    /// </summary>
    /// <remarks>
    /// The value is always <c>menu</c>.
    /// </remarks>
    public override string Type => "menu";

}