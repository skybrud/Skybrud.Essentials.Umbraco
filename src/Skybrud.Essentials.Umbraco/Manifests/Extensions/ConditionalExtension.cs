using System.Collections.Generic;
using Skybrud.Essentials.Umbraco.Manifests.Conditions;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions;

/// <summary>
/// Represents an Umbraco extension manifest that supports dynamic conditions.
/// </summary>
public abstract class ConditionalExtension : Extension {

    /// <summary>
    /// Gets the conditions that determine when the extension is available.
    /// </summary>
    public IReadOnlyList<ICondition> Conditions { get; init; } = [];

    /// <summary>
    /// Gets the aliases of extensions that this extension overwrites.
    /// </summary>
    public IReadOnlyList<string> Overwrites { get; init; } = [];

}