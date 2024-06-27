using System.Collections.Generic;
using System.Reflection;
using Umbraco.Cms.Core.Manifest;

namespace Skybrud.Essentials.Umbraco;

/// <inheritdoc />
public class EssentialsManifestFilter : IManifestFilter {

    /// <inheritdoc />
    public void Filter(List<PackageManifest> manifests) {

        // Initialize a new manifest filter for this package
        PackageManifest manifest = new() {
            AllowPackageTelemetry = false,
            PackageName = EssentialsPackage.Name,
            Version = EssentialsPackage.InformationalVersion,
            Scripts = [
                $"/App_Plugins/{EssentialsPackage.AppPlugins}/Scripts/Services/Skybrud.js",
                $"/App_Plugins/{EssentialsPackage.AppPlugins}/Scripts/Directives/JsonView.js"
            ],
            Stylesheets = [
                $"/App_Plugins/{EssentialsPackage.AppPlugins}/Styles/Styles.css"
            ]
        };

        // The "PackageId" property isn't available prior to Umbraco 12, and since the package is build against
        // Umbraco 10, we need to use reflection for setting the property value for Umbraco 12+. Ideally this
        // shouldn't fail, but we might at least add a try/catch to be sure
        try {
            PropertyInfo? property = manifest.GetType().GetProperty("PackageId");
            property?.SetValue(manifest, EssentialsPackage.Alias);
        } catch {
            // We don't really care about the exception
        }

        // Append the manifest
        manifests.Add(manifest);

    }

}