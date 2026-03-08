//using System.Collections.Generic;
//using Umbraco.Cms.Core.Manifest;

//namespace Skybrud.Essentials.Umbraco;

///// <inheritdoc />
//public class EssentialsManifestFilter : IManifestFilter {

//    /// <inheritdoc />
//    public void Filter(List<PackageManifest> manifests) {
//        manifests.Add(new PackageManifest {
//            AllowPackageTelemetry = false,
//            PackageId = EssentialsPackage.Alias,
//            PackageName = EssentialsPackage.Name,
//            Version = EssentialsPackage.InformationalVersion,
//            Scripts = [
//                $"/App_Plugins/{EssentialsPackage.AppPlugins}/Scripts/Services/Skybrud.js",
//                $"/App_Plugins/{EssentialsPackage.AppPlugins}/Scripts/Directives/JsonView.js"
//            ],
//            Stylesheets = [
//                $"/App_Plugins/{EssentialsPackage.AppPlugins}/Styles/Styles.css"
//            ]
//        });
//    }

//}