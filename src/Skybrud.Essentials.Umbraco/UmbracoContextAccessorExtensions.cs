using System;
using Umbraco.Cms.Core.Web;

namespace Skybrud.Essentials.Umbraco;

/// <summary>
/// Static class with various extension methods for <see cref="IUmbracoContextAccessor"/>.
/// </summary>
[Obsolete("Use the 'Skybrud.Essentials.Umbraco.Context.UmbracoContextExtensions' class instead.")]
public static class UmbracoContextAccessorExtensions {

    /// <summary>
    /// Returns the current <see cref="IUmbracoContext"/> if successful, or <see langword="null"/> if an Umbraco context is not available.
    /// </summary>
    /// <param name="umbracoContextAccessor">A reference to the current <see cref="IUmbracoContextAccessor"/>.</param>
    /// <returns>An instance of <see cref="IUmbracoContext"/> if successful; otherwise, <see langword="null"/>.</returns>
    [Obsolete("Use the 'Skybrud.Essentials.Umbraco.Context.UmbracoContextExtensions.GetUmbracoContext' method instead.")]
    public static IUmbracoContext? GetUmbracoContext(this IUmbracoContextAccessor umbracoContextAccessor) {
        return Context.UmbracoContextAccessorExtensions.GetUmbracoContext(umbracoContextAccessor);
    }

}