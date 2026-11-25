using System;
using System.Diagnostics.CodeAnalysis;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;

namespace Skybrud.Essentials.Umbraco.PublishedCache;

/// <summary>
/// Static class with extension methods for retrieving media items from an <see cref="IPublishedMediaCache"/>.
/// </summary>
public static class PublishedMediaCacheExtensions {

    /// <summary>
    /// Gets the media item with the specified ID <paramref name="id"/> as an instance of <typeparamref name="TMedia"/>.
    /// </summary>
    /// <typeparam name="TMedia">The type of the media item.</typeparam>
    /// <param name="mediaCache">A reference to the current <see cref="IPublishedMediaCache"/>.</param>
    /// <param name="id">The ID of the media item.</param>
    /// <returns>An instance of <typeparamref name="TMedia"/> representing the media item if the lookup is successful, or the <see langword="default"/> value of <typeparamref name="TMedia"/> if the media item is not found, or the media item is not an instance of <typeparamref name="TMedia"/>.</returns>
    public static TMedia? GetById<TMedia>(this IPublishedMediaCache mediaCache, int id) where TMedia : IPublishedContent {
        return mediaCache.GetById(id) is TMedia media ? media : default;
    }

    /// <summary>
    /// Gets the media item with the specified ID <paramref name="id"/> and converts it to <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of the result returned by the callback function.</typeparam>
    /// <param name="mediaCache">A reference to the current <see cref="IPublishedMediaCache"/>.</param>
    /// <param name="id">The ID of the media item.</param>
    /// <param name="function">A callback function used for converting an <see cref="IPublishedContent"/> instance to <typeparamref name="TResult"/>.</param>
    /// <returns>The result of invoking <paramref name="function"/> with the media item if the lookup is successful, or the <see langword="default"/> value of <typeparamref name="TResult"/> if the media item is not found.</returns>
    public static TResult? GetById<TResult>(this IPublishedMediaCache mediaCache, int id, Func<IPublishedContent, TResult> function) {
        IPublishedContent? media = mediaCache.GetById(id);
        return media is null ? default : function(media);
    }

    /// <summary>
    /// Gets the media item with the specified GUID key <paramref name="key"/> as an instance of <typeparamref name="TMedia"/>.
    /// </summary>
    /// <typeparam name="TMedia">The type of the media item.</typeparam>
    /// <param name="mediaCache">A reference to the current <see cref="IPublishedMediaCache"/>.</param>
    /// <param name="key">The GUID key of the media item.</param>
    /// <returns>An instance of <typeparamref name="TMedia"/> representing the media item if the lookup is successful, or the <see langword="default"/> value of <typeparamref name="TMedia"/> if the media item is not found, or the media item is not an instance of <typeparamref name="TMedia"/>.</returns>
    public static TMedia? GetById<TMedia>(this IPublishedMediaCache mediaCache, Guid key) where TMedia : IPublishedContent {
        return mediaCache.GetById(key) is TMedia media ? media : default;
    }

    /// <summary>
    /// Gets the media item with the specified GUID key <paramref name="key"/> and converts it to <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of the result returned by the callback function.</typeparam>
    /// <param name="mediaCache">A reference to the current <see cref="IPublishedMediaCache"/>.</param>
    /// <param name="key">The GUID key of the media item.</param>
    /// <param name="function">A callback function used for converting an <see cref="IPublishedContent"/> instance to <typeparamref name="TResult"/>.</param>
    /// <returns>The result of invoking <paramref name="function"/> with the media item if the lookup is successful, or the <see langword="default"/> value of <typeparamref name="TResult"/> if the media item is not found.</returns>
    public static TResult? GetById<TResult>(this IPublishedMediaCache mediaCache, Guid key, Func<IPublishedContent, TResult> function) {
        IPublishedContent? media = mediaCache.GetById(key);
        return media is null ? default : function(media);
    }

    /// <summary>
    /// Gets the media item with the specified UDI <paramref name="udi"/>.
    /// </summary>
    /// <param name="cache">A reference to the current <see cref="IPublishedMediaCache"/>.</param>
    /// <param name="udi">The UDI of the media item.</param>
    /// <returns>An instance of <see cref="IPublishedContent"/> representing the media item if the lookup is successful, or <see langword="null"/> if <paramref name="udi"/> is not an instance of <see cref="GuidUdi"/> or the media item is not found.</returns>
    public static IPublishedContent? GetById(this IPublishedMediaCache cache, Udi udi) {
        return udi is GuidUdi guidUdi ? cache.GetById(guidUdi.Guid) : null;
    }

    /// <summary>
    /// Gets the media item with the specified UDI <paramref name="udi"/> as an instance of <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of the media item.</typeparam>
    /// <param name="cache">A reference to the current <see cref="IPublishedMediaCache"/>.</param>
    /// <param name="udi">The UDI of the media item.</param>
    /// <returns>An instance of <typeparamref name="TResult"/> representing the media item if the lookup is successful, or the <see langword="default"/> value of <typeparamref name="TResult"/> if <paramref name="udi"/> is not an instance of <see cref="GuidUdi"/>, the media item is not found, or the media item is not an instance of <typeparamref name="TResult"/>.</returns>
    public static TResult? GetById<TResult>(this IPublishedMediaCache cache, Udi udi) where TResult : IPublishedContent {
        return udi is GuidUdi guidUdi ? cache.GetById<TResult>(guidUdi.Guid) : default;
    }

