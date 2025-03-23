using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skybrud.Essentials.Security.Extensions;
using Umbraco.Cms.Core.Manifest;
using Umbraco.Cms.Infrastructure.Manifest;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Skybrud.Essentials.Umbraco.Manifests;

public class EssentialsPackageManifestReader : IPackageManifestReader {

    public async Task<IEnumerable<PackageManifest>> ReadPackageManifestsAsync() {

        string cacheBuster = EssentialsPackage.InformationalVersion.ToMd5Hash();

        List<PackageManifest> temp = [
            new PackageManifest {
                Name = EssentialsPackage.Name,
                AllowTelemetry = true,
                Version = EssentialsPackage.InformationalVersion,
                Extensions = [
                    new {
                        name = "skybrud.essentials.entrypoint",
                        alias = "Skybrud.Essentials.EntryPoint",
                        type = "backofficeEntryPoint",
                        js = "/App_Plugins/Skybrud.Essentials/EntryPoint.js?v=" + cacheBuster
                    }
                ],
                Importmap = new PackageManifestImportmap {
                    Imports = new Dictionary<string, string> {
                        //{"@skybrud-essentials/service", $"/App_Plugins/${EssentialsPackage.AppPlugins}/Scripts/Services/Skybrud.js?v={cacheBuster}"},
                        {"@skybrud-essentials/elements/duration", $"/App_Plugins/${EssentialsPackage.AppPlugins}/Elements/Duration.js?v={cacheBuster}"},
                        {"@skybrud-essentials/elements/from-now", $"/App_Plugins/${EssentialsPackage.AppPlugins}/Elements/FromNow.js?v={cacheBuster}"},
                        {"@skybrud-essentials/elements/json", $"/App_Plugins/${EssentialsPackage.AppPlugins}/Elements/Json.js?v={cacheBuster}"}
                    }
                }
            }

        ];

        return await Task.FromResult(temp);
    }

}