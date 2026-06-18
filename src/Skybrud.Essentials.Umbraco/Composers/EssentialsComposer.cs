using Microsoft.Extensions.DependencyInjection;
using Skybrud.Essentials.Umbraco.Composing;
using Skybrud.Essentials.Umbraco.Manifests;
using Skybrud.Essentials.Umbraco.Media;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

#pragma warning disable CS1591

namespace Skybrud.Essentials.Umbraco.Composers;

public class EssentialsComposer : IComposer {

    public void Compose(IUmbracoBuilder builder) {
        builder.Services.AddSingleton<MediaHelper>();
        builder.AddPackageManifestReader<EssentialsPackageManifestReader>();
    }

}