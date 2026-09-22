using System;

namespace Skybrud.Essentials.Umbraco.Constants;

/// <summary>
/// Provides well-known keys for built-in Umbraco users.
/// </summary>
/// <remarks>
/// <para>
/// User keys should generally be preferred over the corresponding integer
/// identifiers in <see cref="UmbracoUserIds"/>.
/// </para>
/// <para>
/// See the
/// <see href="https://apidocs.umbraco.com/v17/csharp/api/Umbraco.Cms.Core.Constants.Security.html">
/// Umbraco security constants
/// </see>
/// for the corresponding Umbraco constants.
/// </para>
/// </remarks>
public static class UmbracoUserKeys {

    /// <summary>
    /// The unique key of the Umbraco super user.
    /// </summary>
    /// <remarks>
    /// This value corresponds to
    /// <see cref="global::Umbraco.Cms.Core.Constants.Security.SuperUserKey"/>.
    /// </remarks>
    /// <seealso cref="UmbracoUserIds.SuperUser"/>
    public static readonly Guid SuperUser = global::Umbraco.Cms.Core.Constants.Security.SuperUserKey;

}