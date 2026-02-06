using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Strings.Extensions;
using Skybrud.Essentials.Umbraco.Constants;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Skybrud.Essentials.Umbraco;

/// <summary>
/// Static utility class for working with <see cref="Udi"/> and <see cref="GuidUdi"/>.
/// </summary>
public static class UdiUtils {

    /// <summary>
    /// Creates a new <see cref="GuidUdi"/> from the specified <paramref name="entityType"/> and GUID <paramref name="key"/>.
    /// </summary>
    /// <param name="entityType">The entity type - e.g. <c>document</c> or <c>media</c>.</param>
    /// <param name="key">The GUID key.</param>
    /// <returns>An instance of <see cref="GuidUdi"/>.</returns>
    public static GuidUdi Create(string entityType, Guid key) {
        return new GuidUdi(entityType, key);
    }

    /// <summary>
    /// Creates a new <see cref="GuidUdi"/> from the specified <paramref name="entityType"/> and GUID <paramref name="key"/>.
    /// </summary>
    /// <param name="entityType">The entity type - e.g. <see cref="PublishedItemType.Content"/> or <see cref="PublishedItemType.Media"/>.</param>
    /// <param name="key">The GUID key.</param>
    /// <returns>An instance of <see cref="GuidUdi"/>.</returns>
    public static GuidUdi Create(PublishedItemType entityType, Guid key) {
        return new GuidUdi(entityType == PublishedItemType.Content ? UmbracoEntityTypes.Document : entityType.ToLower(), key);
    }

    /// <summary>
    /// Creates a new content (document) <see cref="GuidUdi"/> from the specified GUID <paramref name="key"/>.
    /// </summary>
    /// <param name="key">The GUID key.</param>
    /// <returns>An instance of <see cref="GuidUdi"/>.</returns>
    public static GuidUdi CreateContent(Guid key) {
        return new GuidUdi(UmbracoEntityTypes.Content, key);
    }

    /// <summary>
    /// Creates a new media (document) <see cref="GuidUdi"/> from the specified GUID <paramref name="key"/>.
    /// </summary>
    /// <param name="key">The GUID key.</param>
    /// <returns>An instance of <see cref="GuidUdi"/>.</returns>
    public static GuidUdi CreateMedia(Guid key) {
        return new GuidUdi(UmbracoEntityTypes.Media, key);
    }

    /// <summary>
    /// Creates a new member (document) <see cref="GuidUdi"/> from the specified GUID <paramref name="key"/>.
    /// </summary>
    /// <param name="key">The GUID key.</param>
    /// <returns>An instance of <see cref="GuidUdi"/>.</returns>
    public static GuidUdi CreateMember(Guid key) {
        return new GuidUdi(UmbracoEntityTypes.Member, key);
    }

    /// <summary>
    /// Parses an input string into a single <see cref="Udi"/> item.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>An instance of <see cref="Udi"/>.</returns>
    public static Udi Parse(string input) {
        return UdiParser.Parse(input);
    }

    /// <summary>
    /// Parses an input string into a list of <see cref="Udi"/> items.
    ///
    /// If any items in the input string cannot be parsed into a valid <see cref="Udi"/>, they are ignored.
    /// </summary>
    /// <param name="input">The input string (e.g. with comma separated UDI values).</param>
    /// <returns>A list of <see cref="Udi"/>.</returns>
    public static IEnumerable<Udi> ParseUdis(string? input) {
        return ParseUdiList(input);
    }

    /// <summary>
    /// Parses an input string into a list of <see cref="Udi"/> items.
    ///
    /// If any items in the input string cannot be parsed into a valid <see cref="Udi"/>, they are ignored.
    /// </summary>
    /// <param name="input">The input string (e.g. with comma separated UDI values).</param>
    /// <returns>A list of <see cref="Udi"/>.</returns>
    public static List<Udi> ParseUdiList(string? input) {

        if (string.IsNullOrWhiteSpace(input)) return [];

        List<Udi> temp = [];

        foreach (string piece in StringUtils.ParseStringArray(input)) {
            if (UdiParser.TryParse(piece, out Udi? udi)) temp.Add(udi);
        }

        return temp;

    }

    /// <summary>
    /// Parses an input string into a set of <see cref="Udi"/> items.
    ///
    /// If any items in the input string cannot be parsed into a valid <see cref="Udi"/>, they are ignored.
    /// </summary>
    /// <param name="input">The input string (e.g. with comma separated UDI values).</param>
    /// <returns>A set of <see cref="Udi"/>.</returns>
    public static HashSet<Udi> ParseUdiSet(string? input) {

        if (string.IsNullOrWhiteSpace(input)) return [];

        HashSet<Udi> temp = [];

        foreach (string piece in StringUtils.ParseStringArray(input)) {
            if (UdiParser.TryParse(piece, out Udi? udi)) temp.Add(udi);
        }

        return temp;

    }

    /// <summary>
    /// Attempts to convert the specified <paramref name="input"/> string into an instance of <see cref="Udi"/>.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <param name="result">When this method returns, holds the parsed <see cref="Udi"/> instance if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the parsing was successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryParse(string? input, [NotNullWhen(true)] out Udi? result) {
        return UdiParser.TryParse(input ?? string.Empty, out result);
    }

    /// <summary>
    /// Attempts to convert the specified <paramref name="input"/> string into an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the UDI - e.g. <see cref="GuidUdi"/>.</typeparam>
    /// <param name="input">The input string.</param>
    /// <param name="result">When this method returns, holds the parsed <typeparamref name="T"/> instance if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the parsing was successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryParse<T>(string? input, [NotNullWhen(true)] out T? result) where T : Udi {
        return UdiParser.TryParse(input, out result);
    }

}