using Examine;

namespace Skybrud.Essentials.Umbraco.Examine;

/// <summary>
/// Static class with extension methods for <see cref="IIndex"/>.
/// </summary>
public static class ExamineIndexExtensions {

    /// <summary>
    /// Same as calling the <see cref="IIndex.Searcher"/> property, but being a method, this looks prettier in a method chain.
    /// </summary>
    /// <param name="index">The index.</param>
    /// <returns>The searcher associated with the index.</returns>
    public static ISearcher GetSearcher(this IIndex index) {
        return index.Searcher;
    }

}