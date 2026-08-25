namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Localization;

public class LocalizationExtension : IExtension {

    public string Type => "localization";

    /// <summary>
    /// The alias of the extension, ensure it is unique.
    /// </summary>
    public required string Alias { get; set; }

    /// <summary>
    /// The friendly name of the extension.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// The file location of the javascript file to load.
    /// </summary>
    public string? Js { get; set; }

    /// <summary>
    /// The meta information of the extension.
    /// </summary>
    public required LocalizationExtensionMeta Meta { get; set; }

    /// <summary>
    /// Extensions such as dashboards are ordered by weight with higher numbers being first in the list.
    /// </summary>
    public int Weight { get; set; } // TODO: should this be nullable?

}