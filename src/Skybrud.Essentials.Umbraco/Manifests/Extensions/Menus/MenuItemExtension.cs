using System.Text.Json.Serialization;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Menus;

/// <summary>
/// Represents a menu item extension declared by an Umbraco package manifest.
/// </summary>
public class MenuItemExtension : ConditionalExtension, IElementExtension {

    /// <summary>
    /// Gets the type of the extension.
    /// </summary>
    /// <remarks>
    /// The value is always <c>menuItem</c>.
    /// </remarks>
    public override string Type => "menuItem";

    /// <summary>
    /// Gets or sets the location of the JavaScript module that provides the
    /// menu item element.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Element { get; set; }

    /// <summary>
    /// Gets or sets the optional name of the custom element that provides the
    /// menu item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ElementName { get; set; }

    /// <summary>
    /// Gets or sets the location of the JavaScript module associated with the
    /// menu item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Js { get; set; }

    /// <summary>
    /// Gets or sets the metadata associated with the menu item.
    /// </summary>
    public required MenuItemMeta Meta { get; set; }

}