using System.Collections.Generic;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Manifest;
using Umbraco.Cms.Infrastructure.Manifest;

namespace Skybrud.Essentials.Umbraco.Manifests;

public class EssentialsPackageManifestReader : IPackageManifestReader {

    public async Task<IEnumerable<PackageManifest>> ReadPackageManifestsAsync() {

        List<PackageManifest> temp = [
            new() {

                Id = EssentialsPackage.Alias,
                Name = EssentialsPackage.Name,
                AllowTelemetry = true,
                Version = EssentialsPackage.InformationalVersion,
                Extensions = []
            }

        ];

        return await Task.FromResult(temp);

    }

}