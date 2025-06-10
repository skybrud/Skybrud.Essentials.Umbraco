using System;

namespace Skybrud.Essentials.Umbraco.Examine;

/// <summary>
/// Static class with constants for various date formats related to Examine.
/// </summary>
public class ExamineDateFormats {

    /// <summary>
    /// Represents a format where year, month, day and so forth is written first, so values may be sorted using regular string comparison.
    /// </summary>
    public const string Sortable = "yyyyMMddHHmmss000";

    /// <summary>
    /// Represents the default format used by Umbraco when adding <see cref="DateTime"/> values to the index.
    /// </summary>
    public const string Umbraco = "dd-MM-yyyy HH:mm:ss";

}