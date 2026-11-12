using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Skybrud.Essentials.Umbraco;

/// <summary>
/// Static class with various Umbraco related extension methods for <see cref="HttpContext"/>.
/// </summary>
[Obsolete("Use the 'Skybrud.Essentials.Umbraco.Http.HttpContextExtensions' class instead.")]
public static class HttpContextExtensions {

    /// <summary>
    /// Returns whether the user is currently logged in to the backoffice.
    /// </summary>
    /// <param name="context">The current HTTP context.</param>
    /// <returns><see langword="false"/> if the user is logged in to the backoffice; otherwise, <see langword="false"/>.</returns>
    [Obsolete("Use the 'Skybrud.Essentials.Umbraco.Http.HttpContextExtensions.IsBackOfficeAuthenticated' method instead.")]
    public static bool IsBackOfficeAuthenticated(this HttpContext? context) {
        return Http.HttpContextExtensions.IsBackOfficeAuthenticated(context);
    }

    /// <summary>
    /// Returns whether the user is currently logged in to the backoffice.
    /// </summary>
    /// <param name="context">The current HTTP context.</param>
    /// <param name="identity">When this method returns, holds the <see cref="ClaimsIdentity"/> of the authenticated backoffice user if successful; otherwise, <see langword="false"/>.</param>
    /// <returns><see langword="true"/> if the user is logged in to the backoffice; otherwise, <see langword="false"/>.</returns>
    [Obsolete("Use the 'Skybrud.Essentials.Umbraco.Http.HttpContextExtensions.IsBackOfficeAuthenticated' method instead.")]
    public static bool IsBackOfficeAuthenticated(this HttpContext? context, [NotNullWhen(true)] out ClaimsIdentity? identity) {
        return Http.HttpContextExtensions.IsBackOfficeAuthenticated(context, out identity);
    }

}