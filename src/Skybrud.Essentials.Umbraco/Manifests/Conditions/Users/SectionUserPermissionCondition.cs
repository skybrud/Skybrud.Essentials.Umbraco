using System;

namespace Skybrud.Essentials.Umbraco.Manifests.Conditions.Users;

public class SectionUserPermissionCondition : Condition {

    #region Properties

    public static SectionUserPermissionCondition Content { get; } = new("Umb.Section.Content");

    public static SectionUserPermissionCondition Media { get; } = new("Umb.Section.Media");

    public static SectionUserPermissionCondition Settings { get; } = new("Umb.Section.Settings");

    public static SectionUserPermissionCondition Users { get; } = new("Umb.Section.Users");

    public string? Match { get; }

    #endregion

    public SectionUserPermissionCondition(string match) : base(ConditionAliases.SectionUserPermission) {
        ArgumentException.ThrowIfNullOrWhiteSpace(match);
        Match = match;
    }

}