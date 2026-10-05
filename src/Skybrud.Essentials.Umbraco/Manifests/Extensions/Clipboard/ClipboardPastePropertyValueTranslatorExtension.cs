using System.Text.Json.Serialization;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Clipboard;

/// <summary>
/// Represents an extension for translating a clipboard entry value to a property editor value.
/// </summary>
public class ClipboardPastePropertyValueTranslatorExtension : Extension, IApiExtension {

    /// <summary>
    /// Gets the extension type.
    /// </summary>
    public override string Type => "clipboardPastePropertyValueTranslator";

    /// <summary>
    /// Gets or sets the path to the JavaScript module providing the extension API.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Api { get; set; }

    /// <summary>
    /// Gets the path to the JavaScript module to load for the extension.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Js { get; set; }

    /// <summary>
    /// Gets or sets the clipboard entry value type accepted by the translator.
    /// </summary>
    public required string FromClipboardEntryValueType { get; set; }

    /// <summary>
    /// Gets or sets the alias of the property editor UI to which the translated value applies.
    /// </summary>
    public required string ToPropertyEditorUi { get; set; }

}