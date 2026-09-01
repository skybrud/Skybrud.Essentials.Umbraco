namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Clipboard;

/// <summary>
/// Represents an extension for translating a clipboard entry value to a property editor value.
/// </summary>
public class ClipboardPastePropertyValueTranslator : IExtension {

    /// <summary>
    /// Gets the extension type.
    /// </summary>
    public string Type => "clipboardPastePropertyValueTranslator";

    /// <summary>
    /// Gets or sets the unique alias of the extension.
    /// </summary>
    public required string Alias { get; set; }

    /// <summary>
    /// Gets or sets the friendly name of the extension.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the path to the JavaScript module providing the extension API.
    /// </summary>
    public required string Api { get; set; }

    /// <summary>
    /// Gets or sets the clipboard entry value type accepted by the translator.
    /// </summary>
    public required string FromClipboardEntryValueType { get; set; }

    /// <summary>
    /// Gets or sets the alias of the property editor UI to which the translated value applies.
    /// </summary>
    public required string ToPropertyEditorUi { get; set; }

}