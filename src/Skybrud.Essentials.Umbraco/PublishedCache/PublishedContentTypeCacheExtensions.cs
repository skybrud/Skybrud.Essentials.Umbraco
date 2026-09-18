using System;
using System.Diagnostics.CodeAnalysis;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;

namespace Skybrud.Essentials.Umbraco.PublishedCache;

/// <summary>
/// Provides extension methods for safely retrieving published content types from an <see cref="IPublishedContentTypeCache"/>.
/// </summary>
public static class PublishedContentTypeCacheExtensions {

    /// <summary>
    /// Gets a published content type with the specified key, or <see langword="null"/> if no matching content type is found.
    /// </summary>
    /// <param name="cache">The published content type cache.</param>
    /// <param name="itemType">The type of published item.</param>
    /// <param name="key">The unique key of the published content type.</param>
    /// <returns>
    /// The matching published content type, or <see langword="null"/> if no matching content type is found.
    /// </returns>
    public static IPublishedContentType? GetOrNull(this IPublishedContentTypeCache cache, PublishedItemType itemType, Guid key) {
        try {
            return cache.Get(itemType, key);
        } catch (Exception) {
            return null;
        }
    }

    /// <summary>
    /// Gets a published content type with the specified alias, or <see langword="null"/> if no matching content type is found.
    /// </summary>
    /// <param name="cache">The published content type cache.</param>
    /// <param name="itemType">The type of published item.</param>
    /// <param name="alias">The alias of the published content type.</param>
    /// <returns>
    /// The matching published content type, or <see langword="null"/> if no matching content type is found.
    /// </returns>
    public static IPublishedContentType? GetOrNull(this IPublishedContentTypeCache cache, PublishedItemType itemType, string alias) {
        try {
            return cache.Get(itemType, alias);
        } catch (Exception) {
            return null;
        }
    }

    /// <summary>
    /// Attempts to retrieve a published content type with the specified key.
    /// </summary>
    /// <param name="cache">The published content type cache.</param>
    /// <param name="itemType">The type of published item.</param>
    /// <param name="key">The unique key of the published content type.</param>
    /// <param name="contentType"> When this method returns <see langword="true"/>, contains the matching published content type; otherwise, <see langword="null"/>.</param>
    /// <returns>
    /// <see langword="true"/> if the published content type was found; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool TryGet(this IPublishedContentTypeCache cache, PublishedItemType itemType, Guid key, [NotNullWhen(true)] out IPublishedContentType? contentType) {
        try {
            contentType = cache.Get(itemType, key);
            return true;
        } catch (Exception) {
            contentType = null;
            return false;
        }
    }
    /// <summary>
    /// Attempts to retrieve a published content type with the specified alias.
    /// </summary>
    /// <param name="cache">The published content type cache.</param>
    /// <param name="itemType">The type of published item.</param>
    /// <param name="alias">The alias of the published content type.</param>
    /// <param name="contentType">When this method returns <see langword="true"/>, contains the matching published content type; otherwise, <see langword="null"/>.</param>
    /// <returns>
    /// <see langword="true"/> if the published content type was found; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool TryGet(this IPublishedContentTypeCache cache, PublishedItemType itemType, string alias, [NotNullWhen(true)] out IPublishedContentType? contentType) {
        try {
            contentType = cache.Get(itemType, alias);
            return true;
        } catch (Exception) {
            contentType = null;
            return false;
        }
    }

}