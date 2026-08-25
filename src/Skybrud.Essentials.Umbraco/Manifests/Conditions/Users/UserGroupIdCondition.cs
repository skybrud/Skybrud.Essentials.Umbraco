using System;
using System.Collections.Generic;
using Skybrud.Essentials.Umbraco.Constants;

namespace Skybrud.Essentials.Umbraco.Manifests.Conditions.Users;

public class UserGroupIdCondition : ICondition {

    public string Alias => ConditionAliases.UserGroupId;

    public static readonly UserGroupIdCondition Admin = new(UmbracoUserGroupKeys.Admin);

    public static readonly UserGroupIdCondition Editors = new(UmbracoUserGroupKeys.Editors);

    public static readonly UserGroupIdCondition SensitiveData = new(UmbracoUserGroupKeys.SensitiveData);

    public static readonly UserGroupIdCondition Translators = new(UmbracoUserGroupKeys.Translators);

    public static readonly UserGroupIdCondition Writers = new(UmbracoUserGroupKeys.Writers);

    public HashSet<Guid>? AllOf { get; set; }

    public Guid? Match { get; set; }

    public HashSet<Guid>? NoneOf { get; set; }

    public HashSet<Guid>? OneOf { get; set; }

    public UserGroupIdCondition(Guid match) {
        Match = match;
    }

}