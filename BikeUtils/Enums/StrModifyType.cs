namespace BikeUtils.Enums;

/// <summary>
/// Types of string modification.
/// </summary>
public enum StrModiType
{
    /// <summary>
    /// Type to align the string.
    /// </summary>
    Align,
    /// <summary>
    /// Type to change the string's position.
    /// </summary>
    Pos,
    /// <summary>
    /// Type to change the vertical offset of the string.
    /// </summary>
    Voffset,
    /// <summary>
    /// Type to change the position and voffset.
    /// </summary>
    PosVoffset,
    /// <summary>
    /// Type to change position and align the text.
    /// </summary>
    PosAlign,
    /// <summary>
    /// Type to change the voffset and alignment.
    /// </summary>
    VoffsetAlign,
    /// <summary>
    /// Type to change all modifiers.
    /// </summary>
    PosVoffsetAlign
}