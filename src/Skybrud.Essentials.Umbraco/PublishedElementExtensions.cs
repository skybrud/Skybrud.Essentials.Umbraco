using System;
using System.Diagnostics.CodeAnalysis;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Strings.Extensions;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Skybrud.Essentials.Umbraco {

    /// <summary>
    /// Static class with various extension methods for <see cref="IPublishedElement"/>.
    /// </summary>
    public static class PublishedElementExtensions {

        #region Boolean

        /// <summary>
        /// Returns the boolean value of the property with the specified <paramref name="alias"/>, or <see langwird="false"/> if a matching property could not be found or it's value converted to a <see cref="bool"/> instance.
        /// </summary>
        /// <param name="element">The element holding the property.</param>
        /// <param name="alias">The alias of the property.</param>
        /// <returns>An instance of <see cref="bool"/>.</returns>
        public static bool GetBoolean(this IPublishedElement element, string alias) {
            return element.Value(alias) switch {
                bool boolean => boolean,
                int number => number == 1,
                string str => StringUtils.ParseBoolean(str),
                _ => false
            };
        }

        /// <summary>
        /// Returns the boolean value of the property with the specified <paramref name="alias"/>, or <see langword="null"/> if a matching property could not be found or it's value converted to a <see cref="bool"/> instance.
        /// </summary>
        /// <param name="element">The element holding the property.</param>
        /// <param name="alias">The alias of the property.</param>
        /// <returns>An instance of <see cref="bool"/> if successful; otherwise, <see langword="null"/>.</returns>
        public static bool? GetBooleanOrNull(this IPublishedElement? element, string alias) {
            return element?.Value(alias) switch {
                bool boolean => boolean,
                int number => number == 1,
                string str => StringUtils.ParseBooleanOrNull(str),
                _ => null
            };
        }

        /// <summary>
        /// Attempts to get a boolean value from the property with the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="element">The element holding the property.</param>
        /// <param name="alias">The alias of the property.</param>
        /// <param name="result">When this method returns, holds the <see cref="bool"/> value if successful; otherwise, <see langword="false"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetBoolean(this IPublishedElement? element, string alias, out bool result) {
            if (element.TryGetBoolean(alias, out bool? guid)) {
                result = guid.Value;
                return true;
            }
            result = default;
            return false;
        }

        /// <summary>
        /// Attempts to get a boolean value from the property with the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="element">The element holding the property.</param>
        /// <param name="alias">The alias of the property.</param>
        /// <param name="result">When this method returns, holds the <see cref="bool"/> value if successful; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetBoolean(this IPublishedElement? element, string alias, [NotNullWhen(true)] out bool? result) {

            if (element is not null && element.HasProperty(alias)) {
                result = element.GetBooleanOrNull(alias);
                return result is not null;
            }

            result = null;
            return false;

        }

        #endregion

        #region Guid

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
        public static Guid? GetGuidOrNull(this IPublishedElement? element, string alias) {
            return element?.Value(alias) switch {
                Guid guid => guid,
                string str => (Guid.TryParse(str, out Guid g) ? g : null),
                _ => null
            };
        }

        /// <summary>
        /// Attempts to get a GUID value from the property with the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="element">The element holding the property.</param>
        /// <param name="alias">The alias of the property.</param>
        /// <param name="result">When this method returns, holds <see cref="Guid"/> value if successful; otherwise, <see cref="Guid.Empty"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetGuid(this IPublishedElement? element, string alias, out Guid result) {
            if (element.TryGetGuid(alias, out Guid? guid)) {
                result = guid.Value;
                return true;
            }
            result = Guid.Empty;
            return false;
        }

        /// <summary>
        /// Attempts to get a GUID value from the property with the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="element">The element holding the property.</param>
        /// <param name="alias">The alias of the property.</param>
        /// <param name="result">When this method returns, holds <see cref="Guid"/> value if successful; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetGuid(this IPublishedElement? element, string alias, [NotNullWhen(true)] out Guid? result) {

            if (element is not null && element.HasProperty(alias)) {
                result = element.GetGuidOrNull(alias);
                return result is not null;
            }

            result = null;
            return false;

        }

        #endregion

        #region String

        /// <summary>
        /// Returns the string value of the property with the specified <paramref name="alias"/>, or <see langword="null"/> if a matching property could not be found or it's value converted to a <see cref="string"/> instance.
        /// </summary>
        /// <param name="element">The element holding the property.</param>
        /// <param name="alias">The alias of the property.</param>
        /// <returns>An instance of <see cref="string"/> if successful; otherwise, <see langword="null"/>.</returns>
        public static string? GetString(this IPublishedElement? element, string alias) {
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
        public static string? GetString(this IPublishedElement? element, string alias, string? fallback) {
            string? value = element?.Value<string>(alias);
            return string.IsNullOrWhiteSpace(value) ? fallback : value;
        }

        /// <summary>
        /// Attempts to get a string value from the property with the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="element">The element holding the property.</param>
        /// <param name="alias">The alias of the property.</param>
        /// <param name="result">When this method returns, holds the string value if successful; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetString(this IPublishedElement? element, string alias, [NotNullWhen(true)] out string? result) {

            if (element is not null && element.HasProperty(alias)) {
                result = element.GetString(alias).NullIfWhiteSpace();
                return result is not null;
            }

            result = null;
            return false;

        }

        #endregion

        #region DateTime

        /// <summary>
        /// Returns a <see cref="DateTime"/> value of the property with the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="element">The element holding the property.</param>
        /// <param name="alias">The alias of the property.</param>
        /// <returns>An instance of <see cref="DateTime"/>.</returns>
        public static DateTime GetDateTime(this IPublishedElement? element, string alias) {

            // Get the property value
            DateTime? dt = element?.Value<DateTime>(alias);

            // Correct for wrong time zone as Umbraco returns the DateTime as "Utc" even though it is actually "Local"
            return dt is null ? DateTime.MinValue : new DateTime(dt.Value.Ticks, DateTimeKind.Local);

        }

        /// <summary>
        /// Returns a <see cref="DateTime"/> value of the property with the specified <paramref name="alias"/>, or
        /// <see langword="null"/> if the type of the property value doesn't match a <see cref="DateTime"/>.
        /// </summary>
        /// <param name="element">The element holding the property.</param>
        /// <param name="alias">The alias of the property.</param>
        /// <returns>An instance of <see cref="DateTime"/> if successful; otherwise, <see langword="null"/>.</returns>
        public static DateTime? GetDateTimeOrNull(this IPublishedElement? element, string alias) {

            // Get the property value
            DateTime? dt = element?.Value<DateTime>(alias);

            // Correct for wrong time zone as Umbraco returns the DateTime as "Utc" even though it is actually "Local"
            return dt is null ? null : new DateTime(dt.Value.Ticks, DateTimeKind.Local);

        }

        /// <summary>
        /// Attempts to get the <see cref="DateTime"/> value of the property with the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="element">The element holding the property.</param>
        /// <param name="alias">The alias of the property.</param>
        /// <param name="value">When this method returns, holds the <see cref="DateTime"/> value if successful; otherwise <see cref="DateTime.MinValue"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetDateTime(this IPublishedElement? element, string alias, out DateTime value) {

            if (element is not null && element.HasValue(alias) && element.Value(alias) is DateTime dt) {

                // Correct for wrong time zone as Umbraco returns the DateTime as "Utc" even though it is actually "Local"
                value = new DateTime(dt.Ticks, DateTimeKind.Local);

                return true;

            }

            value = default;
            return false;

        }

        /// <summary>
        /// Attempts to get the <see cref="DateTime"/> value of the property with the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="element">The element holding the property.</param>
        /// <param name="alias">The alias of the property.</param>
        /// <param name="value">When this method returns, holds the <see cref="DateTime"/> value if successful; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetDateTime(this IPublishedElement? element, string alias, out DateTime? value) {

            if (element is not null && element.HasValue(alias) && element.Value(alias) is DateTime dt) {

                // Correct for wrong time zone as Umbraco returns the DateTime as "Utc" even though it is actually "Local"
                value = new DateTime(dt.Ticks, DateTimeKind.Local);

                return true;

            }

            value = null;
            return false;

        }

        #endregion

        /// <summary>
        /// Attempts to get the value of type <typeparamref name="T"/> from the property with the specified <paramref name="propertyAlias"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="element">The <see cref="IPublishedElement"/> holding the property.</param>
        /// <param name="propertyAlias">The alias of the property.</param>
        /// <param name="result">When this method returns, holds the <typeparamref name="T"/> value of the property if successful; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetValue<T>(this IPublishedElement? element, string propertyAlias, out T? result) {

            result = default;

            if (element == null) return false;
            if (!element.HasValue(propertyAlias)) return false;

            result = element.Value<T>(propertyAlias);
            return result != null;

        }

    }

}