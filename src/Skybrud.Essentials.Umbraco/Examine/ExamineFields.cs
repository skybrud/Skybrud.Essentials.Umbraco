namespace Skybrud.Essentials.Umbraco.Examine;

/// <summary>
/// Class with constants for typical fields in Examine.
/// </summary>
public static class ExamineFields {

    /// <summary>
    /// Gets the key of the field indicating the index type.
    /// </summary>
    public const string IndexType = "__IndexType";

    /// <summary>
    /// Gets the key of the field with the key of the node.
    /// </summary>
    public const string Key = "__Key";

    /// <summary>
    /// Gets the key of the field with the numeric ID of the node.
    /// </summary>
    public const string NodeId = "__NodeId";

    /// <summary>
    /// Gets the key of the field with the name of the node.
    /// </summary>
    public const string NodeName = "nodeName";

    /// <summary>
    /// Gets the key of the field indicating the node type alias of the node.
    /// </summary>
    public const string NodeTypeAlias = "__NodeTypeAlias";

    /// <summary>
    /// Gets the key of the field indicating the node's path.
    /// </summary>
    public const string Path = "path";

    /// <summary>
    /// Gets the key of the field holding a search-friendly version of the node's path. Notice that this field does not exist in Umbraco by default.
    /// </summary>
    public const string PathSearch = "path_search";

    /// <summary>
    /// Gets the key of the field indicating whether the node should be hidden from navigation. Notice that this field does not exist in Umbraco by default.
    /// </summary>
    public const string HideFromNavigation = global::Umbraco.Cms.Core.Constants.Conventions.Content.NaviHide;

    /// <summary>
    /// Gets the key of the field indicating whether the node should be included in search results. Notice that this field does not exist in Umbraco by default.
    /// </summary>
    public const string HideFromSearch = "hideFromSearch";

    /// <summary>
    /// Gets the key of the field with the teaser of the node.
    /// </summary>
    public const string Teaser = "teaser";

    /// <summary>
    /// Gets the key of the field with the title of the node.
    /// </summary>
    public const string Title = "title";

    /// <summary>
    /// Gets the key of the field indicating the creation date of the node.
    /// </summary>
    public const string CreateDate = "createDate";

    /// <summary>
    /// Gets the key of the field indicating the ID of the user who created the node.
    /// </summary>
    public const string CreatorId = "creatorID";

    /// <summary>
    /// Gets the key of the field indicating the key of the user who created the node. Notice that this field does not exist in Umbraco by default.
    /// </summary>
    public const string CreatorKey = "creatorKey";

    /// <summary>
    /// Gets the key of the field indicating the name of the user who created the node.
    /// </summary>
    public const string CreatorName = "creatorName";

    /// <summary>
    /// Gets the key of the field indicating the ID of the type of the node.
    /// </summary>
    public const string NodeType = "nodeType";

    /// <summary>
    /// Gets the key of the field indicating the ID of the parent of the node.
    /// </summary>
    public const string ParentId = "parentID";

    /// <summary>
    /// Gets the key of the field indicating the update date of the node.
    /// </summary>
    public const string UpdateDate = "updateDate";

    /// <summary>
    /// Gets the key of the field indicating the URL name of the node.
    /// </summary>
    public const string UrlName = global::Umbraco.Cms.Core.Constants.Conventions.Content.UrlName;

    /// <summary>
    /// Gets the key of the field indicating the ID of the user who last updated the node.
    /// </summary>
    public const string WriterId = "writerID";

    /// <summary>
    /// Gets the key of the field indicating the key of the user who last updated the node. Notice that this field does not exist in Umbraco by default.
    /// </summary>
    public const string WriterKey = "writerKey";

    /// <summary>
    /// Gets the key of the field indicating the name of the user who last updated the node.
    /// </summary>
    public const string WriterName = "writerName";

    /// <summary>
    /// Gets the key of the field indicating the boost words of a given page.
    /// </summary>
    public const string BoostWords = "searchBoostWords";

    /// <summary>
    /// Gets the key of the field indicating the content date.
    /// </summary>
    public const string ContentDate = "contentDate";

}