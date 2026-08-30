using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Localization;

/// <summary>
/// Represents metadata associated with an Umbraco localization extension.
/// </summary>
public class LocalizationMeta {

    /// <summary>
    /// Gets or sets the culture for which the localization entries are provided.
    /// </summary>
    /// <remarks>
    /// Examples include <c>en</c>, <c>en-US</c>, and <c>da-DK</c>.
    /// </remarks>
    public required string Culture { get; set; }

    /// <summary>
    /// Gets or sets the localization entries provided directly by the extension.
    /// </summary>
    /// <remarks>
    /// Localization entries can be provided directly instead of loading them
    /// from the JavaScript module specified by the extension.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LocalizationDictionary? Localizations { get; set; }

}