namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.EntryPoints;

public class BackofficeEntryPointExtension : IExtension {

    public string Type => "backofficeEntryPoint";

    public required string Alias { get; set; }

    public required string Name { get; set; }

    public required string Js { get; set; }

}