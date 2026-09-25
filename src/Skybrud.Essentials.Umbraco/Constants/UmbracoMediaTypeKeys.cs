using System;

namespace Skybrud.Essentials.Umbraco.Constants;

/// <summary>
/// Constants for Umbraco media type keys.
///
/// Build-in data types are created during installation, and Umbraco ensures that the media types are created with the
/// same keys on all installations. This means that you can use these keys to identify media types in your code,
/// without having to rely on the name of the media type, which can be changed by the user.
/// </summary>
public static class UmbracoMediaTypeKeys {

    public static readonly Guid Article = new("a43e3414-9599-4230-a7d3-943a21b20122");

    public static readonly Guid Audio = new("a5ddeee0-8fd8-4cee-a658-6f1fcdb00de3");

    public static readonly Guid File = new("4c52d8ab-54e6-40cd-999c-7a5f24903e4d");

    public static readonly Guid Folder = new("f38bd2d7-65d0-48e6-95dc-87ce06ec2d3d");

    public static readonly Guid Image = new("cc07b313-0843-4aa8-bbda-871c8da728c8");

    public static readonly Guid VectorGraphics = new("c4b1efcf-a9d5-41c4-9621-e9d273b52a9c");

    public static readonly Guid Video = new("f6c515bb-653c-4bdc-821c-987729ebe327");

    /// <summary>
    /// Alias of <see cref="VectorGraphics"/>.
    /// </summary>
    public static readonly Guid Svg = VectorGraphics;

}