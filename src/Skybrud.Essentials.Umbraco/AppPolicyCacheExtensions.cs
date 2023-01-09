using System;
using Umbraco.Cms.Core.Cache;

namespace Skybrud.Essentials.Umbraco {

    /// <summary>
    /// Static class with various extension methods for <see cref="IAppPolicyCache"/>.
    /// </summary>
    public static class AppPolicyCacheExtensions {

        /// <summary>
        /// Returns the value of item with the specified <paramref name="key"/>, or <see langword="default"/> if a matching item wasn't found.
        /// </summary>
        /// <typeparam name="T">The type of the cached item.</typeparam>
        /// <param name="cache">The cache.</param>
        /// <param name="key">The key of the cached item.</param>
        /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, <see langword="default"/>.</returns>
        public static T? Get<T>(this IAppPolicyCache cache, string key) {
            return cache.Get(key) is T value ? value : default;
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
        /// <param name="dependentFiles">Files the cache entry depends on.</param>
        /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, <see langword="default"/>.</returns>
        public static T? Get<T>(this IAppPolicyCache cache, string key, Func<object?> factory, TimeSpan? timeout = null, bool isSliding = false, string[]? dependentFiles = null) {
            return cache.Get(key, factory, timeout, isSliding, dependentFiles) is T value ? value : default;
        }

    }

}