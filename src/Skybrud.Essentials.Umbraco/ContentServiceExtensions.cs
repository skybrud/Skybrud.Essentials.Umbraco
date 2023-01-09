using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;

namespace Skybrud.Essentials.Umbraco {

    /// <summary>
    /// Static class with various extension methods for <see cref="IContentService"/>.
    /// </summary>
    public static class ContentServiceExtensions {

        /// <summary>
        /// Returns the children of the node with the specified <paramref name="parentId"/>.
        /// </summary>
        /// <param name="service">A reference to the current <see cref="IContentService"/>.</param>
        /// <param name="parentId">The ID of the parent node.</param>
        /// <returns>An instance of <see cref="IEnumerable{IContent}"/>.</returns>
        public static IEnumerable<IContent> GetChildren(this IContentService service, int parentId) {
            return service.GetPagedChildren(parentId, 0, int.MaxValue, out long _);
        }

        /// <summary>
        /// Returns the children of the node with the specified <paramref name="parentId"/>.
        /// </summary>
        /// <param name="service">A reference to the current <see cref="IContentService"/>.</param>
        /// <param name="parentId">The ID of the parent node.</param>
        /// <param name="total">When this method returns, holds the amount of children returned.</param>
        /// <returns>An instance of <see cref="IEnumerable{IContent}"/>.</returns>
        public static IEnumerable<IContent> GetChildren(this IContentService service, int parentId, out long total) {
            return service.GetPagedChildren(parentId, 0, int.MaxValue, out total);
        }

        /// <summary>
        /// Returns the children of the specified <paramref name="parent"/> node.
        /// </summary>
        /// <param name="service">A reference to the current <see cref="IContentService"/>.</param>
        /// <param name="parent">The parent node.</param>
        /// <returns>An instance of <see cref="IEnumerable{IContent}"/>.</returns>
        public static IEnumerable<IContent> GetChildren(this IContentService service, IContent parent) {
            return service.GetPagedChildren(parent.Id, 0, int.MaxValue, out long _);
        }

        /// <summary>
        /// Returns the children of the specified <paramref name="parent"/> node.
        /// </summary>
        /// <param name="service">A reference to the current <see cref="IContentService"/>.</param>
        /// <param name="parent">The parent node.</param>
        /// <param name="total">When this method returns, holds the amount of children returned.</param>
        /// <returns>An instance of <see cref="IEnumerable{IContent}"/>.</returns>
        public static IEnumerable<IContent> GetChildren(this IContentService service, IContent parent, out long total) {
            return service.GetPagedChildren(parent.Id, 0, int.MaxValue, out total);
        }

        /// <summary>
        /// Sorts the nodes under the parent with the specified <paramref name="parentId"/> in ascending order.
        /// </summary>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
        /// <param name="service">A reference to the current <see cref="IContentService"/>.</param>
        /// <param name="parentId">The ID of the parent node.</param>
        /// <param name="keySelector">A function to extract a key from an element.</param>
        /// <param name="userId">The ID of the user responsible for the sort actions. Defaults to <see cref="Constants.Security.SuperUserId"/> if not specified.</param>
        /// <returns>An instance of <see cref="OperationResult"/> representing the result of the sort operation.</returns>
        public static OperationResult SortAscending<TKey>(this IContentService service, int parentId, Func<IContent, TKey> keySelector, int userId = Constants.Security.SuperUserId) {
            return service.Sort(GetChildren(service, parentId).OrderBy(keySelector), userId);
        }

        /// <summary>
        /// Sorts the nodes under the specified <paramref name="parent"/> in ascending order.
        /// </summary>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
        /// <param name="service">A reference to the current <see cref="IContentService"/>.</param>
        /// <param name="parent">The parent node.</param>
        /// <param name="keySelector">A function to extract a key from an element.</param>
        /// <param name="userId">The ID of the user responsible for the sort actions. Defaults to <see cref="Constants.Security.SuperUserId"/> if not specified.</param>
        /// <returns>An instance of <see cref="OperationResult"/> representing the result of the sort operation.</returns>
        public static OperationResult SortAscending<TKey>(this IContentService service, IContent parent, Func<IContent, TKey> keySelector, int userId = Constants.Security.SuperUserId) {
            return service.Sort(GetChildren(service, parent.Id).OrderBy(keySelector), userId);
        }

        /// <summary>
        /// Sorts the nodes under the parent with the specified <paramref name="parentId"/> in descending order.
        /// </summary>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
        /// <param name="service">A reference to the current <see cref="IContentService"/>.</param>
        /// <param name="parentId">The ID of the parent node.</param>
        /// <param name="keySelector">A function to extract a key from an element.</param>
        /// <param name="userId">The ID of the user responsible for the sort actions. Defaults to <see cref="Constants.Security.SuperUserId"/> if not specified.</param>
        /// <returns>An instance of <see cref="OperationResult"/> representing the result of the sort operation.</returns>
        public static OperationResult SortDescending<TKey>(this IContentService service, int parentId, Func<IContent, TKey> keySelector, int userId = Constants.Security.SuperUserId) {
            return service.Sort(GetChildren(service, parentId).OrderByDescending(keySelector), userId);
        }

        /// <summary>
        /// Sorts the nodes under the specified <paramref name="parent"/> in descending order.
        /// </summary>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
        /// <param name="service">A reference to the current <see cref="IContentService"/>.</param>
        /// <param name="parent">The parent node.</param>
        /// <param name="keySelector">A function to extract a key from an element.</param>
        /// <param name="userId">The ID of the user responsible for the sort actions. Defaults to <see cref="Constants.Security.SuperUserId"/> if not specified.</param>
        /// <returns>An instance of <see cref="OperationResult"/> representing the result of the sort operation.</returns>
        public static OperationResult SortDescending<TKey>(this IContentService service, IContent parent, Func<IContent, TKey> keySelector, int userId = Constants.Security.SuperUserId) {
            return service.Sort(GetChildren(service, parent.Id).OrderByDescending(keySelector), userId);
        }

    }

}