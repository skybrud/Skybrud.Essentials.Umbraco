using System.Collections.Generic;
using System.Text.Json.Serialization;
using Skybrud.Essentials.Umbraco.Manifests.Conditions;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Menus;

/// <summary>
/// Represents a menu item extension declared by an Umbraco package manifest.
/// </summary>
public class MenuItemExtension : IExtension {

    /// <summary>
    /// Gets the type of the extension.
    /// </summary>
    /// <remarks>
    /// The value is always <c>menuItem</c>.
    /// </remarks>
    public string Type => "menuItem";

    /// <summary>
    /// Gets or sets the unique alias of the extension.
    /// </summary>
    public required string Alias { get; set; }

    /// <summary>
    /// Gets or sets the human-readable name of the extension.
    /// </summary>
    public required string Name { get; set; }

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
    /// Gets or sets the optional kind of the menu item.
    /// </summary>
    /// <remarks>
    /// Umbraco provides built-in kinds such as <c>link</c>,
    /// <c>action</c>, and <c>tree</c>.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Kind { get; set; }

    /// <summary>
    /// Gets or sets the weight used to determine the ordering of the menu item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Weight { get; set; }

    /// <summary>
    /// Gets or sets the metadata associated with the menu item.
    /// </summary>
    public required MenuItemMeta Meta { get; set; }

    /// <summary>
    /// Gets or sets the conditions that determine when the menu item is available.
    /// </summary>
    [JsonPropertyName("conditions")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<ICondition> Conditions { get; set; } = [];

}