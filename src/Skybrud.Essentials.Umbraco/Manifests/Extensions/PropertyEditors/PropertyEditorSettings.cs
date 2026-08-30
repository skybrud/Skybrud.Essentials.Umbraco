using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.PropertyEditors;

/// <summary>
/// Represents the configurable settings of an Umbraco property editor schema.
/// </summary>
public class PropertyEditorSettings {

    /// <summary>
    /// Gets or sets the properties available for configuring the property editor schema.
    /// </summary>
    public List<PropertyEditorSettingsProperty> Properties { get; set; } = [];

    /// <summary>
    /// Gets or sets the optional default values for the property editor settings.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<PropertyEditorSettingsDefaultData>? DefaultData { get; set; }

}