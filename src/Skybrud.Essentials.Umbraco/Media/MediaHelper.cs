using System.IO;
using Microsoft.AspNetCore.Http;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.IO;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Strings;
using Umbraco.Extensions;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Skybrud.Essentials.Umbraco.Media;

/// <summary>
/// Helper class for working with media in Umbraco.
/// </summary>
public class MediaHelper {

    public IMediaService MediaService { get; }

    public MediaFileManager MediaFileManager { get; }

    public MediaUrlGeneratorCollection MediaUrlGeneratorCollection { get; }

    public IShortStringHelper ShortStringHelper { get; }

    public IContentTypeBaseServiceProvider ContentTypeBaseServiceProvider { get; }

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="MediaHelper"/> class.
    /// </summary>
    /// <param name="mediaService"></param>
    /// <param name="mediaFileManager"></param>
    /// <param name="mediaUrlGeneratorCollection"></param>
    /// <param name="shortStringHelper"></param>
    /// <param name="contentTypeBaseServiceProvider"></param>
    public MediaHelper(IMediaService mediaService, MediaFileManager mediaFileManager, MediaUrlGeneratorCollection mediaUrlGeneratorCollection, IShortStringHelper shortStringHelper, IContentTypeBaseServiceProvider contentTypeBaseServiceProvider) {
        MediaService = mediaService;
        MediaFileManager = mediaFileManager;
        MediaUrlGeneratorCollection = mediaUrlGeneratorCollection;
        ShortStringHelper = shortStringHelper;
        ContentTypeBaseServiceProvider = contentTypeBaseServiceProvider;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Sets the property value to the specified <paramref name="file"/>.
    /// </summary>
    /// <param name="media">The parent media.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <param name="file">An uploaded file.</param>
    public virtual void SetValue(IMedia media, string propertyAlias, IFormFile file) {
        SetValue(media, propertyAlias, file, file.FileName);
    }

    /// <summary>
    /// Sets the property value to the specified <paramref name="file"/>.
    /// </summary>
    /// <param name="media">The parent media.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <param name="file">An uploaded file.</param>
    /// <param name="fileName">The name of the media file. If not specified, the name of <paramref name="file"/> will be used instead.</param>
    public virtual void SetValue(IMedia media, string propertyAlias, IFormFile file, string? fileName) {
        SetValue(media, propertyAlias, file.OpenReadStream(), fileName ?? file.FileName);
    }

    /// <summary>
    /// Sets the property value to the file in specified <paramref name="stream"/>.
    /// </summary>
    /// <param name="media">The parent media.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <param name="stream">The stream.</param>
    /// <param name="fileName">The name of the media file.</param>
    public virtual void SetValue(IMedia media, string propertyAlias, Stream stream, string fileName) {
        media.SetValue(MediaFileManager, MediaUrlGeneratorCollection, ShortStringHelper, ContentTypeBaseServiceProvider, propertyAlias, fileName, stream);
    }

    /// <summary>
    /// Sets the <c>umbracoFile</c> property value to the specified <paramref name="file"/>.
    /// </summary>
    /// <param name="media">The parent media.</param>
    /// <param name="file">An uploaded file.</param>
    public virtual void SetUmbracoFile(IMedia media, IFormFile file) {
        SetUmbracoFile(media, file, file.FileName);
    }

    /// <summary>
    /// Sets the <c>umbracoFile</c> property value to the specified <paramref name="file"/>.
    /// </summary>
    /// <param name="media">The parent media.</param>
    /// <param name="file">An uploaded file.</param>
    /// <param name="fileName">The name of the media file. If not specified, the name of <paramref name="file"/> will be used instead.</param>
    public virtual void SetUmbracoFile(IMedia media, IFormFile file, string? fileName) {
        media.SetValue(MediaFileManager, MediaUrlGeneratorCollection, ShortStringHelper, ContentTypeBaseServiceProvider, global::Umbraco.Cms.Core.Constants.Conventions.Media.File, fileName ?? file.FileName, file.OpenReadStream());
    }

    /// <summary>
    /// Sets the <c>umbracoFile</c> property value to the file in specified <paramref name="stream"/>.
    /// </summary>
    /// <param name="media">The parent media.</param>
    /// <param name="stream">The stream.</param>
    /// <param name="fileName">The name of the media file.</param>
    public virtual void SetUmbracoFile(IMedia media, Stream stream, string fileName) {
        media.SetValue(MediaFileManager, MediaUrlGeneratorCollection, ShortStringHelper, ContentTypeBaseServiceProvider, global::Umbraco.Cms.Core.Constants.Conventions.Media.File, fileName, stream);
    }

    #endregion

}