namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Clipboard;

/// <summary>
/// Represents an extension for translating a property editor value to a clipboard entry value.
/// </summary>
public class ClipboardCopyPropertyValueTranslatorExtension : IExtension {

    /// <summary>
    /// Gets the extension type.
    /// </summary>
    public string Type => "clipboardCopyPropertyValueTranslator";

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
    /// Gets or sets the alias of the property editor UI from which values can be copied.
    /// </summary>
    public required string FromPropertyEditorUi { get; set; }

    /// <summary>
    /// Gets or sets the clipboard entry value type produced by the translator.
    /// </summary>
    public required string ToClipboardEntryValueType { get; set; }

}