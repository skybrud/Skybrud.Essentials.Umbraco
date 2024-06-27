using System.Collections.Generic;
using Umbraco.Cms.Core.Manifest;

namespace Skybrud.Essentials.Umbraco;

/// <inheritdoc />
public class EssentialsManifestFilter : IManifestFilter {

    /// <inheritdoc />
    public void Filter(List<PackageManifest> manifests) {
        const string dir = "Skybrud.Essentials";
        manifests.Add(new PackageManifest {
            AllowPackageTelemetry = false,
            PackageId = EssentialsPackage.Alias,
            PackageName = EssentialsPackage.Name,
            Version = EssentialsPackage.InformationalVersion,
            Scripts = [
                $"/App_Plugins/{dir}/Scripts/Services/Skybrud.js"
            ]
        });
    }

}