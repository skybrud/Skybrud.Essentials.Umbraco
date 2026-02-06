using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models;

namespace Skybrud.Essentials.Umbraco;

/// <summary>
/// Static class with various extension methods for <see cref="IContentBase"/>.
/// </summary>
public static class ContentBaseExtensions {

    /// <summary>
    /// Returns whether a property with the alias <paramref name="propertyAlias"/> exists on <paramref name="content"/>.
    /// </summary>
    /// <param name="content">An instance of <see cref="IContentBase"/> - e.g. <see cref="IContent"/> or <see cref="IMedia"/>.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <returns><see langword="true"/> if the property exists; otherwise, <see langword="false"/>.</returns>
    /// <remarks>
    /// Umbraco doesn't offer a direct way for getting a property with a specific alias from a
    /// <see cref="IContentBase"/> instance, so this method will iterate through all of the <paramref name="content"/>
    /// item's properties until a match is found. This means this method is <c>O(n)</c> in terms of performance and
    /// lookups, and not <c>O(1)</c>.
    /// </remarks>
    public static bool HasProperty(this IContentBase content, string propertyAlias) {
        return content.Properties.FirstOrDefault(x => x.Alias == propertyAlias) != null;
    }

    /// <summary>
    /// Attempts to get the property with the specified <paramref name="propertyAlias"/>.
    /// </summary>
    /// <param name="content">An instance of <see cref="IContentBase"/> - e.g. <see cref="IContent"/> or <see cref="IMedia"/>.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <param name="result">When this method returns, holds an instance of <see cref="IProperty"/> if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the property exists; otherwise, <see langword="false"/>.</returns>
    /// <remarks>
    /// Umbraco doesn't offer a direct way for getting a property with a specific alias from a
    /// <see cref="IContentBase"/> instance, so this method will iterate through all of the <paramref name="content"/>
    /// item's properties until a match is found. This means this method is <c>O(n)</c> in terms of performance and
    /// lookups, and not <c>O(1)</c>.
    /// </remarks>
    public static bool TryGetProperty(this IContentBase content, string propertyAlias, [NotNullWhen(true)] out IProperty? result) {
        result = content.Properties.FirstOrDefault(x => x.Alias == propertyAlias);
        return result != null;
    }

    /// <summary>
    /// Attempts to get the property matching the specified <paramref name="predicate"/>.
    /// </summary>
    /// <param name="content">An instance of <see cref="IContentBase"/> - e.g. <see cref="IContent"/> or <see cref="IMedia"/>.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="result">When this method returns, holds the first instance of <see cref="IProperty"/> element that passes the test specified by <paramref name="predicate"/>, or <see langword="null"/> if not match is found.</param>
    /// <returns><see langword="true"/> if a matching property is found; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetProperty(this IContentBase content, Func<IProperty, bool> predicate, [NotNullWhen(true)] out IProperty? result) {
        result = content.Properties.FirstOrDefault(predicate);
        return result != null;
    }

    /// <summary>
    /// Returns the value of the property with the alias <paramref name="propertyAlias"/> as an instance of <see cref="Udi"/>.
    /// </summary>
    /// <param name="content">An instance of <see cref="IContentBase"/> - e.g. <see cref="IContent"/> or <see cref="IMedia"/>.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <returns>The <see cref="Udi"/> instance if found; otherwise, <see langword="null"/>.</returns>
    public static Udi? GetUdi(this IContentBase content, string propertyAlias) {
        return UdiUtils.TryParse(content.GetValue<string>(propertyAlias), out var result) ? result : null;
    }

    /// <summary>
    /// Returns the value of the property with the alias <paramref name="propertyAlias"/> as a collection of <see cref="Udi"/> instances.
    /// </summary>
    /// <param name="content">An instance of <see cref="IContentBase"/> - e.g. <see cref="IContent"/> or <see cref="IMedia"/>.</param>
    /// <param name="propertyAlias">The alias of the property.</param>
    /// <returns>A collection of <see cref="Udi"/> instances.</returns>
    public static IEnumerable<Udi> GetUdis(this IContentBase content, string propertyAlias) {
        return UdiUtils.ParseUdis(content.GetValue<string>(propertyAlias));
    }

}