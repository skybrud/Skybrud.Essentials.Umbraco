using System.Text.Json.Serialization;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Clipboard;

/// <summary>
/// Represents an extension for translating a property editor value to a clipboard entry value.
/// </summary>
public class ClipboardCopyPropertyValueTranslatorExtension : Extension, IApiExtension {

    /// <summary>
    /// Gets the extension type.
    /// </summary>
    public override string Type => "clipboardCopyPropertyValueTranslator";

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
    /// Gets or sets the alias of the property editor UI from which values can be copied.
    /// </summary>
    public required string FromPropertyEditorUi { get; set; }

    /// <summary>
    /// Gets or sets the clipboard entry value type produced by the translator.
    /// </summary>
    public required string ToClipboardEntryValueType { get; set; }

}