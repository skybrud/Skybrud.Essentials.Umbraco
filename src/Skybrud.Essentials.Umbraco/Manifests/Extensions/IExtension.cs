namespace Skybrud.Essentials.Umbraco.Manifests.Extensions;

public interface IExtension {

    string Type { get; }

    string Alias { get; }

    string Name { get; }

}