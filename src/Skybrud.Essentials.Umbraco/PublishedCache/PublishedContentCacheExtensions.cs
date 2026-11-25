using System;
using System.Diagnostics.CodeAnalysis;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;

namespace Skybrud.Essentials.Umbraco.PublishedCache;

/// <summary>
/// Static class with extension methods for retrieving content items from an <see cref="IPublishedContentCache"/>.
/// </summary>
public static class PublishedContentCacheExtensions {

    /// <summary>
    /// Gets the content item with the specified ID <paramref name="id"/> as an instance of <typeparamref name="TContent"/>.
    /// </summary>
    /// <typeparam name="TContent">The type of the content item.</typeparam>
    /// <param name="contentCache">A reference to the current <see cref="IPublishedContentCache"/>.</param>
    /// <param name="id">The ID of the content item.</param>
    /// <returns>An instance of <typeparamref name="TContent"/> representing the content item if the lookup is successful, or the <see langword="default"/> value of <typeparamref name="TContent"/> if the content item is not found, or the content item is not an instance of <typeparamref name="TContent"/>.</returns>
    public static TContent? GetById<TContent>(this IPublishedContentCache contentCache, int id) where TContent : IPublishedContent {
        return contentCache.GetById(id) is TContent content ? content : default;
    }

    /// <summary>
    /// Gets the content item with the specified ID <paramref name="id"/> and converts it to <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of the result returned by the callback function.</typeparam>
    /// <param name="contentCache">A reference to the current <see cref="IPublishedContentCache"/>.</param>
    /// <param name="id">The ID of the content item.</param>
    /// <param name="function">A callback function used for converting an <see cref="IPublishedContent"/> instance to <typeparamref name="TResult"/>.</param>
    /// <returns>The result of invoking <paramref name="function"/> with the content item if the lookup is successful, or the <see langword="default"/> value of <typeparamref name="TResult"/> if the content item is not found.</returns>
    public static TResult? GetById<TResult>(this IPublishedContentCache contentCache, int id, Func<IPublishedContent, TResult> function) {
        IPublishedContent? content = contentCache.GetById(id);
        return content is null ? default : function(content);
    }

    /// <summary>
    /// Gets the content item with the specified GUID key <paramref name="key"/> as an instance of <typeparamref name="TContent"/>.
    /// </summary>
    /// <typeparam name="TContent">The type of the content item.</typeparam>
    /// <param name="contentCache">A reference to the current <see cref="IPublishedContentCache"/>.</param>
    /// <param name="key">The GUID key of the content item.</param>
    /// <returns>An instance of <typeparamref name="TContent"/> representing the content item if the lookup is successful, or the <see langword="default"/> value of <typeparamref name="TContent"/> if the content item is not found, or the content item is not an instance of <typeparamref name="TContent"/>.</returns>
    public static TContent? GetById<TContent>(this IPublishedContentCache contentCache, Guid key) where TContent : IPublishedContent {
        return contentCache.GetById(key) is TContent content ? content : default;
    }

    /// <summary>
    /// Gets the content item with the specified GUID key <paramref name="key"/> and converts it to <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of the result returned by the callback function.</typeparam>
    /// <param name="contentCache">A reference to the current <see cref="IPublishedContentCache"/>.</param>
    /// <param name="key">The GUID key of the content item.</param>
    /// <param name="function">A callback function used for converting an <see cref="IPublishedContent"/> instance to <typeparamref name="TResult"/>.</param>
    /// <returns>The result of invoking <paramref name="function"/> with the content item if the lookup is successful, or the <see langword="default"/> value of <typeparamref name="TResult"/> if the content item is not found.</returns>
    public static TResult? GetById<TResult>(this IPublishedContentCache contentCache, Guid key, Func<IPublishedContent, TResult> function) {
        IPublishedContent? content = contentCache.GetById(key);
        return content is null ? default : function(content);
    }

    /// <summary>
    /// Gets the content item with the specified UDI <paramref name="udi"/>.
    /// </summary>
    /// <param name="cache">A reference to the current <see cref="IPublishedContentCache"/>.</param>
    /// <param name="udi">The UDI of the content item.</param>
    /// <returns>An instance of <see cref="IPublishedContent"/> representing the content item if the lookup is successful, or <see langword="null"/> if <paramref name="udi"/> is not an instance of <see cref="GuidUdi"/> or the content item is not found.</returns>
    public static IPublishedContent? GetById(this IPublishedContentCache cache, Udi udi) {
        return udi is GuidUdi guidUdi ? cache.GetById(guidUdi.Guid) : null;
    }

    /// <summary>
    /// Gets the content item with the specified UDI <paramref name="udi"/> as an instance of <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of the content item.</typeparam>
    /// <param name="cache">A reference to the current <see cref="IPublishedContentCache"/>.</param>
    /// <param name="udi">The UDI of the content item.</param>
    /// <returns>An instance of <typeparamref name="TResult"/> representing the content item if the lookup is successful, or the <see langword="default"/> value of <typeparamref name="TResult"/> if <paramref name="udi"/> is not an instance of <see cref="GuidUdi"/>, the content item is not found, or the content item is not an instance of <typeparamref name="TResult"/>.</returns>
    public static TResult? GetById<TResult>(this IPublishedContentCache cache, Udi udi) where TResult : IPublishedContent {
        return udi is GuidUdi guidUdi ? cache.GetById<TResult>(guidUdi.Guid) : default;
    }

