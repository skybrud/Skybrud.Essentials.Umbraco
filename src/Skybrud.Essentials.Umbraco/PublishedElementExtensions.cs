using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Skybrud.Essentials.Strings;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Skybrud.Essentials.Umbraco {

    /// <summary>
    /// Static class with various extension methods for <see cref="IPublishedElement"/>.
    /// </summary>
    public static class PublishedElementExtensions {

        /// <summary>
        /// Returns the GUID value of the property with the specified <paramref name="alias"/>, or <see cref="Guid.Empty"/> if a matching property could not be found or it's value converted to a <see cref="Guid"/> instance.
        /// </summary>
        /// <param name="element">The element holding the property.</param>
        /// <param name="alias">The alias of the property.</param>
        /// <returns>An instance of <see cref="Guid"/>.</returns>
        public static Guid GetGuid(this IPublishedElement element, string alias) {
            return element.Value(alias) switch {
                Guid guid => guid,
                string str => Guid.TryParse(str, out Guid g) ? g : Guid.Empty,
                _ => Guid.Empty
            };
        }

        /// <summary>
        /// Returns the GUID value of the property with the specified <paramref name="alias"/>, or <see langword="null"/> if a matching property could not be found or it's value converted to a <see cref="Guid"/> instance.
        /// </summary>
        /// <param name="element">The element holding the property.</param>
        /// <param name="alias">The alias of the property.</param>
        /// <returns>An instance of <see cref="Guid"/> if successful; otherwise, <see langword="null"/>.</returns>
        public static Guid? GetGuidOrNull(this IPublishedElement element, string alias) {
            return element.Value(alias) switch {
                Guid guid => guid,
                string str => (Guid.TryParse(str, out Guid g) ? g : null),
                _ => null
            };
        }

        /// <summary>
        /// Returns the string value of the property with the specified <paramref name="alias"/>, or <see langword="null"/> if a matching property could not be found or it's value converted to a <see cref="string"/> instance.
        /// </summary>
        /// <param name="element">The element holding the property.</param>
        /// <param name="alias">The alias of the property.</param>
        /// <returns>An instance of <see cref="string"/> if successful; otherwise, <see langword="null"/>.</returns>
        public static string? GetString(this IPublishedElement element, string alias) {
            return element?.Value<string>(alias);
        }

        /// <summary>
        /// Returns the string value of the property with the specified <paramref name="alias"/>, or <paramref name="fallback"/> if a matching property could not be found or it's value converted to a <see cref="string"/> instance.
        /// </summary>
        /// <param name="element">The element holding the property.</param>
        /// <param name="alias">The alias of the property.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>An instance of <see cref="string"/> if successful; otherwise, <paramref name="fallback"/>.</returns>
        [return: NotNullIfNotNull("fallback")]
        public static string? GetString(this IPublishedElement element, string alias, string? fallback) {
            return StringUtils.FirstWithValue(element?.Value<string>(alias), fallback);
        }

        /// <summary>
        /// Returns a <see cref="DateTime"/> value of the property with the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="element">The element holding the property.</param>
        /// <param name="alias">The alias of the property.</param>
        /// <returns>An instance of <see cref="DateTime"/>.</returns>
        public static DateTime GetDateTime(this IPublishedElement element, string alias) {

            // Get the property value
            DateTime dt = element.Value<DateTime>(alias);

            // Correct for wrong time zone as Umbraco returns the DateTime as "Utc" even though it is actually "Local"
            return new DateTime(dt.Ticks, DateTimeKind.Local);

        }

        /// <summary>
        /// Attempts to get the <see cref="DateTime"/> value of the property with the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="element">The element holding the property.</param>
        /// <param name="alias">The alias of the property.</param>
        /// <param name="value">When this method returns, holds the <see cref="DateTime"/> value if successful; otherwise <see cref="DateTime.MinValue"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetDateTime(this IPublishedElement element, string alias, out DateTime value) {

            if (element.HasValue(alias) && element.Value(alias) is DateTime dt) {

                // Correct for wrong time zone as Umbraco returns the DateTime as "Utc" even though it is actually "Local"
                value = new DateTime(dt.Ticks, DateTimeKind.Local);

                return true;

            }

            value = default;
            return false;

        }

    }
}