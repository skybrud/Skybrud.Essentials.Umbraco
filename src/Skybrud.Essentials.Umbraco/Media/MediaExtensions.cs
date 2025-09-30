using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;

namespace Skybrud.Essentials.Umbraco.Media;

/// <summary>
/// Static class with various media extension methods.
/// </summary>
public static class MediaExtensions {

    /// <summary>
    /// Sets the property value to the specified <paramref name="file"/>.
    /// </summary>
    /// <param name="media">The parent media.</param>
    /// <param name="helper">An <see cref="MediaHelper"/> instance.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <param name="file">An uploaded file.</param>
    public static void SetValue(IMedia media, MediaHelper helper, string propertyAlias, IFormFile file) {
        helper.SetValue(media, propertyAlias, file, file.FileName);
    }

    /// <summary>
    /// Sets the property value to the specified <paramref name="file"/>.
    /// </summary>
    /// <param name="media">The parent media.</param>
    /// <param name="helper">An <see cref="MediaHelper"/> instance.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <param name="file">An uploaded file.</param>
    /// <param name="fileName">The name of the media file. If not specified, the name of <paramref name="file"/> will be used instead.</param>
    public static void SetValue(IMedia media, MediaHelper helper, string propertyAlias, IFormFile file, string? fileName) {
        helper.SetValue(media, propertyAlias, file.OpenReadStream(), fileName ?? file.FileName);
    }

    /// <summary>
    /// Sets the property value to the file in specified <paramref name="stream"/>.
    /// </summary>
    /// <param name="media">The parent media.</param>
    /// <param name="helper">An <see cref="MediaHelper"/> instance.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <param name="stream">The stream.</param>
    /// <param name="fileName">The name of the media file.</param>
    public static void SetValue(IMedia media, MediaHelper helper, string propertyAlias, Stream stream, string fileName) {
        helper.SetValue(media, propertyAlias, stream, fileName);
    }

    /// <summary>
    /// Sets the <c>umbracoFile</c> property value to the specified <paramref name="file"/>.
    /// </summary>
    /// <param name="media">The parent media.</param>
    /// <param name="helper">An <see cref="MediaHelper"/> instance.</param>
    /// <param name="file">An uploaded file.</param>
    public static void SetUmbracoFile(this IMedia media, MediaHelper helper, IFormFile file) {
        helper.SetUmbracoFile(media, file);
    }

    /// <summary>
    /// Sets the <c>umbracoFile</c> property value to the specified <paramref name="file"/>.
    /// </summary>
    /// <param name="media">The parent media.</param>
    /// <param name="helper">An <see cref="MediaHelper"/> instance.</param>
    /// <param name="file">An uploaded file.</param>
    /// <param name="fileName">The name of the media file. If not specified, the name of <paramref name="file"/> will be used instead.</param>
    public static void SetUmbracoFile(this IMedia media, MediaHelper helper, IFormFile file, string fileName) {
        helper.SetUmbracoFile(media, file, fileName);
    }

    /// <summary>
    /// Sets the <c>umbracoFile</c> property value to the file in specified <paramref name="stream"/>.
    /// </summary>
    /// <param name="media">The parent media.</param>
    /// <param name="helper">An <see cref="MediaHelper"/> instance.</param>
    /// <param name="stream">The stream.</param>
    /// <param name="fileName">The name of the media file.</param>
    public static void SetUmbracoFile(this IMedia media, MediaHelper helper, Stream stream, string fileName) {
        helper.SetUmbracoFile(media, stream, fileName);
    }

    /// <summary>
    /// Sets the key of the specified <paramref name="media"/>. This should only be used when creating new media.
    /// </summary>
    /// <param name="media">The media.</param>
    /// <param name="key">The key to set.</param>
    /// <returns>The input media - useful for method chains.</returns>
    public static IMedia SetKey(this IMedia media, Guid key) {
        media.Key = key;
        return media;
    }

