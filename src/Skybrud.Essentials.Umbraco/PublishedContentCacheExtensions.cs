using System;
using System.Diagnostics.CodeAnalysis;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;

namespace Skybrud.Essentials.Umbraco;

/// <summary>
/// Static class with various extension methods for <see cref="IPublishedContentCache"/>.
/// </summary>
public static class PublishedContentCacheExtensions {

    /// <summary>
    /// Returns an instance of <typeparamref name="TContent"/> representing the content item with the specified <paramref name="id"/>, or <see langword="null"/> if not found.
    /// </summary>
    /// <typeparam name="TContent">The type of the content.</typeparam>
    /// <param name="contentCache">A reference to the current <see cref="IPublishedContentCache"/>.</param>
    /// <param name="id">The ID of the content item.</param>
    /// <returns>An instance of <typeparamref name="TContent"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static TContent? GetById<TContent>(this IPublishedContentCache? contentCache, int id) where TContent : class, IPublishedContent {
        return contentCache?.GetById(id) as TContent;
    }

    /// <summary>
    /// Returns an instance of <typeparamref name="TResult"/> representing the content item with the specified <paramref name="id"/>, or <see langword="null"/> if not found.
    /// </summary>
    /// <typeparam name="TResult">The type of the converted content.</typeparam>
    /// <param name="contentCache">A reference to the current <see cref="IPublishedContentCache"/>.</param>
    /// <param name="id">The ID of the content item.</param>
    /// <param name="function">A callback function used for converting an <see cref="IPublishedContent"/> instance to <typeparamref name="TResult"/>.</param>
    /// <returns>An instance of <typeparamref name="TResult"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static TResult? GetById<TResult>(this IPublishedContentCache? contentCache, int id, Func<IPublishedContent, TResult> function) where TResult : class {
        IPublishedContent? content = contentCache?.GetById(id);
        return content is null ? null : function(content);
    }

    /// <summary>
    /// Returns an instance of <typeparamref name="TContent"/> representing the content item with the specified GUID <paramref name="key"/>, or <see langword="null"/> if not found.
    /// </summary>
    /// <typeparam name="TContent">The type of the content.</typeparam>
    /// <param name="contentCache">A reference to the current <see cref="IPublishedContentCache"/>.</param>
    /// <param name="key">The GUID key of the content item.</param>
    /// <returns>An instance of <typeparamref name="TContent"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static TContent? GetById<TContent>(this IPublishedContentCache? contentCache, Guid key) where TContent : class, IPublishedContent {
        return contentCache?.GetById(key) as TContent;
    }

    /// <summary>
    /// Returns an instance of <typeparamref name="TResult"/> representing the content item with the specified GUID <paramref name="key"/>, or <see langword="null"/> if not found.
    /// </summary>
    /// <typeparam name="TResult">The type of the converted content.</typeparam>
    /// <param name="contentCache">A reference to the current <see cref="IPublishedContentCache"/>.</param>
    /// <param name="key">The GUID key of the content item.</param>
    /// <param name="function">A callback function used for converting an <see cref="IPublishedContent"/> instance to <typeparamref name="TResult"/>.</param>
    /// <returns>An instance of <typeparamref name="TResult"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static TResult? GetById<TResult>(this IPublishedContentCache? contentCache, Guid key, Func<IPublishedContent, TResult> function) where TResult : class {
        IPublishedContent? content = contentCache?.GetById(key);
        return content is null ? default : function(content);
    }

    /// <summary>
    /// Attempts to get the content item matching the specified <paramref name="id"/>.
    /// </summary>
    /// <param name="contentCache">A reference to the current <see cref="IPublishedContentCache"/>.</param>
    /// <param name="id">The ID of the content item.</param>
    /// <param name="result">When this method returns, holds an instance of <see cref="IPublishedContent"/> if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetById(this IPublishedContentCache? contentCache, int id, [NotNullWhen(true)] out IPublishedContent? result) {
        result = contentCache?.GetById(id);
        return result != null;
    }

    /// <summary>
    /// Attempts to get the content item matching the specified <paramref name="id"/> as an instance of <typeparamref name="TContent"/>.
    /// </summary>
    /// <typeparam name="TContent">The type of the content item.</typeparam>
    /// <param name="contentCache">A reference to the current <see cref="IPublishedContentCache"/>.</param>
    /// <param name="id">The ID of the content item.</param>
    /// <param name="result">When this method returns, holds an instance of <typeparamref name="TContent"/> if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetById<TContent>(this IPublishedContentCache? contentCache, int id, [NotNullWhen(true)] out TContent? result) where TContent : class, IPublishedContent {

        if (contentCache?.GetById(id) is TContent content) {
            result = content;
            return true;
        }

        result = default;
        return false;

    }

    /// <summary>
    /// Attempts to get the content item matching the specified <paramref name="id"/> and convert it to an instance of <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of the content item.</typeparam>
    /// <param name="contentCache">A reference to the current <see cref="IPublishedContentCache"/>.</param>
    /// <param name="id">The ID of the content item.</param>
    /// <param name="function">A callback function used for converting an <see cref="IPublishedContent"/> instance to <typeparamref name="TResult"/>.</param>
    /// <param name="result">When this method returns, holds an instance of <typeparamref name="TResult"/> if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetById<TResult>(this IPublishedContentCache? contentCache, int id, Func<IPublishedContent, TResult> function, [NotNullWhen(true)] out TResult? result) where TResult : class {

        IPublishedContent? content = contentCache?.GetById(id);

        if (content is not null) {
            result = function(content);
            return true;
        }

        result = default;
        return false;

    }

    /// <summary>
    /// Attempts to get the content item matching the specified GUID <paramref name="key"/>.
    /// </summary>
    /// <param name="contentCache">A reference to the current <see cref="IPublishedContentCache"/>.</param>
    /// <param name="key">The GUID key of the content item.</param>
    /// <param name="result">When this method returns, holds an instance of <see cref="IPublishedContent"/> if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetById(this IPublishedContentCache? contentCache, Guid key, [NotNullWhen(true)] out IPublishedContent? result) {
        result = contentCache?.GetById(key);
        return result != null;
    }

    /// <summary>
    /// Attempts to get the content item matching the specified GUID <paramref name="key"/> as an instance of <typeparamref name="TContent"/>.
    /// </summary>
    /// <typeparam name="TContent">The type of the content item.</typeparam>
    /// <param name="contentCache">A reference to the current <see cref="IPublishedContentCache"/>.</param>
    /// <param name="key">The GUID key of the content item.</param>
    /// <param name="result">When this method returns, holds an instance of <typeparamref name="TContent"/> if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetById<TContent>(this IPublishedContentCache? contentCache, Guid key, [NotNullWhen(true)] out TContent? result) where TContent : class, IPublishedContent {

        if (contentCache?.GetById(key) is TContent content) {
            result = content;
            return true;
        }

        result = default;
        return false;

    }

    /// <summary>
    /// Attempts to get the content item matching the specified GUID <paramref name="key"/> and convert it to an instance of <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of the content item.</typeparam>
    /// <param name="contentCache">A reference to the current <see cref="IPublishedContentCache"/>.</param>
    /// <param name="key">The GUID key of the content item.</param>
    /// <param name="function">A callback function used for converting an <see cref="IPublishedContent"/> instance to <typeparamref name="TResult"/>.</param>
    /// <param name="result">When this method returns, holds an instance of <typeparamref name="TResult"/> if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetById<TResult>(this IPublishedContentCache? contentCache, Guid key, Func<IPublishedContent, TResult> function, [NotNullWhen(true)] out TResult? result) where TResult : class {

        IPublishedContent? content = contentCache?.GetById(key);

        if (content is not null) {
            result = function(content);
            return true;
        }

        result = default;
        return false;

    }

}