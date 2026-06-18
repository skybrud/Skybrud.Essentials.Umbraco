using System;
using Examine.Lucene.Search;
using Examine.Search;

namespace Skybrud.Essentials.Umbraco.Examine;

/// <summary>
/// Static class with extension methods for <see cref="IQuery"/> instances used in Examine.
/// </summary>
public static class ExamineQueryExtensions {

    /// <summary>
    /// Enables leading wildcards for the specified <paramref name="query"/>. This allows queries to start with a wildcard character (e.g., "*term"), which can be useful for certain search scenarios but may impact performance. Use with caution.
    /// </summary>
    /// <param name="query">The <see cref="IQuery"/> instance to modify.</param>
    /// <returns>The modified <see cref="IQuery"/> instance.</returns>
    public static IQuery AllowLeadingWildcards(this IQuery query) {
        return AllowLeadingWildcards(query, true);
    }

    /// <summary>
    /// Enables or disables leading wildcards for the specified <paramref name="query"/> based on the value of <paramref name="allow"/>. When enabled, this allows queries to start with a wildcard character (e.g., "*term"), which can be useful for certain search scenarios but may impact performance. Use with caution.
    /// </summary>
    /// <param name="query">The <see cref="IQuery"/> instance to modify.</param>
    /// <param name="allow">A boolean value indicating whether to allow leading wildcards.</param>
    /// <returns>The modified <see cref="IQuery"/> instance.</returns>
    /// <exception cref="Exception">If <paramref name="query"/> is not an instance of <see cref="LuceneSearchQueryBase"/>.</exception>
    public static IQuery AllowLeadingWildcards(this IQuery query, bool allow) {
        if (query is not LuceneSearchQueryBase lucene) throw new Exception("Query must be an instance of 'LuceneSearchQueryBase'.");
        lucene.QueryParser.AllowLeadingWildcard = allow;
        lucene.SearchOptions.AllowLeadingWildcard = allow;
        return query;
    }

}