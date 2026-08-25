using System;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Essentials.Umbraco.Manifests.Conditions;

public class WorkspaceAliasCondition : Condition {

    #region Properties

    public static WorkspaceAliasCondition Document { get; } = new("Umb.Workspace.Document");

    public static WorkspaceAliasCondition DocumentType { get; } = new("Umb.Workspace.DocumentType");

    public static WorkspaceAliasCondition DataType { get; } = new("Umb.Workspace.DataType");

    public static WorkspaceAliasCondition Media { get; } = new("Umb.Workspace.Media");

    public static WorkspaceAliasCondition MediaType { get; } = new("Umb.Workspace.MediaType");

    public static WorkspaceAliasCondition Member { get; } = new("Umb.Workspace.Member");

    public static WorkspaceAliasCondition MemberType { get; } = new("Umb.Workspace.MemberType");

    public static WorkspaceAliasCondition User { get; } = new("Umb.Workspace.User");

    /// <summary>
    /// The workspace that this extension should be available in.
    /// </summary>
    public string? Match { get; }

    /// <summary>
    /// One or more workspaces that this extension should be available in.
    /// </summary>
    public IReadOnlyList<string>? OneOf { get; }

    #endregion

    #region Constructors

    public WorkspaceAliasCondition(string match) : base(ConditionAliases.WorkspaceAlias) {
        ArgumentException.ThrowIfNullOrWhiteSpace(match);
        Match = match;
    }

    public WorkspaceAliasCondition(IEnumerable<string> oneOf) : base(ConditionAliases.WorkspaceAlias) {
        ArgumentNullException.ThrowIfNull(oneOf);
        OneOf = oneOf.ToArray();
        if (OneOf.Count == 0) throw new ArgumentException("At least one workspace alias must be specified.", nameof(oneOf));
    }

    #endregion

}