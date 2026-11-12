namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Blocks;

/// <summary>
/// Represents the metadata associated with an Umbraco block action extension.
/// </summary>
public class BlockActionMeta {

    /// <summary>
    /// Gets the label displayed for the block action.
    /// </summary>
    public required string Label { get; init; }

    /// <summary>
    /// Gets the icon displayed for the block action.
    /// </summary>
    public required string Icon { get; init; }

}