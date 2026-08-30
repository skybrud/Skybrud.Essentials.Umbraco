using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Modals;

/// <summary>
/// Represents metadata associated with an Umbraco modal extension.
/// </summary>
public class ModalMeta {

    /// <summary>
    /// Gets or sets additional metadata associated with the modal.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? Properties { get; set; }

}