using System.Diagnostics.CodeAnalysis;

namespace Skybrud.Essentials.Umbraco.Manifests.Conditions;

public class UserGroupCondition : Condition {

    // Umbraco may not have a schema for this? ¯\_(ツ)_/¯

    public required string Match { get; set; }

    public static UserGroupCondition Admin { get; } = new("Umb.UserGroup.Admin");

    public UserGroupCondition() : base(ConditionAliases.UserGroup) { }

    [SetsRequiredMembers]
    public UserGroupCondition(string match) : base(ConditionAliases.UserGroup) {
        Match = match;
    }

}