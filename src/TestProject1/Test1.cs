using Skybrud.Essentials.Umbraco.Manifests.Extensions.Localization;
using Skybrud.Essentials.Umbraco.Manifests.Extensions.PropertyEditors;

namespace TestProject1;

[TestClass]
public sealed class Test1 {

    [TestMethod]
    public void TestMethod1() {

        PropertyEditorSchemaExtension schema = new() {
            Alias = "test",
            Name = "Test",
            Meta = new PropertyEditorSchemaMeta {
                DefaultPropertyEditorUiAlias = "test",
                Settings = new PropertyEditorSettings {
                    Properties = [
                        new PropertyEditorSettingsProperty {
                            Alias = "test",
                            Label = "Test",
                            PropertyEditorUiAlias = "test",
                            Config = new List<PropertyEditorConfigProperty>()
                                .Add("test", "value")
                                .Add("test2", "value2")
                        }
                    ]
                }
            }
        };

        Assert.HasCount(1, schema.Meta.Settings.Properties);

        var test = schema.Meta.Settings.Properties[0];

        Assert.IsNotNull(test);
        Assert.IsNotNull(test.Config);

        PropertyEditorConfigProperty? config1 = test.Config.FirstOrDefault(x => x.Alias == "test");
        PropertyEditorConfigProperty? config2 = test.Config.FirstOrDefault(x => x.Alias == "test2");

        Assert.IsNotNull(config1);
        Assert.IsNotNull(config2);

        Assert.AreEqual("value", config1.Value);
        Assert.AreEqual("value2", config2.Value);

    }

    [TestMethod]
    public void TestMethod2() {

        var extension1 = new LocalizationExtension {
            Alias = "test",
            Name = "Test: English (US)",
            Meta = new LocalizationMeta {
                Culture = "en",
                Localizations = new LocalizationDictionary {
                    ["section"] = new LocalizationSection {
                        ["key"] = "value"
                    }
                }
            }
        };

        var extension2 = new LocalizationExtension {
            Alias = "test",
            Name = "Test: English (US)",
            Meta = new LocalizationMeta {
                Culture = "en",
                Localizations = new LocalizationDictionary {
                    ["section"] = {
                        ["key"] = "value"
                    }
                }
            }
        };

        var value1 = extension1.Meta.Localizations?["section"].GetValueOrDefault("key");
        var value2 = extension2.Meta.Localizations?["section"].GetValueOrDefault("key");

        Assert.AreEqual("value", value1);
        Assert.AreEqual("value", value2);

        var dictionary1 = LocalizationDictionary
            .Create()
            .Add("section", "key", "value")
            .Add("section", new Dictionary<string, string> {
                {"key", "value"}
            });

        var value3 = dictionary1["section"].GetValueOrDefault("key");
        Assert.AreEqual("value", value3);

        var dictionary2 = LocalizationDictionary
            .Create()
            .Add("section", "key", "value")
            .Add("section", ("key", "value"));

        var value4 = dictionary2["section"].GetValueOrDefault("key");
        Assert.AreEqual("value", value4);

        var dictionary3 = LocalizationDictionary
            .Create()
            .Add("section", "key", "value")
            .Add("section", x => {
                x["key"] = "value";
                x.Add("key2", "value2");
            });

        Assert.AreEqual("value", dictionary3["section"].GetValueOrDefault("key"));
        Assert.AreEqual("value2", dictionary3["section"].GetValueOrDefault("key2"));

        var dictionary4 = LocalizationDictionary
            .Create()
            .Add("section", "key", "value")
            .Add("section", new LocalizationSection {
                {"key", "value"}
            });

    }

}