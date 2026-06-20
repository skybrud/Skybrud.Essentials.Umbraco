namespace Skybrud.Essentials.Umbraco.Content.BlockList;

public interface IBlockListItem {

    IBlockListContentData Content { get; }

    IBlockListContentData? Settings { get; }

}