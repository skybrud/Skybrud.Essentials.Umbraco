using System.IO;
using Microsoft.AspNetCore.Http;
using Umbraco.Cms.Core.Models;

namespace Skybrud.Essentials.Umbraco.Media;

/// <summary>
/// Static class with various media extension methods.
/// </summary>
public static class MediaExtensions {

    /// <summary>
    /// Sets the <c>umbracoFile</c> property value to the specified <paramref name="file"/>.
    /// </summary>
    /// <param name="media">The parent media.</param>
    /// <param name="helper">An <see cref="MediaHelper"/> instance.</param>
    /// <param name="file">An uploaded file.</param>
    public static void SetValue(this IMedia media, MediaHelper helper, IFormFile file) {
        helper.SetValue(media, file);
    }

    /// <summary>
    /// Sets the <c>umbracoFile</c> property value to the specified <paramref name="file"/>.
    /// </summary>
    /// <param name="media">The parent media.</param>
    /// <param name="helper">An <see cref="MediaHelper"/> instance.</param>
    /// <param name="file">An uploaded file.</param>
    /// <param name="fileName">The name of the media file. If not specified, the name of <paramref name="file"/> will be used instead.</param>
    public static void SetValue(this IMedia media, MediaHelper helper, IFormFile file, string fileName) {
        helper.SetValue(media, file, fileName);
    }

    /// <summary>
    /// Sets the <c>umbracoFile</c> property value to the file in specified <paramref name="stream"/>.
    /// </summary>
    /// <param name="media">The parent media.</param>
    /// <param name="helper">An <see cref="MediaHelper"/> instance.</param>
    /// <param name="stream">The stream.</param>
    /// <param name="fileName">The name of the media file.</param>
    public static void SetValue(this IMedia media, MediaHelper helper, Stream stream, string fileName) {
        helper.SetValue(media, stream, fileName);
    }

}