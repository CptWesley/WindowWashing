using System.Runtime.InteropServices;

namespace WindowWashing;

/// <summary>
/// Represents a rectangle.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public record struct WindowRectangle(int X, int Y, int Width, int Height)
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WindowRectangle"/> class.
    /// </summary>
    /// <param name="position">The top-left point of the rectangle.</param>
    /// <param name="size">The size of the rectangle.</param>
    public WindowRectangle(WindowPoint position, WindowPoint size)
        : this(position.X, position.Y, size.X, size.Y)
    {
    }

    /// <summary>
    /// Gets the top-left point of the rectangle.
    /// </summary>
    public WindowPoint Position => new WindowPoint(X, Y);

    /// <summary>
    /// Gets the size of the rectangle.
    /// </summary>
    public WindowPoint Size => new WindowPoint(Width, Height);
}