using System.Diagnostics.CodeAnalysis;

namespace Skybrud.Essentials.Umbraco.Manifests.Conditions;

public class WorkspaceCondition : Condition {

    public required string Match { get; set; }

    public static WorkspaceCondition Document { get; } = new("Umb.Workspace.Document");

    public static WorkspaceCondition DocumentType { get; } = new("Umb.Workspace.DocumentType");

    public static WorkspaceCondition DataType { get; } = new("Umb.Workspace.DataType");

    public static WorkspaceCondition MediaType { get; } = new("Umb.Workspace.MediaType");

    public static WorkspaceCondition Member { get; } = new("Umb.Workspace.Member");

    public static WorkspaceCondition MemberType { get; } = new("Umb.Workspace.MemberType");

    public static WorkspaceCondition User { get; } = new("Umb.Workspace.User");

    public WorkspaceCondition() : base("Umb.Condition.WorkspaceAlias") { }

    [SetsRequiredMembers]
    public WorkspaceCondition(string match) : base("Umb.Condition.WorkspaceAlias") {
        Match = match;
    }

}