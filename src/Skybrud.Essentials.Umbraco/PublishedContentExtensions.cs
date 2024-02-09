using System;
using System.Globalization;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Web;
using Umbraco.Extensions;

namespace Skybrud.Essentials.Umbraco;

/// <summary>
/// Static class with various extension methods for working with <see cref="IPublishedContent"/>.
/// </summary>
public static class PublishedContentExtensions {

    /// <summary>
    /// Gets the <see cref="CultureInfo"/> of the specified <paramref name="content"/> item.
    /// </summary>
    /// <param name="content">The content item to get the culture item for.</param>
    /// <param name="uri">The URI of the request.</param>
    /// <returns>An instance of <see cref="CultureInfo"/>.</returns>
    /// <see>
    ///     <cref>https://docs.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.getcultureinfo</cref>
    /// </see>
    /// <remarks>
    /// <para>This extension method works by looking up the node tree until the culture is found. The
    /// <c>PublishedContentExtensions.GetCultureFromDomains</c> method in Umbraco only returns the name of
    /// the culture, which we can then look up using the static <see cref="CultureInfo.GetCultureInfo(string)"/>
    /// method. Using the static method ensures that we get a cached instance of <see cref="CultureInfo"/>, whereas
    /// using the <see cref="CultureInfo(string)"/> constructor instead would result in a new instance each time
    /// this method is called.</para>
    /// <para>Calling <c>PublishedContentExtensions.GetCultureFromDomains</c> on a content item that hasn't
    /// yet been published doesn't work properly, as the methods returns <c>null</c> instead of the actual culture
    /// node. This appears to be an issue with Umbraco as the internal logic fails to look up the route of the
    /// content item.
    ///
    /// While it ought to be fixed in Umbraco, this method has been updated to traverse up the tree until a culture
    /// has been found or the top of the tree has been reached. If none of the content items along the path specify
    /// a culture, the default culture configured in Umbraco (typically <c>en-US</c>) will be used as fallback.</para>
    /// </remarks>
    public static CultureInfo? GetCultureInfo(this IPublishedContent? content, Uri? uri = null) {

        // If no content item is specified, we return the default culture
        if (content == null) return null;

        // Get culture code via Umbraco's extension method
        string? code = content.GetCultureFromDomains(uri);

        // If no culture code was found, try the parent node - otherwise return the matching CultureInfo
        return string.IsNullOrWhiteSpace(code) ? GetCultureInfo(content.Parent, uri) : CultureInfo.GetCultureInfo(code);

    }

    /// <summary>
    /// Gets the <see cref="CultureInfo"/> of the specified <paramref name="content"/> item.
    /// </summary>
    /// <param name="content">The content item to get the culture item for.</param>
    /// <param name="umbracoContextAccessor"></param>
    /// <param name="siteDomainMapper"></param>
    /// <param name="uri">The URI of the request.</param>
    /// <returns>An instance of <see cref="CultureInfo"/>.</returns>
    /// <see>
    ///     <cref>https://docs.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.getcultureinfo</cref>
    /// </see>
    /// <remarks>
    /// <para>This extension method works by looking up the node tree until the culture is found. The
    /// <c>PublishedContentExtensions.GetCultureFromDomains</c> method in Umbraco only returns the name of
    /// the culture, which we can then look up using the static <see cref="CultureInfo.GetCultureInfo(string)"/>
    /// method. Using the static method ensures that we get a cached instance of <see cref="CultureInfo"/>, whereas
    /// using the <see cref="CultureInfo(string)"/> constructor instead would result in a new instance each time
    /// this method is called.</para>
    /// <para>Calling <c>PublishedContentExtensions.GetCultureFromDomains</c> on a content item that hasn't
    /// yet been published doesn't work properly, as the methods returns <c>null</c> instead of the actual culture
    /// node. This appears to be an issue with Umbraco as the internal logic fails to look up the route of the
    /// content item.
    ///
    /// While it ought to be fixed in Umbraco, this method has been updated to traverse up the tree until a culture
    /// has been found or the top of the tree has been reached. If none of the content items along the path specify
    /// a culture, the default culture configured in Umbraco (typically <c>en-US</c>) will be used as fallback.</para>
    /// </remarks>
    public static CultureInfo? GetCultureInfo(this IPublishedContent? content, IUmbracoContextAccessor umbracoContextAccessor, ISiteDomainMapper siteDomainMapper, Uri? uri = null) {

        // If no content item is specified, we return the default culture
        if (content == null) {
            IUmbracoContext ctx = umbracoContextAccessor.GetRequiredUmbracoContext();
            return CultureInfo.GetCultureInfo(ctx.Domains!.DefaultCulture);
        }

        // Get culture code via Umbraco's extension method
        string? code = content.GetCultureFromDomains(umbracoContextAccessor, siteDomainMapper, uri);

        // If no culture code was found, try the parent node - otherwise return the matching CultureInfo
        return string.IsNullOrWhiteSpace(code) ? GetCultureInfo(content.Parent, umbracoContextAccessor, siteDomainMapper, uri) : CultureInfo.GetCultureInfo(code);

    }

}