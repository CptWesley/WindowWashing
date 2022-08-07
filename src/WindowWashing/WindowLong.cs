namespace WindowWashing;

/// <summary>
/// Window long types.
/// </summary>
public enum WindowLong
{
    /// <summary>
    /// Indicates that the window long represents the extended style of a window.
    /// </summary>
    ExtendedStyle = -20,

    /// <summary>
    /// Indicates that the window long represents the application instance (<c>HINSTANCE</c>) of a window.
    /// </summary>
    HInstance = -6,

    /// <summary>
    /// Indicates that the window long represents the parent <c>hWnd</c> of a window.
    /// </summary>
    HWndParent = -8,

    /// <summary>
    /// Indicates that the window long represents the identifier of a window.
    /// </summary>
    Id = -12,

    /// <summary>
    /// Indicates that the window long represents the style of a window.
    /// </summary>
    Style = -16,

    /// <summary>
    /// Indicates that the window long represents the user data of a window.
    /// </summary>
    UserData = -21,

    /// <summary>
    /// Indicates that the window long represents the window procedure of a window.
    /// </summary>
    WndProc = -4,
}
