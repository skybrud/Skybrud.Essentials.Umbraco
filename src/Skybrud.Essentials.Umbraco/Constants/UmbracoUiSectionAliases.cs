namespace Skybrud.Essentials.Umbraco.Constants;

/// <summary>
/// Static class with constants for the aliases of the built-in sections in the Umbraco backoffice.
///
/// Umbraco may still use the old section aliases (e.g. "content", "media", etc.) in some places, so these constants
/// are specific for the new Umbraco UI section aliases (e.g. "Umb.Section.Content", "Umb.Section.Media", etc.).
/// </summary>
public class UmbracoUiSectionAliases {

    public const string Content = "Umb.Section.Content";

    public const string Media = "Umb.Section.Media";

    public const string Members = "Umb.Section.Members";

    public const string Settings = "Umb.Section.Settings";

    public const string Packages = "Umb.Section.Packages";

    public const string Translation = "Umb.Section.Translation";

    public const string Users = "Umb.Section.Users";

    public const string Forms = "Umb.Section.Forms";

}