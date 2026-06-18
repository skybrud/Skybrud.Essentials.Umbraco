namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Localization;

public class LocalizationExtension {

    public string Type => "localization";

    public required string Alias { get; set; }

    public required string Name { get; set; }

    public required LocalizationExtensionMeta Meta { get; set; }

}