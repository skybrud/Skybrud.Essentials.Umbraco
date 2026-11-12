using System.Collections.Generic;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Manifest;
using Umbraco.Cms.Infrastructure.Manifest;

namespace Skybrud.Essentials.Umbraco.Manifests;

public class EssentialsPackageManifestReader : IPackageManifestReader {

    public Task<IEnumerable<PackageManifest>> ReadPackageManifestsAsync() {

        IEnumerable<PackageManifest> manifests = [
            new() {
                Id = EssentialsPackage.Alias,
                Name = EssentialsPackage.Name,
                AllowTelemetry = true,
                Version = EssentialsPackage.InformationalVersion,
                Extensions = []
            }
        ];

        return Task.FromResult(manifests);

    }

}