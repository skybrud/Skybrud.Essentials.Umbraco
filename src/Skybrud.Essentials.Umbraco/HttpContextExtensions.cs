using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Umbraco.Extensions;

namespace Skybrud.Essentials.Umbraco;

/// <summary>
/// Static class with various Umbraco related extension methods for <see cref="HttpContext"/>.
/// </summary>
public static class HttpContextExtensions {

    /// <summary>
    /// Returns whether the user is currently logged in to the backoffice.
    /// </summary>
    /// <param name="context">The current HTTP context.</param>
    /// <returns><see langword="false"/> if the user is logged in to the backoffice; otherwise, <see langword="false"/>.</returns>
    public static bool IsBackOfficeAuthenticated(this HttpContext? context) {
        return IsBackOfficeAuthenticated(context, out _);
    }

    /// <summary>
    /// Returns whether the user is currently logged in to the backoffice.
    /// </summary>
    /// <param name="context">The current HTTP context.</param>
    /// <param name="identity">When this method returns, holds the <see cref="ClaimsIdentity"/> of the authenticated backoffice user if successful; otherwise, <see langword="false"/>.</param>
    /// <returns><see langword="false"/> if the user is logged in to the backoffice; otherwise, <see langword="false"/>.</returns>
    public static bool IsBackOfficeAuthenticated(this HttpContext? context, [NotNullWhen(true)] out ClaimsIdentity? identity) {

        // Check whether a backoffice identity is already available at this point - eg. for a backoffice request
        if (TryGetBackOfficeIdentity(context, out identity)) return true;

        // Try to authenticate the user
        AddBackOfficeIdentityIfAvailable(context);

        // Now try to get the backoffice identity again
        return TryGetBackOfficeIdentity(context, out identity);

    }

    /// <summary>
    /// Attempts to authenticate the user with the backoffice given that a backoffice cookie is available.
    /// </summary>
    /// <param name="context">The current HTTP context.</param>
    private static void AddBackOfficeIdentityIfAvailable(HttpContext? context) {

        // Get the current cookie options for the backoffice
        CookieAuthenticationOptions? cookieOptions = context?.RequestServices
            .GetRequiredService<IOptionsSnapshot<CookieAuthenticationOptions>>()
            .Get(global::Umbraco.Cms.Core.Constants.Security.BackOfficeAuthenticationType);

        // This should be available, but we'd like this method to fail silent if not present
        if (cookieOptions == null) return;

        // Get the cookie value
        if (!context!.Request.Cookies.TryGetValue(cookieOptions.Cookie.Name!, out string? cookie)) return;

        // Unprotected the cookie value
        AuthenticationTicket? unprotected = cookieOptions.TicketDataFormat.Unprotect(cookie);

        // Get the backoffice identity
        ClaimsIdentity? backOfficeIdentity = unprotected?.Principal.GetUmbracoIdentity();
        if (backOfficeIdentity == null) return;

        // Add the identity to the user's list of identities
        context.User.AddIdentity(backOfficeIdentity);

    }

    private static bool TryGetBackOfficeIdentity(HttpContext? context, [NotNullWhen(true)] out ClaimsIdentity? identity) {

        // Get the backoffice identity from the current user
        identity = context?.User.Identities
            .FirstOrDefault(c => c.AuthenticationType == global::Umbraco.Cms.Core.Constants.Security.BackOfficeAuthenticationType);

        // Return whether the user is authenticated
        return identity is { IsAuthenticated: true };

    }

}