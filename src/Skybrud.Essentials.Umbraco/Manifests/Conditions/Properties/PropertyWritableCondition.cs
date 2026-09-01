namespace Skybrud.Essentials.Umbraco.Manifests.Conditions.Properties;

/// <summary>
/// Represents the Umbraco condition that determines whether the current property is writable.
/// </summary>
public class PropertyWritableCondition : ICondition {

    /// <summary>
    /// Gets the alias of the condition.
    /// </summary>
    public string Alias => "Umb.Condition.Property.Writable";

}