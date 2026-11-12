using System.Collections.Generic;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Blocks;

/// <summary>
/// Represents an Umbraco block action extension.
/// </summary>
/// <remarks>
/// A block action extension adds a custom action to blocks in an Umbraco block editor.
/// </remarks>
public class BlockActionExtension : ConditionalExtension, IElementAndApiExtension {

    /// <summary>
    /// The default kind of block action extension.
    /// </summary>
    public const string DefaultKind = "default";

    /// <summary>
    /// Gets the extension type.
    /// </summary>
    /// <remarks>
    /// The value is always <c>blockAction</c>.
    /// </remarks>
    public override string Type => "blockAction";

    /// <summary>
    /// Gets the aliases of the block editors for which the action is available.
    /// </summary>
    public IReadOnlyList<string> ForBlockEditor { get; init; } = [];

    /// <summary>
    /// Gets the aliases of the block content types for which the action is available.
    /// </summary>
    public IReadOnlyList<string> ForContentTypeAlias { get; init; } = [];

    /// <summary>
    /// Gets the path to the JavaScript module that implements the block action.
    /// </summary>
    public string? Js { get; init; }

    /// <summary>
    /// Gets the path to the JavaScript module that exports the API for the block action.
    /// </summary>
    public string? Api { get; init; }

    /// <summary>
    /// Gets the path to the JavaScript module that exports the element for the block action.
    /// </summary>
    public string? Element { get; init; }

    /// <summary>
    /// Gets the name of the custom element used by the block action.
    /// </summary>
    public string? ElementName { get; init; }

    /// <summary>
    /// Gets the metadata associated with the block action.
    /// </summary>
    public required BlockActionMeta Meta { get; init; }

}