    /// <summary>
    /// Gets the content item with the specified UDI <paramref name="udi"/> and converts it to <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of the result returned by the callback function.</typeparam>
    /// <param name="contentCache">A reference to the current <see cref="IPublishedContentCache"/>.</param>
    /// <param name="udi">The UDI of the content item.</param>
    /// <param name="function">A callback function used for converting an <see cref="IPublishedContent"/> instance to <typeparamref name="TResult"/>.</param>
    /// <returns>The result of invoking <paramref name="function"/> with the content item if the lookup is successful, or the <see langword="default"/> value of <typeparamref name="TResult"/> if <paramref name="udi"/> is not an instance of <see cref="GuidUdi"/>, or the content item is not found.</returns>
    public static TResult? GetById<TResult>(this IPublishedContentCache contentCache, Udi udi, Func<IPublishedContent, TResult> function) {
        IPublishedContent? content = contentCache.GetById(udi);
        return content is null ? default : function(content);
    }

    /// <summary>
    /// Attempts to get the content item with the specified ID <paramref name="id"/>.
    /// </summary>
    /// <param name="contentCache">A reference to the current <see cref="IPublishedContentCache"/>.</param>
    /// <param name="id">The ID of the content item.</param>
    /// <param name="result">When this method returns, holds an instance of <see cref="IPublishedContent"/> representing the content item if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="false"/> if the content item is not found; otherwise, <see langword="true"/>.</returns>
    public static bool TryGetById(this IPublishedContentCache contentCache, int id, [NotNullWhen(true)] out IPublishedContent? result) {
        result = contentCache.GetById(id);
        return result != null;
    }

    /// <summary>
    /// Attempts to get the content item with the specified ID <paramref name="id"/> as an instance of <typeparamref name="TContent"/>.
    /// </summary>
    /// <typeparam name="TContent">The type of the content item.</typeparam>
    /// <param name="contentCache">A reference to the current <see cref="IPublishedContentCache"/>.</param>
    /// <param name="id">The ID of the content item.</param>
    /// <param name="result">When this method returns, holds an instance of <typeparamref name="TContent"/> representing the content item if successful; otherwise, the <see langword="default"/> value of <typeparamref name="TContent"/>.</param>
    /// <returns><see langword="false"/> if the content item is not found, or the content item is not an instance of <typeparamref name="TContent"/>; otherwise, <see langword="true"/>.</returns>
    public static bool TryGetById<TContent>(this IPublishedContentCache contentCache, int id, [NotNullWhen(true)] out TContent? result) where TContent : IPublishedContent {

        if (contentCache.GetById(id) is TContent content) {
            result = content;
            return true;
        }

        result = default;
        return false;

    }

    /// <summary>
    /// Attempts to get the content item with the specified ID <paramref name="id"/> and convert it to <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of the result returned by the callback function.</typeparam>
    /// <param name="contentCache">A reference to the current <see cref="IPublishedContentCache"/>.</param>
    /// <param name="id">The ID of the content item.</param>
    /// <param name="function">A callback function used for converting an <see cref="IPublishedContent"/> instance to <typeparamref name="TResult"/>.</param>
    /// <param name="result">When this method returns, holds the result of invoking <paramref name="function"/> with the content item if the lookup is successful (which may be <see langword="null"/>); otherwise, the <see langword="default"/> value of <typeparamref name="TResult"/>.</param>
    /// <returns><see langword="false"/> if the content item is not found; otherwise, <see langword="true"/>.</returns>
    public static bool TryGetById<TResult>(this IPublishedContentCache contentCache, int id, Func<IPublishedContent, TResult> function, out TResult? result) {

        IPublishedContent? content = contentCache.GetById(id);

        if (content is not null) {
            result = function(content);
            return true;
        }

        result = default;
        return false;

    }

    /// <summary>
    /// Attempts to get the content item with the specified GUID key <paramref name="key"/>.
    /// </summary>
    /// <param name="contentCache">A reference to the current <see cref="IPublishedContentCache"/>.</param>
    /// <param name="key">The GUID key of the content item.</param>
    /// <param name="result">When this method returns, holds an instance of <see cref="IPublishedContent"/> representing the content item if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="false"/> if the content item is not found; otherwise, <see langword="true"/>.</returns>
    public static bool TryGetById(this IPublishedContentCache contentCache, Guid key, [NotNullWhen(true)] out IPublishedContent? result) {
        result = contentCache.GetById(key);
        return result != null;
    }

