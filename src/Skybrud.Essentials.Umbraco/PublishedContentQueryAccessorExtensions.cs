using System;
using Umbraco.Cms.Core;

namespace Skybrud.Essentials.Umbraco;

public static class PublishedContentQueryAccessorExtensions {

    /// <summary>
    /// Gets the current <see cref="IPublishedContentQuery"/>, or <see langword="null"/> if no
    /// published content query is available.
    /// </summary>
    /// <param name="accessor">The published content query accessor.</param>
    /// <returns>
    /// The current <see cref="IPublishedContentQuery"/>, or <see langword="null"/> if no
    /// published content query is available.
    /// </returns>
    public static IPublishedContentQuery? GetValueOrNull(this IPublishedContentQueryAccessor accessor) {
        return accessor.TryGetValue(out IPublishedContentQuery? publishedContentQuery) ? publishedContentQuery : null;
    }

    /// <summary>
    /// Gets the current <see cref="IPublishedContentQuery"/>.
    /// </summary>
    /// <param name="accessor">The published content query accessor.</param>
    /// <returns>The current <see cref="IPublishedContentQuery"/>.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when no published content query is available.
    /// </exception>
    public static IPublishedContentQuery GetRequiredValue(this IPublishedContentQueryAccessor accessor) {
        if (accessor.TryGetValue(out IPublishedContentQuery? publishedContentQuery)) return publishedContentQuery;
        throw new InvalidOperationException("No published content query is available in the current context.");
    }

}