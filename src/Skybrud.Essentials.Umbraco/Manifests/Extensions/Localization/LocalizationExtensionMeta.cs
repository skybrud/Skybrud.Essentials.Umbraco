using System.Collections.Generic;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Localization;

public class LocalizationExtensionMeta {

    public required string Culture { get; set; }

    public string? Js { get; set; }

    public Dictionary<string, Dictionary<string, string>>? Localizations { get; set; }

}