using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Infrastructure.Manifest;

#pragma warning disable CS1591

namespace Skybrud.Essentials.Umbraco.Composing;

public static class UmbracoComposingExtensions {

    public static IUmbracoBuilder AddPackageManifestReader<TManifest>(this IUmbracoBuilder builder) where TManifest : class, IPackageManifestReader {
        builder.Services.AddSingleton<IPackageManifestReader, TManifest>();
        return builder;
    }

}