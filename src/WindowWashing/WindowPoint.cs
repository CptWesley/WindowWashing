using System.Runtime.InteropServices;

namespace WindowWashing;

/// <summary>
/// Represents a rectangle.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public record struct WindowPoint(int X, int Y)
{
    /// <summary>
    /// Implements the + operator.
    /// </summary>
    /// <param name="a">The first argument.</param>
    /// <param name="b">The second argument.</param>
    /// <returns>The result of the computation.</returns>
    public static WindowPoint operator +(WindowPoint a, WindowPoint b)
        => new WindowPoint(a.X + b.X, a.Y + b.Y);

    /// <summary>
    /// Implements the - operator.
    /// </summary>
    /// <param name="a">The first argument.</param>
    /// <param name="b">The second argument.</param>
    /// <returns>The result of the computation.</returns>
    public static WindowPoint operator -(WindowPoint a, WindowPoint b)
        => new WindowPoint(a.X - b.X, a.Y - b.Y);
}