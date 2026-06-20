using System;
using System.Linq.Expressions;
using Skybrud.Essentials.Reflection;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Skybrud.Essentials.Umbraco.Content.BlockList;

public class BlockListItem : IBlockListItem {

    public BlockListContentData Content { get; set; }

    IBlockListContentData IBlockListItem.Content => Content;

    public BlockListContentData? Settings { get; set; }

    IBlockListContentData? IBlockListItem.Settings => Settings;

    public BlockListItem(BlockListContentData content) {
        Content = content;
    }

    public BlockListItem(BlockListContentData content, BlockListContentData? settings) {
        Content = content;
        Settings = settings;
    }

}

public class BlockListItem<TContent> : BlockListItem where TContent : PublishedElementModel {

    public new BlockListContentData<TContent> Content => (BlockListContentData<TContent>) base.Content;

    public BlockListItem(BlockListContentData<TContent> content) : base(content, null) { }

    protected BlockListItem(BlockListContentData<TContent> content, BlockListContentData? settings) : base(content, settings) { }

    public BlockListItem<TContent> SetContentValue<TProperty>(Expression<Func<TContent, TProperty>> selector, object? value) {

        // Get the name/alias of the property
        string alias = ReflectionUtils.GetPropertyInfo(selector).Name;

        // Not sure how much casing matters, so we better lookup the correct casing of the property type
        IPublishedPropertyType? propertyType = Content.ContentType.GetPropertyType(alias);
        if (propertyType is null) throw new Exception($"Property type with alias '{alias}' not found for content type '{Content.ContentType.Alias}'.");

        // Set the property value
        Content.SetValue(propertyType.Alias, value);

        return this;

    }

}

public class BlockListItem<TContent, TSettings> : BlockListItem<TContent> where TContent : PublishedElementModel where TSettings : PublishedElementModel {

    public new BlockListContentData<TSettings> Settings => (BlockListContentData<TSettings>) base.Settings!;

    public BlockListItem(BlockListContentData<TContent> content, BlockListContentData<TSettings> settings) : base(content, settings) { }

    public new BlockListItem<TContent, TSettings> SetContentValue<TProperty>(Expression<Func<TContent, TProperty>> selector, object? value) {

        // Get the name/alias of the property
        string alias = ReflectionUtils.GetPropertyInfo(selector).Name;

        // Not sure how much casing matters, so we better lookup the correct casing of the property type
        IPublishedPropertyType? propertyType = Content.ContentType.GetPropertyType(alias);
        if (propertyType is null) throw new Exception($"Property type with alias '{alias}' not found for content type '{Content.ContentType.Alias}'.");

        // Set the property value
        Content.SetValue(propertyType.Alias, value);

        return this;

    }

    public BlockListItem<TContent, TSettings> SetSettingsValue<TProperty>(Expression<Func<TSettings, TProperty>> selector, object? value) {

        // Get the name/alias of the property
        string alias = ReflectionUtils.GetPropertyInfo(selector).Name;

        // Not sure how much casing matters, so we better lookup the correct casing of the property type
        IPublishedPropertyType? propertyType = Settings.ContentType.GetPropertyType(alias);
        if (propertyType is null) throw new Exception($"Property type with alias '{alias}' not found for content type '{Settings.ContentType.Alias}'.");

        // Set the property value
        Settings.SetValue(propertyType.Alias, value);

        return this;

    }

}