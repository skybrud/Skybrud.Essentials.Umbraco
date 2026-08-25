namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Localization;

public class LocalizationExtensionMeta {

    /// <summary>
    /// The culture is a combination of a language and a country. The language is represented by an ISO 639-1 code and the country is represented by an ISO 3166-1 alpha-2 code.
    /// The language and country are separated by a dash.
    /// The value is used to describe the language of the translations according to the extension system, and it will be set as the <c>lang</c> attribute on the <c>&lt;html&gt;</c> element.
    /// </summary>
    public required string Culture { get; set; }

    /// <summary>
    /// The value is used to describe the direction of the translations according to the extension system, and it will be set as the <c>dir</c> attribute on the <c>&lt;html&gt;</c> element. It defaults to <c>ltr</c>.
    /// </summary>
    public string? Direction { get; set; }

    public LocalizationDictionary? Localizations { get; set; }

}