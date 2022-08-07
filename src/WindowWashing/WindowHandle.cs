using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

namespace WindowWashing;

/// <summary>
/// Represents a window handle.
/// </summary>
[SupportedOSPlatform("windows")]
public unsafe readonly struct WindowHandle : IEquatable<WindowHandle>
{
    private readonly void* ptr;

    /// <summary>
    /// Initializes a new instance of the <see cref="WindowHandle"/> struct.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    public WindowHandle(void* hWnd)
        => this.ptr = hWnd;

    /// <summary>
    /// Initializes a new instance of the <see cref="WindowHandle"/> struct.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    public WindowHandle(nint hWnd)
        => this.ptr = (void*)hWnd;

    /// <summary>
    /// Gets the native window handle.
    /// </summary>
    public nint HWnd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (nint)ptr;
    }

    /// <summary>
    /// Gets the native window handle.
    /// </summary>
    public void* HWndPtr
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ptr;
    }

    /// <summary>
    /// Gets or sets the title of the window.
    /// </summary>
    public string Text
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Win32Windows.GetWindowText(ptr, true);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Win32Windows.SetWindowText(ptr, value, true);
    }

    /// <summary>
    /// Gets the class name of the window.
    /// </summary>
    public string ClassName
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Win32Windows.GetClassName(ptr, true);
    }

    /// <summary>
    /// Gets a value indicating whether or not this window exists.
    /// </summary>
    public bool Exists
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Win32Windows.IsWindow(ptr);
    }

    /// <summary>
    /// Gets or sets the parent of the window.
    /// </summary>
    public WindowHandle Parent
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new WindowHandle(Win32Windows.GetParent(ptr));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Win32Windows.SetParent(ptr, value.ptr, true);
    }

    /// <summary>
    /// Gets or sets the HINSTANCE of the window.
    /// </summary>
    public void* HInstancePtr
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Win32Windows.GetHInstance(ptr, true);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Win32Windows.SetHInstance(ptr, value, true);
    }

    /// <summary>
    /// Gets or sets the HINSTANCE of the window.
    /// </summary>
    public nint HInstance
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (nint)Win32Windows.GetHInstance(ptr, true);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Win32Windows.SetHInstance(ptr, (void*)value, true);
    }

    /// <summary>
    /// Gets or sets the identifier of the window.
    /// </summary>
    public void* IdPtr
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Win32Windows.GetIdentifier(ptr, true);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Win32Windows.SetIdentifier(ptr, value, true);
    }

    /// <summary>
    /// Gets or sets the identifier of the window.
    /// </summary>
    public nint Id
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (nint)Win32Windows.GetIdentifier(ptr, true);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Win32Windows.SetIdentifier(ptr, (void*)value, true);
    }

    /// <summary>
    /// Gets an accessor for chaging the style of the window.
    /// </summary>
    public WindowStyleAccessor Style
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new WindowStyleAccessor(this);
    }

    /// <summary>
    /// Gets or sets the window rectangle.
    /// </summary>
    public WindowRectangle Rectangle
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Win32Windows.GetWindowRect(ptr, true);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Move(value.X, value.Y, value.Width, value.Height, true);
    }

    /// <summary>
    /// Gets or sets the window size.
    /// </summary>
    public WindowPoint Size
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Rectangle.Size;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Rectangle = new WindowRectangle(Position, value);
    }

    /// <summary>
    /// Gets or sets the window position.
    /// </summary>
    public WindowPoint Position
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Rectangle.Position;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Rectangle = new WindowRectangle(value, Size);
    }

    /// <summary>
    /// Converts the window handle into a void pointer.
    /// </summary>
    /// <param name="wh">The window handle.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator void*(WindowHandle wh)
        => wh.ptr;

    /// <summary>
    /// Converts the window handle into a void pointer.
    /// </summary>
    /// <param name="wh">The window handle.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator nint(WindowHandle wh)
        => (nint)wh.ptr;

    /// <summary>
    /// Wraps a window handle.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator WindowHandle(void* hWnd)
        => new WindowHandle(hWnd);

    /// <summary>
    /// Wraps a window handle.
    /// </summary>
    /// <param name="hWnd">The window handle.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator WindowHandle(nint hWnd)
        => new WindowHandle(hWnd);

    /// <summary>
    /// Checks that two values are equal.
    /// </summary>
    /// <param name="lhs">The first value.</param>
    /// <param name="rhs">The second value.</param>
    /// <returns><c>true</c> if both values are equal, <c>false</c> otherwise.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(WindowHandle lhs, WindowHandle rhs)
        => lhs.Equals(rhs);

    /// <summary>
    /// Checks that two values are equal.
    /// </summary>
    /// <param name="lhs">The first value.</param>
    /// <param name="rhs">The second value.</param>
    /// <returns><c>true</c> if both values are equal, <c>false</c> otherwise.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(WindowHandle lhs, WindowHandle rhs)
        => !lhs.Equals(rhs);

    /// <summary>
    /// Gets the child windows of this window.
    /// </summary>
    /// <param name="recursively">Indicates whether or not the children should be retrieved recursively.</param>
    /// <returns>The children of this window.</returns>
    public IEnumerable<WindowHandle> GetChildren(bool recursively = false)
    {
        if (recursively)
        {
            return Win32Windows.EnumChildWindows(ptr).Select(x => new WindowHandle(x));
        }

        nint expectedParent = HWnd;
        return Win32Windows.EnumChildWindows(ptr)
        .Where(x => Win32Windows.GetParent(x) == expectedParent)
        .Select(x => new WindowHandle(x));
    }

    /// <summary>
    /// Destroy the current window.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Destroy()
        => Win32Windows.DestroyWindow(ptr, true);

    /// <summary>
    /// Execute the given show command on the window.
    /// </summary>
    /// <param name="cmd">The show command.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Show(ShowWindow cmd)
        => Win32Windows.ShowWindow(ptr, cmd, true);

    /// <summary>
    /// Moves the window to the given location.
    /// </summary>
    /// <param name="x">The new x coordinate.</param>
    /// <param name="y">The new y coordinate.</param>
    /// <param name="width">Thew new width.</param>
    /// <param name="height">The new height.</param>
    /// <param name="repaint">A value indicating whether or not to repaint this window after moving.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Move(int x, int y, int width, int height, bool repaint)
        => Win32Windows.MoveWindow(ptr, x, y, width, height, repaint, true);

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object obj)
        => obj is WindowHandle windowHandle && Equals(windowHandle);

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(WindowHandle other)
        => ptr == other.ptr;

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode()
        => unchecked((int)ptr);
}
