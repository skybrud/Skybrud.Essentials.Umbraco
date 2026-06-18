using System.Diagnostics.CodeAnalysis;

namespace Skybrud.Essentials.Umbraco.Manifests.Conditions;

public class UserGroupCondition : Condition {

    public required string Match { get; set; }

    public static UserGroupCondition Admin { get; } = new("Umb.UserGroup.Admin");

    public UserGroupCondition() : base("Umb.Condition.UserGroup") { }

    [SetsRequiredMembers]
    public UserGroupCondition(string match) : base("Umb.Condition.UserGroup") {
        Match = match;
    }

}