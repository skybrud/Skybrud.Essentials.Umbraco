namespace Skybrud.Essentials.Umbraco.Constants;

/// <summary>
/// Static class with constants for various Umbraco entity types.
/// </summary>
public static class UmbracoEntityTypes {

    /// <summary>
    /// The entity type for Umbraco documents.
    /// </summary>
    public const string Document = global::Umbraco.Cms.Core.Constants.UdiEntityType.Document;

    /// <summary>
    /// The entity type for Umbraco document types.
    /// </summary>
    public const string DocumentType = global::Umbraco.Cms.Core.Constants.UdiEntityType.DocumentType;

    /// <summary>
    /// Alias of <see cref="Document"/>.
    /// </summary>
    public const string Content = Document;

    /// <summary>
    /// Alias of <see cref="DocumentType"/>.
    /// </summary>
    public const string ContentType = DocumentType;

    /// <summary>
    /// The entity type for Umbraco data types.
    /// </summary>
    public const string DataType = global::Umbraco.Cms.Core.Constants.UdiEntityType.DataType;

    /// <summary>
    /// The entity type for Umbraco data type containers.
    /// </summary>
    public const string DataTypeContainer = global::Umbraco.Cms.Core.Constants.UdiEntityType.DataTypeContainer;

    /// <summary>
    /// The entity type for Umbraco media items.
    /// </summary>
    public const string Media = global::Umbraco.Cms.Core.Constants.UdiEntityType.Media;

    /// <summary>
    /// The entity type for Umbraco media types.
    /// </summary>
    public const string MediaType = global::Umbraco.Cms.Core.Constants.UdiEntityType.MediaType;

    /// <summary>
    /// The entity type for Umbraco media type containers.
    /// </summary>
    public const string MediaTypeContainer = global::Umbraco.Cms.Core.Constants.UdiEntityType.MediaTypeContainer;

    /// <summary>
    /// The entity type for Umbraco members.
    /// </summary>
    public const string Member = global::Umbraco.Cms.Core.Constants.UdiEntityType.Member;

    /// <summary>
    /// The entity type for Umbraco member groups.
    /// </summary>
    public const string MemberGroup = global::Umbraco.Cms.Core.Constants.UdiEntityType.MemberGroup;

}