    /// <summary>
    /// Saves the specified <paramref name="media"/> using the provided <paramref name="mediaService"/>.
    /// </summary>
    /// <param name="media">The media.</param>
    /// <param name="mediaService">A reference to the media service.</param>
    /// <param name="userId">The ID of the user saving the media.</param>
    /// <returns>The result of the save operation.</returns>
    public static Attempt<OperationResult?> Save(this IMedia media, IMediaService mediaService, int userId = -1) {
        return mediaService.Save(media, userId: userId);
    }

    /// <summary>
    /// Creates a new media item with the specified <paramref name="name"/>, <paramref name="parentId"/>, and <paramref name="mediaTypeAlias"/>.
    /// </summary>
    /// <param name="mediaService">The current <see cref="IMediaService"/> instance.</param>
    /// <param name="name">The name of the media item.</param>
    /// <param name="parentId">The numeric ID of the parent media, if any.</param>
    /// <param name="mediaTypeAlias">The alias of the media type.</param>
    /// <param name="userId">The ID of the user creating the media.</param>
    /// <returns>An instance of <see cref="IMedia"/> representing the created media.</returns>
    public static IMedia CreateMedia(this IMediaService mediaService, string name, int? parentId, string mediaTypeAlias, int userId = -1) {
        return mediaService.CreateMedia(name, parentId ?? -1, mediaTypeAlias, userId);
    }

    /// <summary>
    /// Creates a new media item with the specified <paramref name="name"/>, <paramref name="parentKey"/>, and <paramref name="mediaTypeAlias"/>.
    /// </summary>
    /// <param name="mediaService">The current <see cref="IMediaService"/> instance.</param>
    /// <param name="name">The name of the media item.</param>
    /// <param name="parentKey">The GUID key of the parent media, if any.</param>
    /// <param name="mediaTypeAlias">The alias of the media type.</param>
    /// <param name="userId">The ID of the user creating the media.</param>
    /// <returns>An instance of <see cref="IMedia"/> representing the created media.</returns>
    public static IMedia CreateMedia(this IMediaService mediaService, string name, Guid? parentKey, string mediaTypeAlias, int userId = -1) {
        return parentKey is null ? mediaService.CreateMedia(name, -1, mediaTypeAlias, userId) : mediaService.CreateMedia(name, parentKey.Value, mediaTypeAlias, userId);
    }

    /// <summary>
    /// Creates a new media item with the specified <paramref name="key"/>, <paramref name="name"/>, <paramref name="parentId"/>, and <paramref name="mediaTypeAlias"/>.
    /// </summary>
    /// <param name="mediaService">The current <see cref="IMediaService"/> instance.</param>
    /// <param name="key">The key of the media item.</param>
    /// <param name="name">The name of the media item.</param>
    /// <param name="parentId">The numeric ID of the parent media.</param>
    /// <param name="mediaTypeAlias">The alias of the media type.</param>
    /// <param name="userId">The ID of the user creating the media.</param>
    /// <returns>An instance of <see cref="IMedia"/> representing the created media.</returns>
    public static IMedia CreateMedia(this IMediaService mediaService, Guid key, string name, int parentId, string mediaTypeAlias, int userId = -1) {
        return mediaService.CreateMedia(name, parentId, mediaTypeAlias, userId).SetKey(key);
    }

    /// <summary>
    /// Creates a new media item with the specified <paramref name="key"/>, <paramref name="name"/>, <paramref name="parentId"/>, and <paramref name="mediaTypeAlias"/>.
    /// </summary>
    /// <param name="mediaService">The current <see cref="IMediaService"/> instance.</param>
    /// <param name="key">The key of the media item.</param>
    /// <param name="name">The name of the media item.</param>
    /// <param name="parentId">The numeric ID of the parent media.</param>
    /// <param name="mediaTypeAlias">The alias of the media type.</param>
    /// <param name="userId">The ID of the user creating the media.</param>
    /// <returns>An instance of <see cref="IMedia"/> representing the created media.</returns>
    public static IMedia CreateMedia(this IMediaService mediaService, Guid key, string name, int? parentId, string mediaTypeAlias, int userId = -1) {
        return CreateMedia(mediaService, key, name, parentId ?? -1, mediaTypeAlias, userId);
    }

