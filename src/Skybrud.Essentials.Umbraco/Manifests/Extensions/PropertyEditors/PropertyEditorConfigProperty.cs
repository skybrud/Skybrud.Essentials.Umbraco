using System.Diagnostics.CodeAnalysis;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.PropertyEditors;

/// <summary>
/// Represents a configuration property for an Umbraco property editor UI.
/// </summary>
/// <remarks>
/// Configuration properties are serialized as alias/value pairs and are used to configure
/// the property editor UI associated with a property editor setting.
/// </remarks>
public class PropertyEditorConfigProperty {

    /// <summary>
    /// Gets or sets the alias identifying the configuration property.
    /// </summary>
    public required string Alias { get; set; }

    /// <summary>
    /// Gets or sets the value of the configuration property.
    /// </summary>
    /// <remarks>
    /// The value may be a primitive value, an object, an array, or <see langword="null"/>,
    /// depending on the configuration supported by the property editor UI.
    /// </remarks>
    public required object? Value { get; set; }

    /// <summary>
    /// Initializes a new, empty instance. Using this constructor, you must set the <see cref="Alias"/> and <see cref="Value"/> properties before using the instance.
    /// </summary>
    public PropertyEditorConfigProperty() { }

    /// <summary>
    /// Initializes a new instance with the specified <paramref name="alias"/> and <paramref name="value"/>.
    /// </summary>
    /// <param name="alias">The alias of the config property.</param>
    /// <param name="value">The value of the config property.</param>
    [SetsRequiredMembers]
    public PropertyEditorConfigProperty(string alias, object? value) {
        Alias = alias;
        Value = value;
    }

}