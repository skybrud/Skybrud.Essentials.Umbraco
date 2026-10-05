// ReSharper disable PossibleInterfaceMemberAmbiguity

namespace Skybrud.Essentials.Umbraco.Manifests.Extensions;

/// <summary>
/// Represents an Umbraco extension that can provide both a custom element
/// and an API.
/// </summary>
public interface IElementAndApiExtension : IElementExtension, IApiExtension;