using System.Collections.Generic;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Localization;

public class LocalizationDictionary : Dictionary<string, Dictionary<string, string>> {

    public LocalizationDictionary Set(string section, string key, string value) {
        if (!ContainsKey(section)) this[section] = new Dictionary<string, string>();
        this[section][key] = value;
        return this;
    }

    public static LocalizationDictionary Create() {
        return new LocalizationDictionary();
    }

}