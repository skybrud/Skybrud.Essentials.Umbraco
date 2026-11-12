using System;
using Umbraco.Cms.Core.Cache;

namespace Skybrud.Essentials.Umbraco;

/// <summary>
/// Static class with various extension methods for <see cref="IAppPolicyCache"/>.
/// </summary>
[Obsolete("Use the extension methods in the Skybrud.Essentials.Umbraco.Caching namespace instead.")]
public static class AppPolicyCacheExtensions {

    /// <summary>
    /// Returns the value of item with the specified <paramref name="key"/>, or <see langword="default"/> if a matching item wasn't found.
    /// </summary>
    /// <typeparam name="T">The type of the cached item.</typeparam>
    /// <param name="cache">The cache.</param>
    /// <param name="key">The key of the cached item.</param>
    /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, <see langword="default"/>.</returns>
    [Obsolete("Use the 'Skybrud.Essentials.Umbraco.Caching.AppPolicyCacheExtensions.Get' method instead.")]
    public static T? Get<T>(this IAppPolicyCache cache, string key) {
        return Caching.AppPolicyCacheExtensions.Get<T>(cache, key);
    }

    /// <summary>
    /// Returns the value of item with the specified <paramref name="key"/>, or <see langword="default"/> if a matching item wasn't found.
    /// </summary>
    /// <typeparam name="T">The type of the cached item.</typeparam>
    /// <param name="cache">The cache.</param>
    /// <param name="key">The key of the item.</param>
    /// <param name="factory">A factory function that can create the item.</param>
    /// <param name="timeout">An optional cache timeout.</param>
    /// <param name="isSliding">An optional value indicating whether the cache timeout is sliding (default is <see langword="false"/>).</param>
    /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, <see langword="default"/>.</returns>
    [Obsolete("Use the 'Skybrud.Essentials.Umbraco.Caching.AppPolicyCacheExtensions.Get' method instead.")]
    public static T? Get<T>(this IAppPolicyCache cache, string key, Func<object?> factory, TimeSpan? timeout = null, bool isSliding = false) {
        return Caching.AppPolicyCacheExtensions.Get<T>(cache, key, factory, timeout, isSliding);
    }

}