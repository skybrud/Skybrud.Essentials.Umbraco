using System;
using Umbraco.Cms.Core;

namespace Skybrud.Essentials.Umbraco;

[Obsolete("Use the 'Skybrud.Essentials.Umbraco.PublishedContent.PublishedContentQueryAccessorExtensions' class instead.")]
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
    [Obsolete("Use the 'Skybrud.Essentials.Umbraco.PublishedContent.PublishedContentQueryAccessorExtensions.GetValueOrNull' method instead.")]
    public static IPublishedContentQuery? GetValueOrNull(this IPublishedContentQueryAccessor accessor) {
        return PublishedContent.PublishedContentQueryAccessorExtensions.GetValueOrNull(accessor);
    }

    /// <summary>
    /// Gets the current <see cref="IPublishedContentQuery"/>.
    /// </summary>
    /// <param name="accessor">The published content query accessor.</param>
    /// <returns>The current <see cref="IPublishedContentQuery"/>.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when no published content query is available.
    /// </exception>
    [Obsolete("Use the 'Skybrud.Essentials.Umbraco.PublishedContent.PublishedContentQueryAccessorExtensions.GetRequiredValue' method instead.")]
    public static IPublishedContentQuery GetRequiredValue(this IPublishedContentQueryAccessor accessor) {
        return PublishedContent.PublishedContentQueryAccessorExtensions.GetRequiredValue(accessor);
    }

}