using System;
using System.Collections.Generic;
using Umbraco.Cms.Core;

namespace Skybrud.Essentials.Umbraco.Content.BlockList;

public interface IBlockListContentData {

    Guid ContentTypeKey { get; }

    GuidUdi Udi { get; }

    IReadOnlyDictionary<string, object?> Properties { get; }

}