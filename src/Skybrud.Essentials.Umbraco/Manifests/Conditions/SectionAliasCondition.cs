using System;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Essentials.Umbraco.Manifests.Conditions;

public class SectionAliasCondition : Condition {

    #region Properties

    public static SectionAliasCondition Content { get; } = new("Umb.Section.Content");

    public static SectionAliasCondition Media { get; } = new("Umb.Section.Media");

    public static SectionAliasCondition Settings { get; } = new("Umb.Section.Settings");

    /// <summary>
    /// The section that this extension should be available in.
    /// </summary>
    public string? Match { get; }

    /// <summary>
    /// One or more sections that this extension should be available in.
    /// </summary>
    public IReadOnlyList<string>? OneOf { get; }

    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="SectionAliasCondition"/> class with the section alias to match.
    /// </summary>
    /// <remarks>Throws <see cref="ArgumentException"/> when <paramref name="match"/> is null, empty, or
    /// whitespace.</remarks>
    /// <param name="match">Section alias to match. Cannot be null, empty, or whitespace.</param>
    public SectionAliasCondition(string match) : base(ConditionAliases.SectionAlias) {
        ArgumentException.ThrowIfNullOrWhiteSpace(match);
        Match = match;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SectionAliasCondition"/> class with the specified section aliases.
    /// </summary>
    /// <param name="oneOf">A collection of section aliases to match. Must contain at least one alias.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="oneOf"/> is empty.</exception>
    public SectionAliasCondition(IEnumerable<string> oneOf) : base(ConditionAliases.SectionAlias) {
        ArgumentNullException.ThrowIfNull(oneOf);
        OneOf = oneOf.ToArray();
        if (OneOf.Count == 0) throw new ArgumentException("At least one section alias must be specified.", nameof(oneOf));
    }

}