    /// <summary>
    /// Attempts to get the content item with the specified GUID key <paramref name="key"/> as an instance of <typeparamref name="TContent"/>.
    /// </summary>
    /// <typeparam name="TContent">The type of the content item.</typeparam>
    /// <param name="contentCache">A reference to the current <see cref="IPublishedContentCache"/>.</param>
    /// <param name="key">The GUID key of the content item.</param>
    /// <param name="result">When this method returns, holds an instance of <typeparamref name="TContent"/> representing the content item if successful; otherwise, the <see langword="default"/> value of <typeparamref name="TContent"/>.</param>
    /// <returns><see langword="false"/> if the content item is not found, or the content item is not an instance of <typeparamref name="TContent"/>; otherwise, <see langword="true"/>.</returns>
    public static bool TryGetById<TContent>(this IPublishedContentCache contentCache, Guid key, [NotNullWhen(true)] out TContent? result) where TContent : IPublishedContent {

        if (contentCache.GetById(key) is TContent content) {
            result = content;
            return true;
        }

        result = default;
        return false;

    }

    /// <summary>
    /// Attempts to get the content item with the specified GUID key <paramref name="key"/> and convert it to <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of the result returned by the callback function.</typeparam>
    /// <param name="contentCache">A reference to the current <see cref="IPublishedContentCache"/>.</param>
    /// <param name="key">The GUID key of the content item.</param>
    /// <param name="function">A callback function used for converting an <see cref="IPublishedContent"/> instance to <typeparamref name="TResult"/>.</param>
    /// <param name="result">When this method returns, holds the result of invoking <paramref name="function"/> with the content item if the lookup is successful (which may be <see langword="null"/>); otherwise, the <see langword="default"/> value of <typeparamref name="TResult"/>.</param>
    /// <returns><see langword="false"/> if the content item is not found; otherwise, <see langword="true"/>.</returns>
    public static bool TryGetById<TResult>(this IPublishedContentCache contentCache, Guid key, Func<IPublishedContent, TResult> function, out TResult? result) {

        IPublishedContent? content = contentCache.GetById(key);

        if (content is not null) {
            result = function(content);
            return true;
        }

        result = default;
        return false;

    }

    /// <summary>
    /// Attempts to get the content item with the specified UDI <paramref name="udi"/>.
    /// </summary>
    /// <param name="contentCache">A reference to the current <see cref="IPublishedContentCache"/>.</param>
    /// <param name="udi">The UDI of the content item.</param>
    /// <param name="result">When this method returns, holds an instance of <see cref="IPublishedContent"/> representing the content item if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="false"/> if <paramref name="udi"/> is not an instance of <see cref="GuidUdi"/>, or the content item is not found; otherwise, <see langword="true"/>.</returns>
    public static bool TryGetById(this IPublishedContentCache contentCache, Udi udi, [NotNullWhen(true)] out IPublishedContent? result) {
        result = contentCache.GetById(udi);
        return result != null;
    }

    /// <summary>
    /// Attempts to get the content item with the specified UDI <paramref name="udi"/> as an instance of <typeparamref name="TContent"/>.
    /// </summary>
    /// <typeparam name="TContent">The type of the content item.</typeparam>
    /// <param name="contentCache">A reference to the current <see cref="IPublishedContentCache"/>.</param>
    /// <param name="udi">The UDI of the content item.</param>
    /// <param name="result">When this method returns, holds an instance of <typeparamref name="TContent"/> representing the content item if successful; otherwise, the <see langword="default"/> value of <typeparamref name="TContent"/>.</param>
    /// <returns><see langword="false"/> if <paramref name="udi"/> is not an instance of <see cref="GuidUdi"/>, the content item is not found, or the content item is not an instance of <typeparamref name="TContent"/>; otherwise, <see langword="true"/>.</returns>
    public static bool TryGetById<TContent>(this IPublishedContentCache contentCache, Udi udi, [NotNullWhen(true)] out TContent? result) where TContent : IPublishedContent {

        if (contentCache.GetById(udi) is TContent content) {
            result = content;
            return true;
        }

        result = default;
        return false;

    }

    /// <summary>
    /// Attempts to get the content item with the specified UDI <paramref name="udi"/> and convert it to <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of the result returned by the callback function.</typeparam>
    /// <param name="contentCache">A reference to the current <see cref="IPublishedContentCache"/>.</param>
    /// <param name="udi">The UDI of the content item.</param>
    /// <param name="function">A callback function used for converting an <see cref="IPublishedContent"/> instance to <typeparamref name="TResult"/>.</param>
    /// <param name="result">When this method returns, holds the result of invoking <paramref name="function"/> with the content item if the lookup is successful (which may be <see langword="null"/>); otherwise, the <see langword="default"/> value of <typeparamref name="TResult"/>.</param>
    /// <returns><see langword="false"/> if <paramref name="udi"/> is not an instance of <see cref="GuidUdi"/>, or the content item is not found; otherwise, <see langword="true"/>.</returns>
    public static bool TryGetById<TResult>(this IPublishedContentCache contentCache, Udi udi, Func<IPublishedContent, TResult> function, out TResult? result) {

        IPublishedContent? content = contentCache.GetById(udi);

        if (content is not null) {
            result = function(content);
            return true;
        }

        result = default;
        return false;

    }

}