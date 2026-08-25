namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Menus;

public class MenuExtension : IExtension {

    public string Type => "menu";

    public required string Alias { get; set; }

    public required string Name { get; set; }

}