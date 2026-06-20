using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Skybrud.Essentials.Reflection;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Skybrud.Essentials.Umbraco.Content;

public class ContentModel {

    // TODO: consider another name to not collide with the existing ContentModel in Umbraco

    public Guid? ParentKey { get; set; }

    public required Guid Key { get; set; }

    public required string Name { get; set; }

    public required string ContentTypeAlias { get; set; }

    public required DateTime CreateDate { get; set; }

    public required DateTime UpdateDate { get; set; }

    public Dictionary<string, object?> Properties { get; } = [];

}

public class ContentModel<TModel> : ContentModel where TModel : PublishedContentModel {

    public required IPublishedContentType ContentType { get; init; }

    public ContentModel<TModel> SetValue<TProperty>(Expression<Func<TModel, TProperty>> selector, object? value) {

        // Get the name/alias of the property
        string alias = ReflectionUtils.GetPropertyInfo(selector).Name;

        // Not sure how much casing matters, so we better lookup the correct casing of the property type
        IPublishedPropertyType? propertyType = ContentType.GetPropertyType(alias);
        if (propertyType is null) throw new Exception($"Property type with alias '{alias}' not found for content type '{ContentType.Alias}'.");

        // Set the property value
        if (value is null) {
            Properties.Remove(alias);
        } else {
            Properties[propertyType.Alias] = value;
        }

        return this;

    }

    public ContentModel<TModel> SetParent(Guid? parentKey) {
        ParentKey = parentKey;
        return this;
    }

    public ContentModel<TModel> SetParent(IContent? parent) {
        ParentKey = parent?.Key;
        return this;
    }

}