namespace Skybrud.Essentials.Umbraco.Manifests.Conditions;

public abstract class Condition {

    public string Alias { get; }

    protected Condition(string alias) {
        Alias = alias;
    }

}