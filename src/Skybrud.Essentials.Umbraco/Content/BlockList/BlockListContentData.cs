using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Skybrud.Essentials.Reflection;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Skybrud.Essentials.Umbraco.Content.BlockList;

public class BlockListContentData : IBlockListContentData {

    public Guid ContentTypeKey { get; }

    public GuidUdi Udi { get; }

    public Dictionary<string, object?> Properties { get; set; } = new();

    IReadOnlyDictionary<string, object?> IBlockListContentData.Properties => Properties;

    public BlockListContentData(Guid key, Guid contentTypeKey) {
        Udi = new GuidUdi("element", key);
        ContentTypeKey = contentTypeKey;
    }

    public BlockListContentData(GuidUdi udi, Guid contentTypeKey) {
        Udi = udi;
        ContentTypeKey = contentTypeKey;
    }

    public BlockListContentData SetValue(string name, object? value) {
        if (value is null) return this;
        if (value is string str && string.IsNullOrWhiteSpace(str)) return this;
        Properties[name] = value;
        return this;
    }

}

public class BlockListContentData<TModel> : BlockListContentData where TModel : PublishedElementModel {

    public IPublishedContentType ContentType { get; }

    public BlockListContentData(Guid key, IPublishedContentType contentType) : base(key, contentType.Key) {
        ContentType = contentType;
    }

    public BlockListContentData<TModel> SetValue<TProperty>(Expression<Func<TModel, TProperty>> selector, object? value) {

        // Get the name/alias of the property
        string alias = ReflectionUtils.GetPropertyInfo(selector).Name;

        // Not sure how much casing matters, so we better lookup the correct casing of the property type
        IPublishedPropertyType? propertyType = ContentType.GetPropertyType(alias);
        if (propertyType is null) throw new Exception($"Property type with alias '{alias}' not found for content type '{ContentType.Alias}'.");

        // Set the property value
        SetValue(propertyType.Alias, value);

        return this;

    }

}