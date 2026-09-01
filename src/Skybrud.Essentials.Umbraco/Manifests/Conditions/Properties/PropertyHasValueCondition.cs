namespace Skybrud.Essentials.Umbraco.Manifests.Conditions.Properties;

/// <summary>
/// Represents the Umbraco condition that determines whether the current property has a value.
/// </summary>
public class PropertyHasValueCondition : ICondition {

    /// <summary>
    /// Gets the alias of the condition.
    /// </summary>
    public string Alias => "Umb.Condition.Property.HasValue";

}