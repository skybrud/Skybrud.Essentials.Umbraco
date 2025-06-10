using System;
using Examine;

namespace Skybrud.Essentials.Umbraco.Examine;

/// <summary>
/// Static class with extension methods for <see cref="IExamineManager"/>.
/// </summary>
public static class ExamineManagerExtensions {

    /// <summary>
    /// Returns the index with the specified <paramref name="indexName"/>. If an index isn't found, an exception will be thrown instead.
    /// </summary>
    /// <param name="examineManager">An instance of <see cref="IExamineManager"/>.</param>
    /// <param name="indexName">The name of the index.</param>
    /// <returns>An instance of <see cref="IIndex"/> if successful.</returns>
    /// <exception cref="Exception">If a matching index isn't found.</exception>
    public static IIndex GetRequiredIndex(this IExamineManager examineManager, string indexName) {
        if (examineManager.TryGetIndex(indexName, out IIndex index)) return index;
        throw new Exception($"Failed getting Examine index with alias '{indexName}'...");
    }

    /// <summary>
    /// Returns the searcher with the specified <paramref name="searcherName"/>. If a searcher isn't found, an exception will be thrown instead.
    /// </summary>
    /// <param name="examineManager">An instance of <see cref="IExamineManager"/>.</param>
    /// <param name="searcherName">The name of the searcher.</param>
    /// <returns>An instance of <see cref="IIndex"/> if successful.</returns>
    /// <exception cref="Exception">If a matching index isn't found.</exception>
    public static ISearcher GetRequiredSearcher(this IExamineManager examineManager, string searcherName) {
        if (examineManager.TryGetSearcher(searcherName, out ISearcher searcher)) return searcher;
        throw new Exception($"Failed getting Examine searcher with alias '{searcher}'...");
    }

}