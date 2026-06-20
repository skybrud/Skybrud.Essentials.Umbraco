using System.Collections.Generic;

namespace Skybrud.Essentials.Umbraco.Content.BlockList;

public interface IBlockListModel {

    int Count { get; }

    IReadOnlyList<IBlockListItem> Items { get; }

}