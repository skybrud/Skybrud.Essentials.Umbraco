using System.IO;
using Microsoft.AspNetCore.Http;
using Umbraco.Cms.Core.Models;

namespace Skybrud.Essentials.Umbraco.Media;

/// <summary>
/// Interface describing a media helper.
/// </summary>
public interface IMediaHelper {

    /// <summary>
    /// Sets the <c>umbracoFile</c> property value to the specified <paramref name="file"/>.
    /// </summary>
    /// <param name="media">The parent media.</param>
    /// <param name="file">An uploaded file.</param>
    void SetValue(IMedia media, IFormFile file);

    /// <summary>
    /// Sets the <c>umbracoFile</c> property value to the specified <paramref name="file"/>.
    /// </summary>
    /// <param name="media">The parent media.</param>
    /// <param name="file">An uploaded file.</param>
    /// <param name="fileName">The name of the media file. If not specified, the name of <paramref name="file"/> will be used instead.</param>
    void SetValue(IMedia media, IFormFile file, string? fileName);

    /// <summary>
    /// Sets the <c>umbracoFile</c> property value to the file in specified <paramref name="stream"/>.
    /// </summary>
    /// <param name="media">The parent media.</param>
    /// <param name="stream">The stream.</param>
    /// <param name="fileName">The name of the media file.</param>
    void SetValue(IMedia media, Stream stream, string fileName);

}