    /// <summary>
    /// Creates a new media item with the specified <paramref name="key"/>, <paramref name="name"/>, <paramref name="parentKey"/>, and <paramref name="mediaTypeAlias"/>.
    /// </summary>
    /// <param name="mediaService">The current <see cref="IMediaService"/> instance.</param>
    /// <param name="key">The key of the media item.</param>
    /// <param name="name">The name of the media item.</param>
    /// <param name="parentKey">The GUID key of the parent media.</param>
    /// <param name="mediaTypeAlias">The alias of the media type.</param>
    /// <param name="userId">The ID of the user creating the media.</param>
    /// <returns>An instance of <see cref="IMedia"/> representing the created media.</returns>
    public static IMedia CreateMedia(this IMediaService mediaService, Guid key, string name, Guid parentKey, string mediaTypeAlias, int userId = -1) {
        return mediaService.CreateMedia(name, parentKey, mediaTypeAlias, userId).SetKey(key);
    }

    /// <summary>
    /// Creates a new media item with the specified <paramref name="key"/>, <paramref name="name"/>, <paramref name="parentKey"/>, and <paramref name="mediaTypeAlias"/>.
    /// </summary>
    /// <param name="mediaService">The current <see cref="IMediaService"/> instance.</param>
    /// <param name="key">The key of the media item.</param>
    /// <param name="name">The name of the media item.</param>
    /// <param name="parentKey">The GUID key of the parent media.</param>
    /// <param name="mediaTypeAlias">The alias of the media type.</param>
    /// <param name="userId">The ID of the user creating the media.</param>
    /// <returns>An instance of <see cref="IMedia"/> representing the created media.</returns>
    public static IMedia CreateMedia(this IMediaService mediaService, Guid key, string name, Guid? parentKey, string mediaTypeAlias, int userId = -1) {
        return CreateMedia(mediaService, name, parentKey, mediaTypeAlias, userId).SetKey(key);
    }

    /// <summary>
    /// Creates a new media item with the specified <paramref name="key"/>, <paramref name="name"/>, <paramref name="parent"/>, and <paramref name="mediaTypeAlias"/>.
    /// </summary>
    /// <param name="mediaService">The current <see cref="IMediaService"/> instance.</param>
    /// <param name="key">The key of the media item.</param>
    /// <param name="name">The name of the media item.</param>
    /// <param name="parent">The parent media, if any.</param>
    /// <param name="mediaTypeAlias">The alias of the media type.</param>
    /// <param name="userId">The ID of the user creating the media.</param>
    /// <returns>An instance of <see cref="IMedia"/> representing the created media.</returns>
    public static IMedia CreateMedia(this IMediaService mediaService, Guid key, string name, IMedia? parent, string mediaTypeAlias, int userId = -1) {
        return mediaService.CreateMedia(name, parent?.Id ?? -1, mediaTypeAlias, userId).SetKey(key);
    }

    /// <summary>
    /// Creates a new folder with the specified <paramref name="name"/> and <paramref name="parentId"/>.
    /// </summary>
    /// <param name="mediaService">The current <see cref="IMediaService"/> instance.</param>
    /// <param name="name">The name of the folder.</param>
    /// <param name="parentId">The numeric ID of the parent media, if any.</param>
    /// <param name="userId">The ID of the user creating the media.</param>
    /// <returns>An instance of <see cref="IMedia"/> representing the created folder.</returns>
    public static IMedia CreateFolder(this IMediaService mediaService, string name, int? parentId, int userId = -1) {
        return mediaService.CreateMedia(name, parentId, Constants.Conventions.MediaTypes.Folder, userId);
    }

