using System.Collections.Generic;

namespace Skybrud.Essentials.Umbraco.Media;

/// <summary>
/// Static class with various media file extensions.
/// </summary>
public static class UmbracoMediaExtensions {

    private static readonly Dictionary<string, string> _aliases = new(System.StringComparer.OrdinalIgnoreCase) {
        { nameof(Doc), Doc },
        { nameof(Docx), Docx },
        { nameof(Pdf), Pdf },
        { nameof(Mp3), Mp3 },
        { nameof(WebA), WebA },
        { nameof(Oga), Oga },
        { nameof(Opus), Opus },
        { nameof(Svg), Svg },
        { nameof(Mp4), Mp4 },
        { nameof(WebM), WebM },
        { nameof(Ogv), Ogv }
    };

    #region Article

    /// <summary>
    /// Alias of <see cref="UmbracoMediaTypes.Article"/>.
    /// </summary>
    public const string Doc = UmbracoMediaTypes.Article;

    /// <summary>
    /// Alias of <see cref="UmbracoMediaTypes.Article"/>.
    /// </summary>
    public const string Docx = UmbracoMediaTypes.Article;

    /// <summary>
    /// Alias of <see cref="UmbracoMediaTypes.Article"/>.
    /// </summary>
    public const string Pdf = UmbracoMediaTypes.Article;

    #endregion

    #region Audio

    /// <summary>
    /// Alias of <see cref="UmbracoMediaTypes.Audio"/>.
    /// </summary>
    public const string Mp3 = UmbracoMediaTypes.Audio;


    /// <summary>
    /// Alias of <see cref="UmbracoMediaTypes.Audio"/>.
    /// </summary>
    public const string WebA = UmbracoMediaTypes.Audio;


    /// <summary>
    /// Alias of <see cref="UmbracoMediaTypes.Audio"/>.
    /// </summary>
    public const string Oga = UmbracoMediaTypes.Audio;


    /// <summary>
    /// Alias of <see cref="UmbracoMediaTypes.Audio"/>.
    /// </summary>
    public const string Opus = UmbracoMediaTypes.Audio;

    #endregion

    #region Vector Graphics

    /// <summary>
    /// Alias of <see cref="UmbracoMediaTypes.VectorGraphics"/>.
    /// </summary>
    public const string Svg = UmbracoMediaTypes.VectorGraphics;

    #endregion

    #region Video

    /// <summary>
    /// Alias of <see cref="UmbracoMediaTypes.Video"/>.
    /// </summary>
    public const string Mp4 = UmbracoMediaTypes.Video;

    /// <summary>
    /// Alias of <see cref="UmbracoMediaTypes.Video"/>.
    /// </summary>
    public const string WebM = UmbracoMediaTypes.Video;

    /// <summary>
    /// Alias of <see cref="UmbracoMediaTypes.Video"/>.
    /// </summary>
    public const string Ogv = UmbracoMediaTypes.Video;

    #endregion

    /// <summary>
    /// Attempts to get the media type alias for the specified file <paramref name="extension"/>.
    /// </summary>
    /// <param name="extension">The file extension (with or without a leading <c></c>.)</param>
    /// <param name="result">When this method returns, holds the media type alias if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise <see langword="false"/>.</returns>
    public static bool TryGetMediaTypeAlias(string extension, out string? result) {
        return _aliases.TryGetValue(extension.TrimStart('.'), out result);
    }

}