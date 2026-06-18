namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.EntryPoints;

public class BackofficeEntryPointExtension {

    public string Type => "backofficeEntryPoint";

    public required string Alias { get; set; }

    public required string Name { get; set; }

    public required string Js { get; set; }

}