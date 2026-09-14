using System.Collections.Generic;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.PropertyEditors;

public static class PropertyEditorExtensions {

    public static List<PropertyEditorConfigProperty> Add(this List<PropertyEditorConfigProperty> list, string alias, object? value) {
        list.Add(new PropertyEditorConfigProperty(alias, value));
        return list;
    }

    public static List<PropertyEditorSettingsDefaultData> Add(this List<PropertyEditorSettingsDefaultData> list, string alias, object? value) {
        list.Add(new PropertyEditorSettingsDefaultData(alias, value));
        return list;
    }

}