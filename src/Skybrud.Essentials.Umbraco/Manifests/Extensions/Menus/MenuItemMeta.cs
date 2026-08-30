using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Menus;

/// <summary>
/// Represents metadata associated with an Umbraco menu item extension.
/// </summary>
public class MenuItemMeta {

    /// <summary>
    /// Gets or sets the label displayed for the menu item in the Umbraco
    /// backoffice.
    /// </summary>
    public required string Label { get; set; }

    /// <summary>
    /// Gets or sets the aliases of the menus in which the menu item is displayed.
    /// </summary>
    public required List<string> Menus { get; set; }

    /// <summary>
    /// Gets or sets the optional entity type associated with the menu item.
    /// </summary>
    /// <remarks>
    /// When specified, Umbraco can associate the menu item with the corresponding
    /// workspace and registered entity actions.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? EntityType { get; set; }

    /// <summary>
    /// Gets or sets the optional icon displayed for the menu item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Icon { get; set; }

}