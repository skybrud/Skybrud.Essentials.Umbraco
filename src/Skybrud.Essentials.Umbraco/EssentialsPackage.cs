using System;
using System.Diagnostics;
using Umbraco.Cms.Core.Semver;

namespace Skybrud.Essentials.Umbraco;

/// <summary>
/// Static class with various information and constants about the package.
/// </summary>
public static class EssentialsPackage {

    /// <summary>
    /// Gets the alias of the package.
    /// </summary>
    public const string Alias = "Skybrud.Essentials.Umbraco";

    /// <summary>
    /// Gets the name of the package.
    /// </summary>
    public const string Name = "Skybrud Essentials Umbraco";

    /// <summary>
    /// Gets name of the <c>App_Plugins</c> subdirectory for the package.
    /// </summary>
    public const string AppPlugins = "Skybrud.Essentials";

    /// <summary>
    /// Gets the version of the package.
    /// </summary>
    public static readonly Version Version = typeof(EssentialsPackage).Assembly
        .GetName().Version!;

    /// <summary>
    /// Gets the informational version of the package.
    /// </summary>
    public static readonly string InformationalVersion = FileVersionInfo
        .GetVersionInfo(typeof(EssentialsPackage).Assembly.Location).ProductVersion!.Split('+')[0];

    /// <summary>
    /// Gets the semantic version of the package.
    /// </summary>
    public static readonly SemVersion SemVersion = InformationalVersion;

}