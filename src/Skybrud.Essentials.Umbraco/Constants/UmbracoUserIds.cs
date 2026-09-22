using System;

namespace Skybrud.Essentials.Umbraco.Constants;

/// <summary>
/// Provides well-known integer identifiers for built-in Umbraco users.
/// </summary>
/// <remarks>
/// <para>
/// Prefer using the corresponding key from <see cref="UmbracoUserKeys"/>
/// whenever an API supports identifying users by <see cref="Guid"/>.
/// </para>
/// <para>
/// Integer identifiers are provided for APIs that still require a user ID
/// instead of a user key.
/// </para>
/// <para>
/// See the
/// <see href="https://apidocs.umbraco.com/v17/csharp/api/Umbraco.Cms.Core.Constants.Security.html">
/// Umbraco security constants
/// </see>
/// for the corresponding Umbraco constants.
/// </para>
/// </remarks>
public static class UmbracoUserIds {

    /// <summary>
    /// The integer identifier of the Umbraco super user.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The super user has an ID of <c>-1</c>.
    /// </para>
    /// <para>
    /// Umbraco's corresponding <c>Constants.Security.SuperUserId</c> constant is
    /// obsolete in favor of <c>Constants.Security.SuperUserKey</c>. This constant
    /// is provided for APIs that still require an integer user ID.
    /// </para>
    /// <para>
    /// Prefer <see cref="UmbracoUserKeys.SuperUser"/> when the API supports
    /// identifying the user by key.
    /// </para>
    /// </remarks>
    /// <seealso cref="UmbracoUserKeys.SuperUser"/>
    public const int SuperUser = -1;

}