    /// <summary>
    /// Gets the media item with the specified UDI <paramref name="udi"/> and converts it to <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of the result returned by the callback function.</typeparam>
    /// <param name="mediaCache">A reference to the current <see cref="IPublishedMediaCache"/>.</param>
    /// <param name="udi">The UDI of the media item.</param>
    /// <param name="function">A callback function used for converting an <see cref="IPublishedContent"/> instance to <typeparamref name="TResult"/>.</param>
    /// <returns>The result of invoking <paramref name="function"/> with the media item if the lookup is successful, or the <see langword="default"/> value of <typeparamref name="TResult"/> if <paramref name="udi"/> is not an instance of <see cref="GuidUdi"/>, or the media item is not found.</returns>
    public static TResult? GetById<TResult>(this IPublishedMediaCache mediaCache, Udi udi, Func<IPublishedContent, TResult> function) {
        IPublishedContent? media = mediaCache.GetById(udi);
        return media is null ? default : function(media);
    }

    /// <summary>
    /// Attempts to get the media item with the specified ID <paramref name="id"/>.
    /// </summary>
    /// <param name="mediaCache">A reference to the current <see cref="IPublishedMediaCache"/>.</param>
    /// <param name="id">The ID of the media item.</param>
    /// <param name="result">When this method returns, holds an instance of <see cref="IPublishedContent"/> representing the media item if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="false"/> if the media item is not found; otherwise, <see langword="true"/>.</returns>
    public static bool TryGetById(this IPublishedMediaCache mediaCache, int id, [NotNullWhen(true)] out IPublishedContent? result) {
        result = mediaCache.GetById(id);
        return result != null;
    }

    /// <summary>
    /// Attempts to get the media item with the specified ID <paramref name="id"/> as an instance of <typeparamref name="TMedia"/>.
    /// </summary>
    /// <typeparam name="TMedia">The type of the media item.</typeparam>
    /// <param name="mediaCache">A reference to the current <see cref="IPublishedMediaCache"/>.</param>
    /// <param name="id">The ID of the media item.</param>
    /// <param name="result">When this method returns, holds an instance of <typeparamref name="TMedia"/> representing the media item if successful; otherwise, the <see langword="default"/> value of <typeparamref name="TMedia"/>.</param>
    /// <returns><see langword="false"/> if the media item is not found, or the media item is not an instance of <typeparamref name="TMedia"/>; otherwise, <see langword="true"/>.</returns>
    public static bool TryGetById<TMedia>(this IPublishedMediaCache mediaCache, int id, [NotNullWhen(true)] out TMedia? result) where TMedia : IPublishedContent {

        if (mediaCache.GetById(id) is TMedia media) {
            result = media;
            return true;
        }

        result = default;
        return false;

    }

    /// <summary>
    /// Attempts to get the media item with the specified ID <paramref name="id"/> and convert it to <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of the result returned by the callback function.</typeparam>
    /// <param name="mediaCache">A reference to the current <see cref="IPublishedMediaCache"/>.</param>
    /// <param name="id">The ID of the media item.</param>
    /// <param name="function">A callback function used for converting an <see cref="IPublishedContent"/> instance to <typeparamref name="TResult"/>.</param>
    /// <param name="result">When this method returns, holds the result of invoking <paramref name="function"/> with the media item if the lookup is successful (which may be <see langword="null"/>); otherwise, the <see langword="default"/> value of <typeparamref name="TResult"/>.</param>
    /// <returns><see langword="false"/> if the media item is not found; otherwise, <see langword="true"/>.</returns>
    public static bool TryGetById<TResult>(this IPublishedMediaCache mediaCache, int id, Func<IPublishedContent, TResult> function, out TResult? result) {

        IPublishedContent? media = mediaCache.GetById(id);

        if (media is not null) {
            result = function(media);
            return true;
        }

        result = default;
        return false;

    }

    /// <summary>
    /// Attempts to get the media item with the specified GUID key <paramref name="key"/>.
    /// </summary>
    /// <param name="mediaCache">A reference to the current <see cref="IPublishedMediaCache"/>.</param>
    /// <param name="key">The GUID key of the media item.</param>
    /// <param name="result">When this method returns, holds an instance of <see cref="IPublishedContent"/> representing the media item if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="false"/> if the media item is not found; otherwise, <see langword="true"/>.</returns>
    public static bool TryGetById(this IPublishedMediaCache mediaCache, Guid key, [NotNullWhen(true)] out IPublishedContent? result) {
        result = mediaCache.GetById(key);
        return result != null;
    }

