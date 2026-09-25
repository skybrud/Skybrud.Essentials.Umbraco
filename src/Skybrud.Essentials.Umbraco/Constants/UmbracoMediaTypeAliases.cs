using System;

namespace Skybrud.Essentials.Umbraco.Constants;

/// <summary>
/// Constants for aliases of Umbraco's build-in media types.
///
/// Similar to <see cref="global::Umbraco.Cms.Core.Constants.Conventions.MediaTypes"/>, but this class may provide easier access.
/// </summary>
public class UmbracoMediaTypeAliases {

    public const string Image = global::Umbraco.Cms.Core.Constants.Conventions.MediaTypes.Image;

    public const string File = global::Umbraco.Cms.Core.Constants.Conventions.MediaTypes.File;

    public const string Folder = global::Umbraco.Cms.Core.Constants.Conventions.MediaTypes.Folder;

    public const string Article = global::Umbraco.Cms.Core.Constants.Conventions.MediaTypes.ArticleAlias;

    public const string Audio = global::Umbraco.Cms.Core.Constants.Conventions.MediaTypes.AudioAlias;

    public const string Video = global::Umbraco.Cms.Core.Constants.Conventions.MediaTypes.VideoAlias;

    public const string VectorGraphics = global::Umbraco.Cms.Core.Constants.Conventions.MediaTypes.VectorGraphicsAlias;

    /// <summary>
    /// Alias of <see cref="VectorGraphics"/>.
    /// </summary>
    public const string Svg = VectorGraphics;

}