namespace Skybrud.Essentials.Umbraco.Manifests.Extensions.Workspaces;

/// <summary>
/// Represents an Umbraco workspace context extension.
/// </summary>
/// <remarks>
/// A workspace context extension provides an API that is instantiated within
/// matching Umbraco workspaces. Conditions can be used to control the
/// workspaces in which the context is available.
/// </remarks>
public class WorkspaceContextExtension : ConditionalExtension, IApiExtension {

    /// <summary>
    /// Gets the extension type.
    /// </summary>
    /// <value>
    /// Always <c>workspaceContext</c>.
    /// </value>
    public override string Type => "workspaceContext";

    /// <summary>
    /// Gets or sets the path to the JavaScript module that provides the workspace
    /// context API.
    /// </summary>
    public string? Api { get; init; }

    /// <summary>
    /// Gets or sets the path to the JavaScript module to load for the extension.
    /// </summary>
    public string? Js { get; init; }

}