    /// <summary>
    /// Creates a new folder with the specified <paramref name="name"/> and <paramref name="parentKey"/>.
    /// </summary>
    /// <param name="mediaService">The current <see cref="IMediaService"/> instance.</param>
    /// <param name="name">The name of the folder.</param>
    /// <param name="parentKey">The GUID key of the parent media, if any.</param>
    /// <param name="userId">The ID of the user creating the media.</param>
    /// <returns>An instance of <see cref="IMedia"/> representing the created folder.</returns>
    public static IMedia CreateFolder(this IMediaService mediaService, string name, Guid? parentKey, int userId = -1) {
        return CreateMedia(mediaService, name, parentKey, Constants.Conventions.MediaTypes.Folder, userId);
    }

    /// <summary>
    /// Creates a new folder media item with the specified <paramref name="name"/> and <paramref name="parent"/>.
    /// </summary>
    /// <param name="mediaService">The current <see cref="IMediaService"/> instance.</param>
    /// <param name="name">The name of the media item.</param>
    /// <param name="parent">The parent media, if any.</param>
    /// <param name="userId">The ID of the user creating the media.</param>
    /// <returns>An instance of <see cref="IMedia"/> representing the created folder.</returns>
    public static IMedia CreateFolder(this IMediaService mediaService, string name, IMedia? parent, int userId = -1) {
        return mediaService.CreateMedia(name, parent?.Id ?? -1, Constants.Conventions.MediaTypes.Folder, userId);
    }

    /// <summary>
    /// Creates a new folder media item with the specified <paramref name="key"/>, <paramref name="name"/> and <paramref name="parentId"/>.
    /// </summary>
    /// <param name="mediaService">The current <see cref="IMediaService"/> instance.</param>
    /// <param name="key">The key of the media item.</param>
    /// <param name="name">The name of the media item.</param>
    /// <param name="parentId">The numeric ID of the parent media, if any.</param>
    /// <param name="userId">The ID of the user creating the media.</param>
    /// <returns>An instance of <see cref="IMedia"/> representing the created folder.</returns>
    public static IMedia CreateFolder(this IMediaService mediaService, Guid key, string name, int? parentId, int userId = -1) {
        return CreateFolder(mediaService, name, parentId, userId).SetKey(key);
    }

    /// <summary>
    /// Creates a new folder media item with the specified <paramref name="key"/>, <paramref name="name"/> and <paramref name="parentKey"/>.
    /// </summary>
    /// <param name="mediaService">The current <see cref="IMediaService"/> instance.</param>
    /// <param name="key">The key of the media item.</param>
    /// <param name="name">The name of the media item.</param>
    /// <param name="parentKey">The GUID key of the parent media, if any.</param>
    /// <param name="userId">The ID of the user creating the media.</param>
    /// <returns>An instance of <see cref="IMedia"/> representing the created folder.</returns>
    public static IMedia CreateFolder(this IMediaService mediaService, Guid key, string name, Guid? parentKey, int userId = -1) {
        return CreateFolder(mediaService, name, parentKey, userId).SetKey(key);
    }

    /// <summary>
    /// Creates a new folder media item with the specified <paramref name="key"/>, <paramref name="name"/> and <paramref name="parent"/>.
    /// </summary>
    /// <param name="mediaService">The current <see cref="IMediaService"/> instance.</param>
    /// <param name="key">The key of the media item.</param>
    /// <param name="name">The name of the media item.</param>
    /// <param name="parent">The parent media, if any.</param>
    /// <param name="userId">The ID of the user creating the media.</param>
    /// <returns>An instance of <see cref="IMedia"/> representing the created folder.</returns>
    public static IMedia CreateFolder(this IMediaService mediaService, Guid key, string name, IMedia? parent, int userId = -1) {
        return CreateFolder(mediaService, name, parent, userId).SetKey(key);
    }

}