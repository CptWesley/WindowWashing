using System.Runtime.InteropServices;

namespace WindowWashing.Internal;

/// <summary>
/// Structure used for invoking Windows API.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal struct WindowRectInternal
{
    /// <summary>
    /// The x-coordinate of the top-left point.
    /// </summary>
    public int Left;

    /// <summary>
    /// The y-coordinate of the top-left point.
    /// </summary>
    public int Top;

    /// <summary>
    /// The x-coordinate of the bottom-right point.
    /// </summary>
    public int Right;

    /// <summary>
    /// The y-coordinate of the bottom-right point.
    /// </summary>
    public int Bottom;
}
