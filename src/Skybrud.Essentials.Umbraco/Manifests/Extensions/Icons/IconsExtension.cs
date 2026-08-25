namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Icons;

public class IconsExtension : IExtension {

    public string Type => "icons";

    public required string Alias { get; init; }

    public required string Name { get; init; }

    public required string Js { get; init; }

}