    /// <summary>
    /// Attempts to get the media item with the specified GUID key <paramref name="key"/> as an instance of <typeparamref name="TMedia"/>.
    /// </summary>
    /// <typeparam name="TMedia">The type of the media item.</typeparam>
    /// <param name="mediaCache">A reference to the current <see cref="IPublishedMediaCache"/>.</param>
    /// <param name="key">The GUID key of the media item.</param>
    /// <param name="result">When this method returns, holds an instance of <typeparamref name="TMedia"/> representing the media item if successful; otherwise, the <see langword="default"/> value of <typeparamref name="TMedia"/>.</param>
    /// <returns><see langword="false"/> if the media item is not found, or the media item is not an instance of <typeparamref name="TMedia"/>; otherwise, <see langword="true"/>.</returns>
    public static bool TryGetById<TMedia>(this IPublishedMediaCache mediaCache, Guid key, [NotNullWhen(true)] out TMedia? result) where TMedia : IPublishedContent {

        if (mediaCache.GetById(key) is TMedia media) {
            result = media;
            return true;
        }

        result = default;
        return false;

    }

    /// <summary>
    /// Attempts to get the media item with the specified GUID key <paramref name="key"/> and convert it to <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of the result returned by the callback function.</typeparam>
    /// <param name="mediaCache">A reference to the current <see cref="IPublishedMediaCache"/>.</param>
    /// <param name="key">The GUID key of the media item.</param>
    /// <param name="function">A callback function used for converting an <see cref="IPublishedContent"/> instance to <typeparamref name="TResult"/>.</param>
    /// <param name="result">When this method returns, holds the result of invoking <paramref name="function"/> with the media item if the lookup is successful (which may be <see langword="null"/>); otherwise, the <see langword="default"/> value of <typeparamref name="TResult"/>.</param>
    /// <returns><see langword="false"/> if the media item is not found; otherwise, <see langword="true"/>.</returns>
    public static bool TryGetById<TResult>(this IPublishedMediaCache mediaCache, Guid key, Func<IPublishedContent, TResult> function, out TResult? result) {

        IPublishedContent? media = mediaCache.GetById(key);

        if (media is not null) {
            result = function(media);
            return true;
        }

        result = default;
        return false;

    }

    /// <summary>
    /// Attempts to get the media item with the specified UDI <paramref name="udi"/>.
    /// </summary>
    /// <param name="mediaCache">A reference to the current <see cref="IPublishedMediaCache"/>.</param>
    /// <param name="udi">The UDI of the media item.</param>
    /// <param name="result">When this method returns, holds an instance of <see cref="IPublishedContent"/> representing the media item if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="false"/> if <paramref name="udi"/> is not an instance of <see cref="GuidUdi"/>, or the media item is not found; otherwise, <see langword="true"/>.</returns>
    public static bool TryGetById(this IPublishedMediaCache mediaCache, Udi udi, [NotNullWhen(true)] out IPublishedContent? result) {
        result = mediaCache.GetById(udi);
        return result != null;
    }

    /// <summary>
    /// Attempts to get the media item with the specified UDI <paramref name="udi"/> as an instance of <typeparamref name="TMedia"/>.
    /// </summary>
    /// <typeparam name="TMedia">The type of the media item.</typeparam>
    /// <param name="mediaCache">A reference to the current <see cref="IPublishedMediaCache"/>.</param>
    /// <param name="udi">The UDI of the media item.</param>
    /// <param name="result">When this method returns, holds an instance of <typeparamref name="TMedia"/> representing the media item if successful; otherwise, the <see langword="default"/> value of <typeparamref name="TMedia"/>.</param>
    /// <returns><see langword="false"/> if <paramref name="udi"/> is not an instance of <see cref="GuidUdi"/>, the media item is not found, or the media item is not an instance of <typeparamref name="TMedia"/>; otherwise, <see langword="true"/>.</returns>
    public static bool TryGetById<TMedia>(this IPublishedMediaCache mediaCache, Udi udi, [NotNullWhen(true)] out TMedia? result) where TMedia : IPublishedContent {

        if (mediaCache.GetById(udi) is TMedia media) {
            result = media;
            return true;
        }

        result = default;
        return false;

    }

    /// <summary>
    /// Attempts to get the media item with the specified UDI <paramref name="udi"/> and convert it to <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of the result returned by the callback function.</typeparam>
    /// <param name="mediaCache">A reference to the current <see cref="IPublishedMediaCache"/>.</param>
    /// <param name="udi">The UDI of the media item.</param>
    /// <param name="function">A callback function used for converting an <see cref="IPublishedContent"/> instance to <typeparamref name="TResult"/>.</param>
    /// <param name="result">When this method returns, holds the result of invoking <paramref name="function"/> with the media item if the lookup is successful (which may be <see langword="null"/>); otherwise, the <see langword="default"/> value of <typeparamref name="TResult"/>.</param>
    /// <returns><see langword="false"/> if <paramref name="udi"/> is not an instance of <see cref="GuidUdi"/>, or the media item is not found; otherwise, <see langword="true"/>.</returns>
    public static bool TryGetById<TResult>(this IPublishedMediaCache mediaCache, Udi udi, Func<IPublishedContent, TResult> function, out TResult? result) {

        IPublishedContent? media = mediaCache.GetById(udi);

        if (media is not null) {
            result = function(media);
            return true;
        }

        result = default;
        return false;

    }

}